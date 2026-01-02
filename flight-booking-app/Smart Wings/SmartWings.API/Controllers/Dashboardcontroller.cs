using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartWings.Application.Contracts;
using SmartWings.Application.DTO;

namespace SmartWings.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IAdminDashboardService _contract;

        public DashboardController(IAdminDashboardService contract)
        {
            _contract = contract;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("revenue/{aircraftModel}")]
        public IActionResult GetRevenueByAircraftModel(string aircraftModel)
        {
            var revenue = _contract.GetTotalRevenueByAircraftModel(aircraftModel);
            return Ok(revenue);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("bookings/{flightNumber}")]
        public async Task<IActionResult> GetBookingsByFlightNumberAndDepartureDate(
            string flightNumber, [FromQuery] DateTime? departureDate)
        {
            var result = await _contract.GetBookingsByFlightNumberAndDepartureDateAsync(
                flightNumber, departureDate);

            if (result == null || !result.Any())
                return NotFound("No bookings found for the given criteria.");

            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("upcoming-flights")]
        public async Task<ActionResult<IEnumerable<UpcomingFlightDto>>> GetUpcomingFlights([FromQuery] DateTime? fromDate)
        {
            var flights = await _contract.GetUpcomingFlightsAsync(fromDate);
            // Always return 200 OK with an array (even if empty)
            return Ok(flights ?? Enumerable.Empty<UpcomingFlightDto>());
        }
    }
}
