namespace Web.ApiGateway.Services;

public class AccountHttpClientService : HttpClientServiceBase
{
    public AccountHttpClientService(IHttpClientFactory httpClientFactory) 
        : base(httpClientFactory.CreateClient("AccountService"))
    {
    }
}
