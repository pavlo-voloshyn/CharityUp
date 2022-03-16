namespace Web.ApiGateway.Services;

public class SubscriptionHttpClientService : HttpClientServiceBase
{
    public SubscriptionHttpClientService(IHttpClientFactory httpClientFactory)
        : base(httpClientFactory.CreateClient("SubscriptionService"))
    {
    }
}
