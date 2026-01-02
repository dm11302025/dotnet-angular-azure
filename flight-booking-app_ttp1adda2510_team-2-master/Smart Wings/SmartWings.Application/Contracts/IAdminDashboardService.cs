using SmartWings.Application.DTO;
using Microsoft.EntityFrameworkCore;

namespace SmartWings.Application.Contracts
{
    public interface IAdminDashboardService
    {

        decimal GetTotalRevenueByAircraftModel(string aircraftModel);
        Task<IEnumerable<DashboardBookingDetailsDto>> GetBookingsByFlightNumberAndDepartureDateAsync(string flightNumber, DateTime? departureDate);
        Task<IEnumerable<UpcomingFlightDto>> GetUpcomingFlightsAsync(DateTime? fromDate = null);
    }
}