using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Services;
using CleanArch.Domain.Interfaces;
using CleanArch.Infrastructure.Data;
using CleanArch.Infrastructure.Repositories;
using CleanArch.Mapping;
namespace CleanArch
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // AutoMapper
            builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());
            // DbContext  using UseSqlServer(connectionString)
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));
            // DI registrations
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }

    // -----------------------------
    // Extra notes & best practices
    // -----------------------------
    /*
    - Keep Domain layer free of framework references.
    - Application layer contains use-cases and DTOs. Prefer interfaces to enable testing.
    - Infrastructure depends on Domain & Application; provides persistence and external services.
    - API depends on Application (and optionally Infrastructure for DI), maps DTOs.
    - For larger apps, split Application into Commands/Queries (CQRS) — use patterns or MediatR if desired.
    - Add logging, FluentValidation for DTO validation, and global exception handling middleware in API.
    */
}
