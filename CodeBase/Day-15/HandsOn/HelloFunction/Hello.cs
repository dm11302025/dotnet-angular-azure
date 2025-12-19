using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace HelloFunction;

public class Hello
{
    private readonly ILogger<Hello> _logger;

    public Hello(ILogger<Hello> logger)
    {
        _logger = logger;
    }

    [Function("Greet")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get",Route ="green/{name}")] HttpRequest req,string name)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
       // var name=req.Query["name"].ToString(); // get the 'name' query parameter
        //var name=req.RouteValues["name"]?.ToString(); // get the 'name' route parameter
        if (!string.IsNullOrEmpty(name))
        {
            return new OkObjectResult($"Hello, {name}!");
        }
        return new OkObjectResult("Welcome to Azure Functions!");
    }
}