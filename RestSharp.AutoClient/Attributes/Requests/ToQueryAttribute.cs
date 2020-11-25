using AutoRestClient.Processing.Requests;

namespace AutoRestClient.Attributes.Requests
{
    public class ToQueryAttribute: RequestParameterBindingAttribute
    {
        private readonly string _name;

        public ToQueryAttribute(string name = default)
        {
            _name = name;
        }

        public override void Bind(RequestParameterBindingContext context)
        {
            var queryParamName = _name ?? context.MemberName;
            context.ExecutionContext.RestRequest.AddQueryParameter(queryParamName, context.MemberValue?.ToString() ?? "");
        }
    }
}