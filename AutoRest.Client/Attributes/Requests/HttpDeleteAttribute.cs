using System.Net.Http;

namespace AutoRest.Client.Attributes.Requests
{
    public class HttpDeleteAttribute: HttpMethodAttribute
    {
        public HttpDeleteAttribute(string template = default) : base(HttpMethod.Delete, template)
        {
        }
    }
}