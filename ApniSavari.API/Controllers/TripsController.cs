using ApniSavari.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApniSavari.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly ITripSearchService _tripSearchService;

        public TripsController(ITripSearchService tripSearchService)
        {
            _tripSearchService = tripSearchService;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchTrips(
       [FromQuery] long fromStopId,
       [FromQuery] long toStopId,
       [FromQuery] DateOnly date)
        {
            var results = await _tripSearchService.SearchTripsAsync(
            fromStopId,
            toStopId,
            date);

            return Ok(results);
        }
    }
}
