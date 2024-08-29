using RestaurantBookingSystem.Data.Repos.IRepos;
using RestaurantBookingSystem.Models;
using RestaurantBookingSystem.Models.DTOs;
using RestaurantBookingSystem.Services.IServices;

namespace RestaurantBookingSystem.Services
{
    public class ReservationsService : IReservationsService
    {
        readonly IReservationsRepo _reservationsRepo;
        readonly ICustomersService _customersService;
        readonly ITablesService _tablesService;

        public ReservationsService(IReservationsRepo repo, ICustomersService customersService, ITablesService ITablesService)
        {
            _reservationsRepo = repo;
            _customersService = customersService;
            _tablesService = ITablesService;
        }

        public async Task CreateReservation(ReservationDTO dto)
        {
            ArgumentNullException.ThrowIfNull(dto);

            // CUSTOMER
            if (!await _customersService.CustomerEmailExists(dto.CustomerEmail))
            {
                CustomerDTO newCustomer = new CustomerDTO()
                {
                    Name = dto.CustomerName,
                    Email = dto.CustomerEmail,
                    Phone = dto.CustomerPhone
                };

                await _customersService.AddCustomer(newCustomer);
            }

            Customer customer = await _customersService.GetCustomerByEmail(dto.CustomerEmail);
            // ------- END CUSTOMER -------

            // TABLE
            // Have to ensure there is a table with equal to or more number of seats than requested in the booking.
            // To do this check if there are tables with enough seats that do not already have reservations on the requested time + 2h.
            Table table = await _tablesService.ReserveTable(dto.NumberOfGuests, dto.DateAndTime);


            // ------- END TABLE -------

            Reservation newReservation = new Reservation
            {
                NumberOfGuests = dto.NumberOfGuests,
                DateAndTime = dto.DateAndTime,
                FK_CustomerId = customer.Id,
                Customer = customer
            };



        }
    }
}
