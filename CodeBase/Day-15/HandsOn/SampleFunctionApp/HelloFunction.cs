using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace SampleFunctionApp;

public class HelloFunction
{
    private readonly ILogger<HelloFunction> _logger;

    public HelloFunction(ILogger<HelloFunction> logger)
    {
        _logger = logger;
    }

    [Function("HelloFunction")]
   
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        string name = req.Query["name"];
        if (string.IsNullOrEmpty(name))
        {
            return new OkObjectResult($"Welcome to Azure Functions!");
        }
        return new OkObjectResult($"Hello, {name}. Welcome to Azure Functions!");

    }
}