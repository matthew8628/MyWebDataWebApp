using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using WebApi.Models;
using System.Collections.Generic;
using Services;


namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class FirstAPIController : ControllerBase
{
    private readonly UserService _userService;

    public FirstAPIController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet(Name = "GetData")]
    public async Task<IActionResult> GetData()
    {
        var users = await _userService.GetUsersAsync();
        return Ok(users);
    }
}

