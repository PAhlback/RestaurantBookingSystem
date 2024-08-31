using RestaurantBookingSystem.Data.Repos;
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
        readonly ICustomersRepo _customersRepo;
        readonly ITablesService _tablesService;
        readonly ITablesRepo _tablesRepo;

        public ReservationsService(IReservationsRepo repo, 
            ICustomersService customersService, 
            ITablesService tablesService,
            ITablesRepo tablesRepo,
            ICustomersRepo customersRepo)
        {
            _reservationsRepo = repo;
            _customersService = customersService;
            _tablesService = tablesService;
            _tablesRepo = tablesRepo;
            _customersRepo = customersRepo;
        }

        public async Task CreateReservation(ReservationDTO dto)
        {
            ArgumentNullException.ThrowIfNull(dto);
            if (dto.NumberOfGuests > 6) throw new ArgumentException("Please contact the restaurant directly to make a reservation for more than 6 people.");

            // CUSTOMER
            if (!await _customersRepo.CustomerEmailExists(dto.CustomerEmail.ToLower()))
            {
                CustomerDTO newCustomer = new CustomerDTO()
                {
                    Name = dto.CustomerName,
                    Email = dto.CustomerEmail,
                    Phone = dto.CustomerPhone
                };

                await _customersService.CreateCustomer(newCustomer);
            }

            Customer customer = await _customersService.GetCustomerByEmail(dto.CustomerEmail);
            // ------- END CUSTOMER -------

            // TABLE
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

        public async Task DeleteReservation(int id)
        {
            Reservation reservation = await _reservationsRepo.GetById(id) ?? throw new KeyNotFoundException();

            await _reservationsRepo.DeleteTable(reservation);
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

        // Can update the reservation with new information for the following:
        // Number of guests - will not automatically change table, that has to be done manually. See below.
        // Date and time.
        // Customer - change the customer on the reservation.
        // Table - recieves both table id and table number, since for a reservation to exist it has to have a table.
        // Entering a new table number will change the reservations to that table without checking for existing reservations.
        public async Task UpdateReservation(int id, ReservationUpdateDTO dto)
        {
            ArgumentNullException.ThrowIfNull(nameof(dto));

            if (dto.DateAndTime < DateTime.Now) throw new ArgumentException("Can not make a reservation in the past.");

            Reservation reservation = await _reservationsRepo.GetById(id) ?? throw new KeyNotFoundException(nameof(dto));

            if (reservation.NumberOfGuests != dto.NumberOfGuests) reservation.NumberOfGuests = dto.NumberOfGuests;
            if (reservation.DateAndTime != dto.DateAndTime) reservation.DateAndTime = dto.DateAndTime;

            // If the dto references a different customer than that already in the reservation, the old
            // customer is swapped for the new customer. If the new customer doesn't exist (email is not in db)
            // a new customer is created and then added to the reservation.
            if (reservation.Customer.Email != dto.CustomerEmail)
            {
                Customer? customer = await _customersService.GetCustomerByEmail(dto.CustomerEmail);

                if (customer == null)
                {
                    CustomerDTO customerDTO = new CustomerDTO
                    {
                        Name = dto.CustomerName,
                        Email = dto.CustomerEmail,
                        Phone = dto.CustomerPhone
                    };

                    await _customersService.CreateCustomer(customerDTO);
                    customer = await _customersService.GetCustomerByEmail(dto.CustomerEmail);
                }
                reservation.FK_CustomerId = customer.Id;
                reservation.Customer = customer;
            }

            // Does the same as the block above, but without creating a new table if the table doesn't exist.
            // If the table doesn't exist an error is thrown.
            if (reservation.Table.Id != dto.TableId)
            {
                Table table = await _tablesRepo.GetTableById(dto.TableId);

                reservation.FK_TableId = table.Id;
                reservation.Table = table;
            }
            
            await _reservationsRepo.UpdateReservation(reservation);
        }
    }
}
