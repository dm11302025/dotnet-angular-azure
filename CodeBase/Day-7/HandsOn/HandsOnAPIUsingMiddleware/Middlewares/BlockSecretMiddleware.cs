namespace HandsOnAPIUsingMiddleware.Middlewares
{
    public class BlockSecretMiddleware
    {
        private readonly RequestDelegate _next;

        public BlockSecretMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/secret"))
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("❌ Access Denied: Secret path is blocked.");
                return; // stops pipeline
            }

            await _next(context);
        }
    }

    public static class BlockSecretMiddlewareExtensions
    {
        public static IApplicationBuilder UseSecretBlocker(this IApplicationBuilder app)
        {
            return app.UseMiddleware<BlockSecretMiddleware>();
        }
    }
}
