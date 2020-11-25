using RestSharp;

namespace AutoRestClient.Processing.Response
{
    public interface IResponseDeserializer
    {
        IRestResponse<TBody> Deserialize<TBody>(IRestResponse response);
    }
}