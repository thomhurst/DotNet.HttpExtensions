using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace TomLonghurst.Extensions.Http
{
    public static class HttpRequestMessageExtensions
    {
        public static IEnumerable<string> GetHeaderValues(this HttpRequestMessage httpRequestMessage, string headerName)
        {
            return httpRequestMessage.Headers.TryGetValues(headerName, out var values) ? values : Array.Empty<string>();
        }
        
        public static string GetHeader(this HttpRequestMessage request, string headerName)
        {
            return GetHeaderValues(request, headerName).FirstOrDefault();
        }

        public static HttpRequestMessage WithAuthorization(this HttpRequestMessage httpRequestMessage, string authorizationValue)
        {
            httpRequestMessage.Headers.Add(HttpRequestHeader.Authorization.ToString(), authorizationValue);
            return httpRequestMessage;
        }
    }
}