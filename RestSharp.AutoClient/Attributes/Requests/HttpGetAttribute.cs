using System.Net.Http;

namespace AutoRestClient.Attributes.Requests
{
    public class HttpGetAttribute: HttpMethodAttribute
    {
        public HttpGetAttribute(string template = default) : base(HttpMethod.Get, template)
        {
        }
    }
}