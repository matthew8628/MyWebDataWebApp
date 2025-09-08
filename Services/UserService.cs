// calls an external API to get user data.
namespace Services;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Net.Http;
using System.Text.Json;

public class UserService : IUserService
{
    private readonly WebAppContext _context;

    public UserService(WebAppContext context) // Constructor that takes an HttpClient as a parameter
    {
        _context = context;
    }

    public async Task<List<User>> GetUsersAsync() // Method to fetch users
    {
        return await _context.User.ToListAsync();



        /* Legacy code to fetch from external API
         * 
        var response = await _httpClient.GetAsync("https://dummyjson.com/users"); // Gets the data from the API through set up http client
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync(); // Reads the response content as a string
        var usersResponse = JsonSerializer.Deserialize<UsersResponse>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }); // Deserializes the JSON string into a UsersResponse object

        return usersResponse?.Users ?? new List<User>(); //return list of users or empty if null
        */
    }
}