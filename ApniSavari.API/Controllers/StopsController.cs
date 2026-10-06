using ApniSavari.Application.DTOs;
using ApniSavari.Application.Interfaces;
using ApniSavari.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApniSavari.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StopsController : ControllerBase
    {
        private readonly IStopService _stopService;
        public StopsController(IStopService stopService)
        {
            _stopService = stopService;
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<StopSearchResponseDto>>> Search([FromQuery] string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return BadRequest(new
                {
                    message = "Search query is required."
                });
            }

            var results = await _stopService.SearchStopsAsync(query);

            return Ok(results);
        }
    }
}
