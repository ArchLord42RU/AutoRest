using System.Net.Http;

namespace AutoRestClient.Attributes.Requests
{
    public class HttpPatchAttribute: HttpMethodAttribute
    {
        public HttpPatchAttribute(string template = default) : base(HttpMethod.Patch, template)
        {
        }
    }
}