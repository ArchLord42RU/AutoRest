using System.Net.Http;

namespace AutoRest.Client.Attributes.Requests
{
    public class HttpPostAttribute: HttpMethodAttribute
    {
        public HttpPostAttribute(string template = default) : base(HttpMethod.Post, template)
        {
        }
    }
}