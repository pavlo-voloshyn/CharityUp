using Newtonsoft.Json;
using System.Text;
using Web.ApiGateway.CustomExceptions;

namespace Web.ApiGateway.Services;

/// <summary>
/// Base http client class for communicating between services via http
/// </summary>
public class HttpClientServiceBase 
{
    private readonly HttpClient _httpClient;

    public HttpClientServiceBase(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.ConnectionClose = true;
    }

    /// <summary>
    /// Get http request
    /// </summary>
    /// <typeparam name="TResult">Type of result</typeparam>
    /// <param name="url">url for request</param>
    /// <exception cref="NonSuccessRequestException">When request is not successful</exception>
    public async Task<TResult> GetAsync<TResult>(string url)
    {
        var response = await _httpClient.GetAsync(url);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new NonSuccessRequestException(response.StatusCode, content);
        }

        return JsonConvert.DeserializeObject<TResult>(content);
    }

    /// <summary>
    /// Post http request with response type
    /// </summary>
    /// <typeparam name="TResult">Reposnse type</typeparam>
    /// <param name="url">Url for request</param>
    /// <param name="body">Body of request</param>
    /// <exception cref="NonSuccessRequestException">If request is not successful</exception>
    public async Task<TResult> PostAsync<TResult>(string url, object body)
    {
        var json = JsonConvert.SerializeObject(body);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(url, data);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new NonSuccessRequestException(response.StatusCode, content);
        }

        return JsonConvert.DeserializeObject<TResult>(content);
    }

    /// <summary>
    /// Post http request with response type
    /// </summary>
    /// <param name="url">Url for request</param>
    /// <param name="body">Body of request</param>
    /// <exception cref="NonSuccessRequestException">If request is not successful</exception>
    public async Task PostAsync(string url, object body)
    {
        var json = JsonConvert.SerializeObject(body);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(url, data);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new NonSuccessRequestException(response.StatusCode, content);
        }
    }

    /// <summary>
    /// Put http request with response type
    /// </summary>
    /// <typeparam name="TResult">Reposnse type</typeparam>
    /// <param name="url">Url for request</param>
    /// <param name="body">Body of request</param>
    /// <exception cref="NonSuccessRequestException">If request is not successful</exception>
    public async Task<TResult> PutAsync<TResult>(string url, object body)
    {
        var json = JsonConvert.SerializeObject(body);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PutAsync(url, data);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new NonSuccessRequestException(response.StatusCode, content);
        }

        return JsonConvert.DeserializeObject<TResult>(content);
    }

    /// <summary>
    /// Put http request
    /// </summary>
    /// <param name="url">Url for request</param>
    /// <param name="body">Body of request</param>
    /// <exception cref="NonSuccessRequestException">If request is not successful</exception>
    public async Task PutAsync(string url, object body)
    {
        var json = JsonConvert.SerializeObject(body);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PutAsync(url, data);
        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new NonSuccessRequestException(response.StatusCode, content);
        }
    }

    /// <summary>
    /// Delete http request
    /// </summary>
    /// <param name="url">Url of request</param>
    /// <exception cref="NonSuccessRequestException">If request is not successful</exception>
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
