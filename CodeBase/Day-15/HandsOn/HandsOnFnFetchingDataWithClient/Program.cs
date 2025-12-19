using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using HandsOnFnFetchingData.Entities;
using Microsoft.Extensions.Configuration;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

builder.Services
    .AddApplicationInsightsTelemetryWorkerService()
    .ConfigureFunctionsApplicationInsights();
// Add DbContext with SQL Server provider
//builder.Services.AddDbContext<MyAppdbContext>(
//    options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnectionString"))
//    );
// Alternatively, you can use the following line if you prefer to access the connection string directly from configuration
builder.Services.AddDbContext<MyAppdbContext>(
    options => options.UseSqlServer(builder.Configuration["SqlConnectionString"])
    );
builder.Build().Run();
