namespace Services;
using WebApi.Models;
using System.Text.Json;

public class UserService
{
    private readonly HttpClient _httpClient;

    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<User>> GetUsersAsync()
    {
        var response = await _httpClient.GetAsync("https://dummyjson.com/users"); // Gets the data from the API through set up http client
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync(); // Reads the response content as a string
        var usersResponse = JsonSerializer.Deserialize<UsersResponse>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }); // Deserializes the JSON string into a UsersResponse object

        return usersResponse?.Users ?? new List<User>(); //return list of users or empty if null
    }
}