
using HandsOnAPIUsingMiddleware.Middlewares;

namespace HandsOnAPIUsingMiddleware
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // ----------------------------------------------
            // 🔥 GLOBAL MIDDLEWARE PIPELINE
            // ----------------------------------------------

            app.UseHttpsRedirection();

            // 1️⃣ Custom logging middleware
            app.UseRequestLogging();
            //app.UseMiddleware<RequestLoggingMiddleware>(); //add custome middleware

            // 2️⃣ Middleware that blocks /secret route
            app.UseSecretBlocker();

            // 3️⃣ Built-in middleware for Swagger
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            // Maps controller endpoints
            app.MapControllers();

            // 4️⃣ Terminal Middleware for unmatched routes
            app.Run(async context =>
            {
                await context.Response.WriteAsync("✔ Pipeline reached the end.");
            });

            // Run the app
            app.Run();
        }
    }
}