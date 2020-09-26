using System.Net;

namespace TomLonghurst.Extensions.Http
{
    public static class HttpStatusCodeExtensions
    {
        public static int? GetIntValueOrDefault(this HttpStatusCode? httpStatusCode)
        {
            if (!httpStatusCode.HasValue)
            {
                return null;
            }

            return (int) httpStatusCode.Value;
        }
        
        public static int? GetIntValue(this HttpStatusCode httpStatusCode)
        {
            return (int) httpStatusCode;
        }
    }
}