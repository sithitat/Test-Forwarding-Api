using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace ForwardingApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ForwardController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public ForwardController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpPost]
        public async Task<IActionResult> ForwardRequest([FromBody] object requestData)
        {
            // Extract necessary data from the incoming request, if needed.

            // Forward the request to the target API.
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("[HTTP-API]", requestData);

            // Handle the response as needed.
            string responseBody = await response.Content.ReadAsStringAsync();

            // Return an appropriate response to the original client.
            return Ok(responseBody);
        }
    }
}
