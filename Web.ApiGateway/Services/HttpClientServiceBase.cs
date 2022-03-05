using System.Text;
using System.Text.Json;
using Web.ApiGateway.CustomExceptions;
using Web.ApiGateway.Services.Contracts;

namespace Web.ApiGateway.Services;

public class HttpClientServiceBase : IHttpClientService
{
    private readonly HttpClient _httpClient;

    public HttpClientServiceBase(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.ConnectionClose = true;
    }

    public async Task<TResult> GetAsync<TResult>(string url)
    {
        var response = await _httpClient.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new NonSuccessRequestException(response.StatusCode, content);
        }

        var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        return JsonSerializer.Deserialize<TResult>(content, options);
    }

    public async Task<TResult> PostAsync<TResult>(string url, object body)
    {
        var json = JsonSerializer.Serialize(body);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(url, data);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new NonSuccessRequestException(response.StatusCode, content);
        }

        var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        return JsonSerializer.Deserialize<TResult>(content, options);
    }

    public async Task PostAsync(string url, object body)
    {
        var json = JsonSerializer.Serialize(body);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(url, data);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new NonSuccessRequestException(response.StatusCode, content);
        }
    }

    public async Task<TResult> PutAsync<TResult>(string url, object body)
    {
        var json = JsonSerializer.Serialize(body);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PutAsync(url, data);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new NonSuccessRequestException(response.StatusCode, content);
        }
        var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        return JsonSerializer.Deserialize<TResult>(content, options);
    }

    public async Task PutAsync(string url, object body)
    {
        var json = JsonSerializer.Serialize(body);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PutAsync(url, data);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new NonSuccessRequestException(response.StatusCode, content);
        }
    }

    public async Task DeleteAsync(string url)
    {
        var response = await _httpClient.DeleteAsync(url);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new NonSuccessRequestException(response.StatusCode, content);
        }
    }
}
