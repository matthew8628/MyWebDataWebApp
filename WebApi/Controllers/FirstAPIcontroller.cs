using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;





namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FirstAPIController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public FirstAPIController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet(Name = "GetData")]
        public async Task<IActionResult> GetData()
        {
            var response = await _httpClient.GetAsync("https://dummyjson.com/docs/users");

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Failed to fetch data.");
            }

            var data = await response.Content.ReadAsStringAsync();
            return Content(data, "application/json");
        }
    }
}
