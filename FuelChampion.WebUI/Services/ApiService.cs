using System.Net.Http.Json;

namespace FuelChampion.WebUI.Services;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<T?> GetAsync<T>(string endpoint)
    {
        return await _httpClient.GetFromJsonAsync<T>(endpoint);
    }

    public async Task<bool> PostAsJsonAsync<T>(string endpoint, T data)
    {
        var response = await _httpClient.PostAsJsonAsync(endpoint, data);
        return response.IsSuccessStatusCode;
    }

    public async Task<HttpResponseMessage> PostAsJsonAsyncHttpResponse<T>(string endpoint, T data)
    {
        var response = await _httpClient.PostAsJsonAsync(endpoint, data);
        return response;
    }

    public async Task<HttpResponseMessage> PostAsync<T>(string endpoint, HttpContent httpContent)
    {
        var response = await _httpClient.PostAsync(endpoint, httpContent);
        return response;
    }


    public async Task<bool> PutAsync<T>(string endpoint, T data)
    {
        var response = await _httpClient.PutAsJsonAsync(endpoint, data);
        return response.IsSuccessStatusCode;
    }

    public async Task<HttpResponseMessage> DeleteAsync(string endpoint)
    {
        return  await _httpClient.DeleteAsync(endpoint);
    }

    //public async Task<HttpResponseMessage> GetAuthenticationStateAsync()
    //{
    //    return await _httpClient.GetAsync<AuthenticationState>("/AuthState");
    //}
}
