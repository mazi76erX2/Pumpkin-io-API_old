using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace PunkApiService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PunkApiController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public PunkApiController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("beer/menu")]
        public async Task<IActionResult> GetBeerMenu()
        {
            var response = await _httpClient.GetAsync("beers");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return Ok(content);
        }

        [HttpGet("beer/{id}")]
        public async Task<IActionResult> GetBeerById(int id)
        {
            var response = await _httpClient.GetAsync($"beers/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return Ok(content);
        }

        [HttpGet("beer/random")]
        public async Task<IActionResult> GetRandomBeer()
        {
            var response = await _httpClient.GetAsync("beers/random");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return Ok(content);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchBeer(string query)
        {
            var response = await _httpClient.GetAsync($"beers?beer_name={query}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return Ok(content);
        }
    }
}
