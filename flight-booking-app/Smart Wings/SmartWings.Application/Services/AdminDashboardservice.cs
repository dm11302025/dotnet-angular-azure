using SmartWings.Application.Contracts;
using SmartWings.Application.DTO;
using SmartWings.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartWings.Application.Services
{
    public class AdminDashboardService : IAdminDashboardService
    {
        private readonly IAdminDashboardContract _contract;

        public AdminDashboardService(IAdminDashboardContract contract)
        {
            _contract = contract;
        }

        public decimal GetTotalRevenueByAircraftModel(string aircraftModel)
        {
            return _contract.GetTotalRevenueByAircraftModel(aircraftModel);
        }

        public async Task<IEnumerable<DashboardBookingDetailsDto>> GetBookingsByFlightNumberAndDepartureDateAsync(
            string flightNumber, DateTime? departureDate)
        {
            var bookings = await _contract.GetBookingsByFlightNumberAndDepartureDateAsync(flightNumber, departureDate);

            return bookings.Select(b => new DashboardBookingDetailsDto
            {
                BookingId = b.BookingId,
                FlightId = b.FlightId,
                FlightNumber = b.Flight.FlightNumber,
                Origin = b.Flight.Origin,
                Destination = b.Flight.Destination,
                DepartureTime = b.Flight.DepartureTime,
                BookingDate = b.BookingDate,
                UserId = b.UserId,
                UserName = b.User.UserName,
                Email = b.User.Email,
                Price = b.TotalAmount,

                Passengers = b.Passengers?.Select(p => new PassengerDashboardDto
                {
                    PassengerId = p.PassengerId,
                    FullName = p.FullName,
                    Age = p.Age,
                    Gender = p.Gender,
                    PassportNumber = p.PassportNumber,
                    SeatNumber = p.SeatNumber,
                    SeatClass = p.Seat?.Class
                }).ToList() ?? new List<PassengerDashboardDto>()
            }).ToList();
        }

        public async Task<IEnumerable<UpcomingFlightDto>> GetUpcomingFlightsAsync(DateTime? fromDate = null)
        {
            var flights = await _contract.GetUpcomingFlightsAsync(fromDate ?? DateTime.Now);

            return flights.Select(f => new UpcomingFlightDto
            {
                FlightId = f.FlightId,
                FlightNumber = f.FlightNumber,
                Origin = f.Origin,
                Destination = f.Destination,
                DepartureTime = f.DepartureTime,
                AircraftModel = f.AirCraft.Model,
                AvailableSeats = f.AirCraft.TotalSeats - (f.Bookings?.Sum(b => b.PassengerCount) ?? 0),
                BasePrice = f.PriceEconomy // Or choose business price based on requirement
            }).ToList();
        }

    }
}
