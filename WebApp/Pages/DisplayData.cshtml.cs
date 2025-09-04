using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class DisplayDataModel : PageModel
    {
        private readonly ILogger<DisplayDataModel> _logger;

        public DisplayDataModel(ILogger<DisplayDataModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogInformation("DisplayData page loaded via GET request.");
        }
    }
}
