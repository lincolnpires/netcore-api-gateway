using NLog;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace OcelotApi
{
    internal class LogRequestDelegatingHandler : DelegatingHandler
    {
        static ILogger logger = LogManager.GetCurrentClassLogger();
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            logger.Debug("Logging from Delegate");
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
