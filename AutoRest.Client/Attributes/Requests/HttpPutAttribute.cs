using System.Net.Http;

namespace AutoRest.Client.Attributes.Requests
{
    public class HttpPutAttribute: HttpMethodAttribute
    {
        public HttpPutAttribute(string template = default) : base(HttpMethod.Put, template)
        {
        }
    }
}