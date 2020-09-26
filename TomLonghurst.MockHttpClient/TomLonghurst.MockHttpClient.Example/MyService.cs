using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TomLonghurst.MockHttpClient.Example
{
    public class MyService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MyService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<HttpResponseMessage> ExecuteAsync()
        {
            var httpClient = _httpClientFactory.GetHttpClient();

            var response = await httpClient.GetAsync("https://www.google.com");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }

            return response;
        }
    }
}