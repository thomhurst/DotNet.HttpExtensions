using System;
using System.Web;

namespace TomLonghurst.Extensions.Http
{
    public static class UriExtensions
    {
        public static Uri WithQueryParameter(this Uri uri, string paramName, string paramValue)
        {
            return new UriBuilder(uri)
                .WithQueryParameter(paramName, paramValue)
                .Uri;
        }
        
        public static UriBuilder WithQueryParameter(this UriBuilder uriBuilder, string paramName, string paramValue)
        {
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query[paramName] = paramValue;
            uriBuilder.Query = query.ToString();

            return uriBuilder;
        }

        public static Uri WithPath(this Uri uri, string path)
        {
            return new UriBuilder(uri)
                .WithPath(path)
                .Uri;
        }

        public static UriBuilder WithPath(this UriBuilder uriBuilder, string path)
        {
            uriBuilder.Path = path;
            return uriBuilder;
        }
        
        public static Uri ClearQueryParameters(this Uri uri)
        {
            return new UriBuilder(uri)
                .ClearQueryParameters()
                .Uri;
        }
        
        public static UriBuilder ClearQueryParameters(this UriBuilder uriBuilder)
        {
            uriBuilder.Query = string.Empty;
            return uriBuilder;
        }

        public static bool TryReadQueryParameter(this Uri uri, string parameterName,
            out string parameterValue)
        {
            return new UriBuilder(uri).TryReadQueryParameter(parameterName, out parameterValue);
        }

        public static bool TryReadQueryParameter(this UriBuilder uriBuilder, string parameterName, out string parameterValue)
        {
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            parameterValue = query[parameterName];

            return !string.IsNullOrEmpty(parameterValue);
        }
    }
}