using System;

namespace TomLonghurst.MockHttpClient
{
    public class NoMockResponseSetupException : Exception
    {
        public NoMockResponseSetupException() : base("You must set up an expected response or exception to be returned by the HttpClient")
        {
            
        }
    }
}