using HandsOnFnFetchingData.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net;

namespace HandsOnFnFetchingData;

public class EmployeeFunction
{
    private readonly ILogger<EmployeeFunction> _logger;
    private readonly MyAppdbContext ?_dbContext;

    public EmployeeFunction(ILogger<EmployeeFunction> logger, MyAppdbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }
    [Function("GetEmployees")]
    public async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req)
    {
        var data = await _dbContext.Employees.ToListAsync();
        var response = req.CreateResponse();// default is 200 OK
        response.StatusCode = HttpStatusCode.OK;
        await response.WriteAsJsonAsync(data); // write the data to response body
        return response; // return the response
    }
}