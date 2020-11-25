using System.Collections.Generic;
using AutoRestClient.Attributes.Requests;

namespace AutoRestClient.Tests.HttpBin.Models
{
    public class AnythingRequest
    {
        [ToHeader("x-header-1")]
        public string Header { get; set; }
        
        [ToQuery("queryParam")]
        public string QueryParam { get; set; }
        
        [ToJsonBody]
        public Dictionary<string, string> Body { get; set; }
    }
}