using AutoRestClient.Processing.Response;

namespace AutoRestClient.Attributes.Response
{
    public class FromRawBody: ResponseParameterBindingAttribute
    {
        public override void Bind(ResponseParameterBindingContext context)
        {
            context.ReturnValue = context.Response.RawBytes;
        }
    }
}