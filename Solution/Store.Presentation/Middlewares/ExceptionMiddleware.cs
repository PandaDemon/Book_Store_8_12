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
            catch (Exception ex)
            {
                try
                {
                    _logger.LogError("log error", ex);
                    _logger.LogInformation("log inform", ex);
                    _logger.LogDebug("log debug", ex);
                    _logger.LogCritical("critical exception", ex);
                }
                catch (Exception innerEx)
                {
                    _logger.LogError(0, innerEx, "Error handling exception");
                }

            }
        }
    }
}
