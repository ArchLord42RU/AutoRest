using AutoRestClient.Processing.Requests;

namespace AutoRestClient.Attributes.Requests
{
    public class ToHeaderAttribute: RequestParameterBindingAttribute
    {
        private readonly string _name;

        public ToHeaderAttribute(string name = default)
        {
            _name = name;
        }
        
        public override void Bind(RequestParameterBindingContext context)
        {
            var headerName = _name ?? context.MemberName;
            context.ExecutionContext.RestRequest.AddHeader(headerName, context.MemberValue?.ToString() ?? "");
        }
    }
}