using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace TomLonghurst.MockHttpClient.Example.UnitTests
{
    public class Tests
    {
        private Mock<IHttpClientFactory> _httpClientFactory;
        
        private MyService _myService;

        [SetUp]
        public void Setup()
        {
            _httpClientFactory = new Mock<IHttpClientFactory>();
            _myService = new MyService(_httpClientFactory.Object);
        }

        [Test]
        public async Task Test1()
        {
            _httpClientFactory.Setup(factory => factory.GetHttpClient())
                .Returns(new MockHttpClient(new HttpResponseMessage(HttpStatusCode.OK)));
            
            var response = await _myService.ExecuteAsync();
            
            Assert.That(response.StatusCode == HttpStatusCode.OK);
        }
        
        [Test]
        public void Test2()
        {
            _httpClientFactory.Setup(factory => factory.GetHttpClient())
                .Returns(new MockHttpClient(new HttpResponseMessage(HttpStatusCode.BadRequest)));
            
            Assert.ThrowsAsync<Exception>(() => _myService.ExecuteAsync());
        }
        
        [Test]
        public void Test3()
        {
            _httpClientFactory.Setup(factory => factory.GetHttpClient())
                .Returns(new MockHttpClient(new AggregateException()));
            
            Assert.ThrowsAsync<AggregateException>(() => _myService.ExecuteAsync());
        }
    }
}