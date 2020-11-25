using AutoRestClient.Processing.Requests;

namespace AutoRestClient.Attributes.Requests
{
    public class ToJsonBodyAttribute: RequestParameterBindingAttribute
    {
        public override void Bind(RequestParameterBindingContext context)
        {
            context.ExecutionContext.RestRequest.AddJsonBody(context.MemberValue);
        }
    }
}