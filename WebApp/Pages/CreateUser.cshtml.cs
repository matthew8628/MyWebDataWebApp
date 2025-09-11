using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Models;
using Services;
using System.Net.Http;

namespace WebApp.Pages
{
    public class CreateUserModel : PageModel
    {
        private readonly HttpClient _httpClient; 

        public CreateUserModel(HttpClient httpClient)
        {
            _httpClient = httpClient;  // Inject the IUserService
        }


        [BindProperty]
        public User NewUser { get; set; } = new(); // Create a new instance of User to hold the form data


        public async Task<IActionResult> OnPostAsync() // Handle form submission
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7050/UserAPI", NewUser);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/DisplayData"); // go back to list after create
            }

            return Page();

        }

        public void OnGet()
        {

        }
    }
}





/* namespace WebApp.Pages
{
    public class CreateUserModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public CreateUserModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MyApi");
        }

        [BindProperty]
        public User User { get; set; } = new();


        public async Task<IActionResult> OnPostAsync()
        {
            // Send new user to WebAPI
            var response = await _httpClient.PostAsJsonAsync("api/users", User);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/DisplayData"); // go back to list after create
            }

            // stay on page if something failed
            ModelState.AddModelError(string.Empty, "Could not create user.");
            return Page();
        }
    }
}



[HttpPost]
public async Task<ActionResult<User>> CreateUser(User user)
{
    _context.Users.Add(user);
    await _context.SaveChangesAsync();
    return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
}
*/