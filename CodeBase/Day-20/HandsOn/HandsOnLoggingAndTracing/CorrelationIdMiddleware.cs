using System.Diagnostics;

namespace HandsOnLoggingAndTracing
{
    public class CorrelationIdMiddleware
    {
        private readonly RequestDelegate _next;
        private const string HeaderName = "X-Correlation-Id";

        public CorrelationIdMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var correlationId = context.Request.Headers.ContainsKey(HeaderName)
                ? context.Request.Headers[HeaderName].ToString()
                : Guid.NewGuid().ToString();

            context.Response.Headers[HeaderName] = correlationId;

            using (Activity activity = new Activity("HTTP Request"))
            {
                activity.SetIdFormat(ActivityIdFormat.W3C);
                activity.Start();
                activity.AddTag("correlation.id", correlationId);

                await _next(context);

                activity.Stop();
            }
        }
    }

}
