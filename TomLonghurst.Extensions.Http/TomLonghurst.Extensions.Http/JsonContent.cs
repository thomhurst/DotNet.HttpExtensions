using System.Net.Http;
using System.Text;

namespace TomLonghurst.Extensions.Http
{
    public class JsonContent : StringContent
    {
        private const string ApplicationJson = "application/json";

        public JsonContent(string content) : base(content, Encoding.UTF8, ApplicationJson)
        {
        }

        public JsonContent(string content, Encoding encoding) : base(content, encoding, ApplicationJson)
        {
        }
    }
}