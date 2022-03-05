namespace Web.ApiGateway.Services;

public class FoundationHttpClientService : HttpClientServiceBase
{
    public FoundationHttpClientService(IHttpClientFactory httpClientFactory)
        : base(httpClientFactory.CreateClient("FoundationService"))
    {
    }
}
