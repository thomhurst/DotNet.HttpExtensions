using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TomLonghurst.MockHttpClient
{
    public class MockHttpClientHandler : HttpClientHandler
    {
        public MockHttpClientHandler()
        {
            
        }

        public MockHttpClientHandler(HttpResponseMessage responseMessage)
        {
            ResponseMessage = responseMessage;
        }
        
        public MockHttpClientHandler(Exception exception)
        {
            Exception = exception;
        }
        
        public HttpResponseMessage ResponseMessage { get; set; }
        public Exception Exception { get; set; }
        
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (Exception != null)
            {
                throw Exception;
            }

            if (ResponseMessage == null)
            {
                throw new NoMockResponseSetupException();
            }

            return Task.FromResult(ResponseMessage);
        }
    }

    public class MockHttpClient : HttpClient
    {
        public MockHttpClient(HttpResponseMessage responseMessage) : base(new MockHttpClientHandler(responseMessage))
        {
        }
        
        public MockHttpClient(Exception exception) : base(new MockHttpClientHandler(exception))
        {
        }
    }
}