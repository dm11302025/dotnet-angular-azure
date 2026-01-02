using System.Diagnostics;

public class RequestTimingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestTimingMiddleware> _logger;

    public RequestTimingMiddleware(
        RequestDelegate next,
        ILogger<RequestTimingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();

        using var activity = new Activity("HTTP Request");
        activity.Start();

        await _next(context); // Controller executes here

        stopwatch.Stop();
        activity.Stop();

        _logger.LogInformation(
            "Request {Method} {Path} completed in {Elapsed} ms | TraceId: {TraceId}",
            context.Request.Method,
            context.Request.Path,
            stopwatch.ElapsedMilliseconds,
            activity.TraceId);
    }
}
