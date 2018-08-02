using Newtonsoft.Json;
using Ocelot.Middleware;
using Ocelot.Middleware.Multiplexer;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OcelotApi
{
    public class ValuesAggregator : IDefinedAggregator
    {
        public async Task<DownstreamResponse> Aggregate(List<DownstreamResponse> responses)
        {
            const string mediaType = "application/json";

            var value1 = await responses[0].Content.ReadAsStringAsync();
            var value2 = await responses[1].Content.ReadAsStringAsync();

            var one = JsonConvert.DeserializeObject<IEnumerable<string>>(value1);
            var two = JsonConvert.DeserializeObject<IEnumerable<string>>(value2);

            var value = one.Union(two);

            HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(value), Encoding.Unicode, mediaType)
            };

            return await Task.FromResult(new DownstreamResponse(responseMessage));
        }
    }
}
