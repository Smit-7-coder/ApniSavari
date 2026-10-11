using ApniSavari.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApniSavari.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatLayoutController : ControllerBase
    {
        private readonly ISeatLayoutService _seatLayoutService;

        public SeatLayoutController(ISeatLayoutService seatLayoutService)
        {
            _seatLayoutService = seatLayoutService;
        }

        [HttpGet("{tripId:long}/seat-layout")]
        public async Task<IActionResult> GetSeatLayout(
            [FromRoute] long tripId,
            [FromQuery] long fromStopId,
            [FromQuery] long toStopId,
            CancellationToken cancellationToken)
        {
            if (tripId <= 0 || fromStopId <= 0 || toStopId <= 0)
            {
                return BadRequest(new
                {
                    message = "Trip, boarding stop and dropping stop IDs must be valid."
                });
            }

            if (fromStopId == toStopId)
            {
                return BadRequest(new
                {
                    message = "Boarding and dropping points must be different."
                });
            }

            var result = await _seatLayoutService.GetSeatLayoutAsync(
                tripId,
                fromStopId,
                toStopId,
                cancellationToken);

            if (result == null)
            {
                return NotFound(new
                {
                    message = "The trip, journey segment, or assigned seat layout was not found."
                });
            }

            return Ok(result);
        }
    }
}
