using System.Net.Http;

namespace AutoRest.Client.Attributes.Requests
{
    public class HttpGetAttribute: HttpMethodAttribute
    {
        public HttpGetAttribute(string template = default) : base(HttpMethod.Get, template)
        {
        }
    }
}