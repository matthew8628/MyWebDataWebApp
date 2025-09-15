 // calls an external API to get user data.
namespace Services;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly HttpClient _httpClient; // HttpClient to make HTTP requests

    public UserService(IUserRepository repository, HttpClient httpClient) // Constructor that takes an HttpClient as a parameter
    {
        _userRepository = repository;
        _httpClient = httpClient;
    }

    public async Task<User> CreateUser(User NewUser)
    {
        await _userRepository.AddUserAsync(NewUser);
        return NewUser;
    }  

    public async Task<List<User>> GetUsersAsync() // Method to fetch users
    {
        var usersFromDb = await _userRepository.GetUsersAsync();

        if (usersFromDb != null && usersFromDb.Any())
        {
            return usersFromDb;
        }

        // If everything fails, return an empty list
        return new List<User>();

    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await _userRepository.GetUserByIdAsync(id);

    }

    public async Task<User> UpdateUserAsync(User user)
    {
        await _userRepository.UpdateUserAsync(user);
        return user;
    } 

    public async Task DeleteUserAsync(int id)
    {
        await _userRepository.DeleteUserAsync(id);

    }

    public async Task<int> GetNextIdAsync()
    {
        var usersFromDb = await _userRepository.GetUsersAsync();

        var maxId = usersFromDb.Any() ? usersFromDb.Max(u => u.Id) : 0;

        return maxId + 1;
    }
}








// Legacy code??

/*
// var response = await _httpClient.GetAsync("https://dummyjson.com/users"); Gets the data from the API through set up http client
var response = await _httpClient.GetFromJsonAsync<UsersResponse>("https://dummyjson.com/users");

if (response?.Users != null)
{
    foreach (var user in response.Users)
    {
        // Avoid duplicates just in case
        var existingUser = await _userRepository.GetUserByIdAsync(user.Id);
        if (existingUser == null)
        {
            await _userRepository.AddUserAsync(user);
        }
    }

    // Return the API users (now also saved in the database)
    return response.Users;
}  */
