namespace Web.ApiGateway.Services;

public class PaymentHttpClientService : HttpClientServiceBase
{
    public PaymentHttpClientService(IHttpClientFactory httpClientFactory)
        : base(httpClientFactory.CreateClient("PaymentService"))
    {
    }
}
