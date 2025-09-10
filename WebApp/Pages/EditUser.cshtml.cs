using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Services;

namespace WebApp.Pages
{
    public class EditUserModel : PageModel
    {
        private readonly IUserService _userService;

        public EditUserModel(IUserService userService)
        {
            _userService = userService;
        }

        public List<User> Users { get; set; } = new();


        public async Task OnGetAsync()
        {
            Users = await _userService.GetUsersAsync();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            Users = await _userService.GetUsersAsync();
            return Page();
        }
    }
}
