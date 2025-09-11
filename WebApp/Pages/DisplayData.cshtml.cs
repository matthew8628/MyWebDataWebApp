// Page model
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using System.Security.Cryptography.X509Certificates;
using Models;
using System.Text.Json;

namespace WebApp.Pages
{
    public class DisplayDataModel : PageModel
    {
        private readonly ILogger<DisplayDataModel>? _logger;

        private readonly HttpClient _httpClient;

        public DisplayDataModel(HttpClient httpClient)
        {
           _httpClient = httpClient;
        }


        public IActionResult OnPostSave() 
        {
            return RedirectToPage("/Index");
        }


        public List<User> Users { get; set; } = new();

        public async Task OnGetAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7050/UserAPI");

            var json = await response.Content.ReadAsStringAsync();

            Users = JsonSerializer.Deserialize<List<User>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new();
        }
    }
}