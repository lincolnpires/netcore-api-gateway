using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace OcelotApi
{
    public static class HttpGetRequester
    {
        public async static Task<HttpResponseMessage> SendRequest(string uri, CancellationToken cancellationToken)
        {
            return await new HttpClient()
                .GetAsync(uri, HttpCompletionOption.ResponseContentRead, cancellationToken)
                .ConfigureAwait(continueOnCapturedContext: false);
        }

        public async static Task<HttpResponseMessage> SendRequest(Uri uri, CancellationToken cancellationToken)
        {
            return await new HttpClient()
                .GetAsync(uri, HttpCompletionOption.ResponseContentRead, cancellationToken)
                .ConfigureAwait(continueOnCapturedContext: false);
        }
    }
}
