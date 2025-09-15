// Exposes that user data from api via an endpoint.
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using Models;
using System.Collections.Generic;
using Services;


namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class UserAPIcontroller : ControllerBase
{
    private readonly IUserService _userService;

    public UserAPIcontroller(IUserService userService) // Constructor injection of UserService
    {
        _userService = userService; // Assign the injected service to a private field
    }

    [HttpGet(Name = "GetData")] 
    public async Task<IActionResult> GetData()
    {
        var users = await _userService.GetUsersAsync(); // Call the method to get users
        return Ok(users);
    }

    [HttpPost(Name = "CreateUser")]
    public async Task<IActionResult> CreateUserAsync(User NewUser)
    {
        await _userService.CreateUser(NewUser);
        return RedirectToPage("/DisplayData");
    }

    [HttpGet("NextId")]
    public async Task<int> GetNextId()
    {
        var maxId = await _userService.GetNextIdAsync();
        return maxId;
    }
}
