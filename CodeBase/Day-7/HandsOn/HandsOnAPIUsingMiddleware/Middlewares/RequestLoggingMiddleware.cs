namespace HandsOnAPIUsingMiddleware.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine($"➡ Request: {context.Request.Method} {context.Request.Path}");

            await _next(context);

            Console.WriteLine($"⬅ Response: {context.Response.StatusCode}");
        }
    }

    // Extension method for clean code
    public static class RequestLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RequestLoggingMiddleware>();
        }
    }
}
