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

    public async Task<bool> PostAsync<T>(string endpoint, T data)
    {
        var response = await _httpClient.PostAsJsonAsync(endpoint, data);
        return response.IsSuccessStatusCode;
    }
}
