using RestaurantBookingSystem.Data.Repos.IRepos;
using RestaurantBookingSystem.Models;
using RestaurantBookingSystem.Models.DTOs;
using RestaurantBookingSystem.Models.ViewModels;
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
            if (dto.NumberOfGuests > 8) throw new ArgumentException("Please contact the restaurant via phone when total number of guests exceed 8");

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
            // To do this, check if there are tables with enough seats that do not already have reservations on the requested time + 2h.
            Table table = await _tablesService.ReserveTable(dto.NumberOfGuests, dto.DateAndTime);
            // ------- END TABLE -------

            Reservation newReservation = new Reservation
            {
                NumberOfGuests = dto.NumberOfGuests,
                DateAndTime = dto.DateAndTime,
                FK_CustomerId = customer.Id,
                Customer = customer,
                FK_TableId = table.Id,
                Table = table
            };

            await _reservationsRepo.CreateReservation(newReservation);
        }

        public async Task<List<ReservationAllViewModel>> GetAllReservations()
        {
            List<Reservation> reservations = await _reservationsRepo.GetAllReservations();

            List<ReservationAllViewModel> result = reservations
                .Select(r => new ReservationAllViewModel()
                {
                    Id = r.Id,
                    NumberOfGuests = r.NumberOfGuests,
                    DateAndTime = r.DateAndTime,
                    Customer = new CustomerViewModel()
                    {
                        Id = r.Customer.Id,
                        Email = r.Customer.Email,
                        Name = r.Customer.Name,
                        Phone = r.Customer.Phone
                    },
                    Table = new TablesAllViewModel()
                    {
                        Id = r.Table.Id,
                        TableNumber = r.Table.TableNumber,
                        NumberOfSeats = r.Table.NumberOfSeats
                    }
                })
                .ToList();
                
            return result;
        }

        public async Task<ReservationAllViewModel> GetById(int id)
        {
            Reservation reservation = await _reservationsRepo.GetById(id);

            ReservationAllViewModel result = new ReservationAllViewModel
            {
                Id = reservation.Id,
                NumberOfGuests = reservation.NumberOfGuests,
                DateAndTime = reservation.DateAndTime,
                Customer = new CustomerViewModel()
                {
                    Id = reservation.Customer.Id,
                    Email = reservation.Customer.Email,
                    Name = reservation.Customer.Name,
                    Phone = reservation.Customer.Phone
                },
                Table = new TablesAllViewModel()
                {
                    Id = reservation.Table.Id,
                    TableNumber = reservation.Table.TableNumber,
                    NumberOfSeats = reservation.Table.NumberOfSeats
                }
            };

            return result;
        }
    }
}
