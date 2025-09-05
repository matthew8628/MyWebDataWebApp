using Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using WebApi.Models;

public class UsersPageModel : PageModel // inherits from PageModel
{
    private readonly UserService _userService;

    public UsersPageModel(UserService userService)
    {
        _userService = userService;
    }

    public List<User> Users { get; set; } = new();

    public async Task OnGetAsync()
    {
        Users = await _userService.GetUsersAsync();
    }
}
