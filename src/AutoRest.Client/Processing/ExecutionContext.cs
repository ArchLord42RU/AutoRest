using System;
using RestSharp;

namespace AutoRest.Client.Processing
{
    public class ExecutionContext
    {
        public IRestRequest Request { get; internal set; }
        
        public IRestResponse Response { get; internal set; }
        
        public Type ClientType { get; internal set; }
    }
}