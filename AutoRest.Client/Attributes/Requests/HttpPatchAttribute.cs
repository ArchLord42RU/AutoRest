using System.Net.Http;

namespace AutoRest.Client.Attributes.Requests
{
    public class HttpPatchAttribute: HttpMethodAttribute
    {
        public HttpPatchAttribute(string template = default) : base(HttpMethod.Patch, template)
        {
        }
    }
}