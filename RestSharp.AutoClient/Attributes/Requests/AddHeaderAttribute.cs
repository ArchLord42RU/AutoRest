using AutoRestClient.Processing.Requests;

namespace AutoRestClient.Attributes.Requests
{
    public class AddHeaderAttribute: RequestModifierAttribute
    {
        private readonly string _name;
        private readonly string _value;

        public AddHeaderAttribute(string name, string value)
        {
            _name = name;
            _value = value;
        }
        
        public override void Apply(RequestExecutionContext context)
        {
            context.RestRequest.AddHeader(_name, _value);
        }
    }
}