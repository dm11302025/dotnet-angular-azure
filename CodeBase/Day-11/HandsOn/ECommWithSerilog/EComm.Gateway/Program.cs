
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Serilog;
namespace EComm.Gateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Add Ocelot configuration file
            builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
            // Add Ocelot services
            Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .Enrich.FromLogContext()
    .Enrich.WithProperty("ServiceName", "ApiGateway")
    .WriteTo.Console()
    .WriteTo.Seq("http://localhost:5341")
    .CreateLogger();

            builder.Host.UseSerilog();
            builder.Services.AddOcelot();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseSerilogRequestLogging();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            // Add Correlation ID middleware
            app.Use(async (context, next) =>
            {
                var correlationId = Guid.NewGuid().ToString();

                context.Response.Headers.Add("X-Correlation-Id", correlationId);

                using (Serilog.Context.LogContext.PushProperty(
                    "CorrelationId", correlationId))
                {
                    await next();
                }
            });

            app.UseAuthorization();
            app.MapControllers();
            app.UseOcelot(); // Use Ocelot middleware
            app.Run();
        }
    }
}
