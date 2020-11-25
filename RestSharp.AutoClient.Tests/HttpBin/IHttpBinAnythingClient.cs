using System.Threading.Tasks;
using AutoRestClient.Attributes.Requests;
using AutoRestClient.Attributes.Response;
using AutoRestClient.Tests.HttpBin.Models;

namespace AutoRestClient.Tests.HttpBin
{
    [AddHeader("x-header-3", "x-header-value")]
    [Route("anything")]
    public interface IHttpBinAnythingClient
    {
        [HttpGet]
        [FromBody]
        Task<AnythingResponseBody> GetBodyAsync();
        
        [HttpPost("foo")]
        [AddHeader("x-header-1", "x-header-value")]
        [FromBody]
        Task<AnythingResponseBody> PostWithBindingsAsync(
            [ToQuery("queryParam")] string queryValue,
            [ToHeader("x-header-2")] string headerValue);

        [HttpPost]
        [FromResponse]
        Task<AnythingResponse> PostJson([ToRequest] AnythingRequest request);
        
        [HttpGet]
        [FromBody]
        AnythingResponseBody GetBodySync();
        
        [HttpGet]
        [FromRawBody]
        Task<byte[]> GetBytesBodyAsync();

        [HttpGet]
        [FromHeader("content-type")]
        Task<string> GetHeaderAsync();
    }
}