using AutoRestClient.Attributes.Response;

namespace AutoRestClient.Tests.HttpBin.Models
{
    public class AnythingResponse
    {
        [FromBody]
        public AnythingResponseBody Body { get; set; }
        
        [FromHeader("server")]
        public string Server { get; set; }
    }
}