namespace Web.ApiGateway.Services.Contracts;

public interface IHttpClientService
{
    Task<TResult> GetAsync<TResult>(string uri);

    Task<TResult> PostAsync<TResult>(string uri, object body);
    
    Task DeleteAsync(string uri);

    Task<TResult> PutAsync<TResult>(string uri, object body);
}
