using System;
using RestSharp;

namespace AutoRestClient.Processing.Response
{
    public class ResponseParameterBindingContext
    {
        public IRestResponse Response { get; internal set; }
        
        public IResponseDeserializer Deserializer { get; internal set; }
        
        public Type ReturnValueType { get; set; }
        
        public object ReturnValue { get; set; }
    }
}