
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace HandsOnAPIVersioning
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Enable API Versioning
            builder.Services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true; // default version if not specified
                options.DefaultApiVersion = new ApiVersion(1, 0);   // v1.0 is default
                options.ReportApiVersions = true;                   // adds headers "api-supported-versions"
            });
            // Enable API Explorer for Swagger
            builder.Services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV"; // v1, v2
                options.SubstituteApiVersionInUrl = true;
            });
            builder.Services.AddControllers();
       
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            // 🔹 Configure Swagger to show multiple versions
            builder.Services.AddSwaggerGen(options =>
            {
                // Later we’ll configure documents in app.UseSwaggerUI()
            });

           // builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
           

            var app = builder.Build();
            // Swagger setup
            var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
            
           
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                                                description.GroupName.ToUpperInvariant());
                    }
                });
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
