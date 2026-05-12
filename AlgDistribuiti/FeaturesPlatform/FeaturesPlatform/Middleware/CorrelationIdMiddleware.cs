using FeaturesPlatform.Application.Common.Interfaces;

namespace FeaturesPlatform.API.Middleware
{
    public class CorrelationIdMiddleware
    {
        private const string HeaderName = "X-Correlation-Id";
        private readonly RequestDelegate _next;
        private readonly ICorrelationIdProvider _correlationIdProvider;

        public CorrelationIdMiddleware(RequestDelegate next,
            ICorrelationIdProvider correlationIdProvider)
        {
            _next = next;
            _correlationIdProvider = correlationIdProvider;
        }

        public async Task Invoke(HttpContext context)
        {
            var correlationId = context.Request.Headers[HeaderName].FirstOrDefault()
                ?? Guid.NewGuid().ToString();

            context.Items[HeaderName] = correlationId;
            context.Response.Headers[HeaderName] = correlationId;
            _correlationIdProvider.CorrelationId = Guid.Parse(correlationId);

            await _next(context);
        }
    }
}
