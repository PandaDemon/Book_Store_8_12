using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Store.Presentation.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                try
                {
                    _logger.LogError("Log error", exception);
                    _logger.LogInformation("Log inform", exception);
                    _logger.LogDebug("Log debug", exception);
                    _logger.LogCritical("Critical exception", exception);
                }
                catch (Exception innerException)
                {
                    _logger.LogError(0, innerException, "Error handling exception");
                }
            }
        }
    }
}
