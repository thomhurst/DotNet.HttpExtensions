using System.Net.Http;

namespace TomLonghurst.MockHttpClient.Example
{
    public interface IHttpClientFactory
    {
        HttpClient GetHttpClient();
    }

    public class HttpClientFactory : IHttpClientFactory
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public HttpClient GetHttpClient()
        {
            return _httpClient;
        }
    }
}