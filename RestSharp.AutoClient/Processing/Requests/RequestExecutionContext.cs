using System.Reflection;
using RestSharp;

namespace AutoRestClient.Processing.Requests
{
    public class RequestExecutionContext
    {
        public IRestRequest RestRequest { get; internal set; }
        
        public MethodInfo Method { get; internal set; }
        
        public IValueResolver ValueResolver { get; internal set; }
    }
}