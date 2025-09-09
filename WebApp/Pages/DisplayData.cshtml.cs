// Page model
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using System.Security.Cryptography.X509Certificates;
using Models;

namespace WebApp.Pages
{
    public class DisplayDataModel : PageModel
    {
        private readonly ILogger<DisplayDataModel>? _logger;


        private readonly IUserService _userService; 

        public DisplayDataModel(IUserService userService)
        {
            _userService = userService; 
        }



        public IActionResult OnPostTestFunc()  // Must start with "OnPost" to handle POST requests
        {
            return RedirectToPage("/Index");
        }


        public List<User> Users { get; set; } = new(); // 

        public async Task OnGetAsync()
        {
            Users = await _userService.GetUsersAsync();
        }
    }
}
