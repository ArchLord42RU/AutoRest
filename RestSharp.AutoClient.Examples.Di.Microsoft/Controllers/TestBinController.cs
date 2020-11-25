using System.Threading.Tasks;
using AutoRestClient.Tests.HttpBin;
using Microsoft.AspNetCore.Mvc;

namespace RestSharp.AutoClient.Examples.Di.Microsoft.Controllers
{
    [Route("test")]
    public class TestBinController: ControllerBase
    {
        private readonly IHttpBinAnythingClient _client;

        public TestBinController(IHttpBinAnythingClient client)
        {
            _client = client;
        }
        
        [HttpGet]
        public async Task<string> TestGet()
        {
            var result = await _client.GetHeaderAsync();
            return await Task.FromResult("hello");
        }
    }
}