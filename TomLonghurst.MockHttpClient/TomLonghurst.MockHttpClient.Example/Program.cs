using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace TomLonghurst.MockHttpClient.Example
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IHttpClientFactory, HttpClientFactory>()
                .AddSingleton<MyService>()
                .BuildServiceProvider();

            var myService = serviceProvider.GetService<MyService>();

            await myService.ExecuteAsync();
        }
    }
}