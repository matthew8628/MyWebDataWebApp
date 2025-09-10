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


        [BindProperty]
        public User User { get; set; } = new();



        public async Task OnGetAsync(int id)
        {
            var fetchedUser = await _userService.GetUserByIdAsync(id);
            if (fetchedUser is not null)
            {
                User = fetchedUser;
            }
            // Optionally, handle the case where the user is not found (fetchedUser is null)
        }


        public async Task<IActionResult> OnPostSaveAsync()
        {
            Console.WriteLine($"Saving user: {User.Id}, {User.FirstName}, {User.Email}");
            await _userService.UpdateUserAsync(User);
            return Page();
        } 
    }
}