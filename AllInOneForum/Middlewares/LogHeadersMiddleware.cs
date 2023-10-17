using Serilog.Context;
using Serilog.Enrichers;

namespace AllInOneForum.Middlewares
{
    public class LogHeadersMiddleware
    {
        readonly RequestDelegate _next;
        const string CORRELATIONID = "CorrelationId";

        public LogHeadersMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.Headers[CORRELATIONID] = httpContext.Response.Headers[CORRELATIONID].FirstOrDefault() ?? Guid.NewGuid().ToString();
            using (LogContext.Push(new CorrelationIdHeaderEnricher(CORRELATIONID)))
            {
                await _next(httpContext);
            } 
        }
    }
}
