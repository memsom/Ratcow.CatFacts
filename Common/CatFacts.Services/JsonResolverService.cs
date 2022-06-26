using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CatFacts.Services
{
    public class JsonResolverService : IJsonResolverService
    {
        public async Task<string> GetJsonResponse(string url, string key = null)
        {
            try
            {



                var handler = new TimeoutHandler
                {
                    DefaultTimeout = TimeSpan.FromSeconds(10),
                    InnerHandler = new HttpClientHandler()
                };

                using (var cts = new CancellationTokenSource())
                using (var client = new HttpClient(handler) { Timeout = Timeout.InfiniteTimeSpan })
                {

                    var request = new HttpRequestMessage
                    {
                        RequestUri = new Uri(url),
                        Method = HttpMethod.Get
                    };

                    request.SetTimeout(TimeSpan.FromSeconds(5));

                    if (key != null)
                    {
                        request.Headers.Add("api_key", key);
                    }
                    try
                    {
                        using (var response = await client.SendAsync(request, cts.Token))
                        {
                            return await response.Content.ReadAsStringAsync();
                        }
                    }
                    catch (TimeoutException)
                    {
                        return default;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return default;
            }
        }
    }
}

