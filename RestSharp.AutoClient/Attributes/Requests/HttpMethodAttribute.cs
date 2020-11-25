using System;
using System.Net.Http;
using AutoRestClient.Processing;
using AutoRestClient.Processing.Requests;
using RestSharp;

namespace AutoRestClient.Attributes.Requests
{
    [AttributeUsage(AttributeTargets.Method)]
    public class HttpMethodAttribute: RequestModifierAttribute
    {
        private readonly HttpMethod _method;
        private readonly string _template;

        // ReSharper disable once MemberCanBeProtected.Global
        public HttpMethodAttribute(HttpMethod method, string template = default)
        {
            _method = method;
            _template = template;
        }
        
        public override void Apply(RequestExecutionContext context)
        {
            context.RestRequest.Method = Enum.Parse<Method>(_method.Method);
            context.RestRequest.Resource = ProcessingUtils.CombineUrl(context.RestRequest.Resource, _template);
        }
    }
}