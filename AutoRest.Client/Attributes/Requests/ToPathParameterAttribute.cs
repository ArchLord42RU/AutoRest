using System;
using AutoRest.Client.Processing.Requests;

namespace AutoRest.Client.Attributes.Requests
{
    public class ToPathParameterAttribute: RequestParameterBindingAttribute
    {
        private readonly string _paramName;

        public ToPathParameterAttribute(string paramName = default)
        {
            _paramName = paramName;
        }
        
        public override void Bind(RequestParameterBindingContext context)
        {
            var paramName = _paramName ?? context.MemberName;
            
            context.ExecutionContext.RestRequest.AddParameter(paramName, context.MemberValue);
        }
    }
}