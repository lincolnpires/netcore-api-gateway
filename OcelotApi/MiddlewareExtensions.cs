using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using NLog;
using System.Threading.Tasks;

namespace OcelotApi
{
    internal static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseLogRequest(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogRequestMiddleware>();
        }
    }

    internal class LogRequestMiddleware
    {
        private readonly RequestDelegate next;
        static ILogger logger = LogManager.GetCurrentClassLogger();

        public LogRequestMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            logger.Debug("Logging from Middleware");
            await next(context);
            logger.Debug("Logging from Middleware back from the pipeline...");
        }
    }
}
