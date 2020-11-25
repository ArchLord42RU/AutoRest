using System.Net.Http;

namespace AutoRestClient.Attributes.Requests
{
    public class HttpDeleteAttribute: HttpMethodAttribute
    {
        public HttpDeleteAttribute(string template = default) : base(HttpMethod.Delete, template)
        {
        }
    }
}