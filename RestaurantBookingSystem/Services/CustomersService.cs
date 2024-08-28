using RestaurantBookingSystem.Data.Repos;
using RestaurantBookingSystem.Data.Repos.IRepos;
using RestaurantBookingSystem.Models;
using RestaurantBookingSystem.Models.DTOs;
using RestaurantBookingSystem.Models.ViewModels;
using RestaurantBookingSystem.Services.IServices;

namespace RestaurantBookingSystem.Services
{
    public class CustomersService : ICustomersService
    {
        readonly ICustomersRepo _customersRepo;

        public CustomersService(ICustomersRepo repo)
        {
            _customersRepo = repo;
        }

        public async Task AddCustomer(CustomerDTO dto)
        {
            ArgumentNullException.ThrowIfNull(nameof(dto));

            if (await _customersRepo.CustomerEmailExists(dto.Email))
            {
                // Add functionality for returning existing customer instead of throwing error?
                throw new Exception($"Customer with email {dto.Email} already exists");
            };

            Customer newCustomer = new()
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone
            };

            await _customersRepo.AddCustomer(newCustomer);
        }

        public async Task DeleteCustomer(int id)
        {
            Customer customer = await _customersRepo.GetCustomerById(id) ?? throw new KeyNotFoundException();

            await _customersRepo.DeleteCustomer(customer);
        }

        public async Task<List<CustomerViewModel>> GetAllCustomers()
        {
            List<Customer> customers = await _customersRepo.GetAllCustomers() ?? throw new ArgumentNullException();

            List<CustomerViewModel> result = customers
                .Select(t => new CustomerViewModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                    Email = t.Email,
                    Phone = t.Phone
                })
                .ToList();

            return result;
        }

        public async Task<CustomerWithReservationsViewModel> GetCustomerById(int id)
        {
            Customer customer = await _customersRepo.GetCustomerById(id) ?? throw new KeyNotFoundException();

            var reservations = new List<CustomerReservationViewModel>();

            if (customer.Reservations != null)
            {
                reservations = customer.Reservations
                    .Select(r => new CustomerReservationViewModel()
                    {
                        Id = r.Id,
                        NumberOfGuests = r.NumberOfGuests,
                        DateAndTime = r.DateAndTime
                    })
                    .ToList();
            }

            CustomerWithReservationsViewModel result = new CustomerWithReservationsViewModel()
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone,
                Reservations = reservations
            };

            return result;
        }

        public async Task UpdateCustomer(int id, CustomerDTO dto)
        {
            ArgumentNullException.ThrowIfNull(nameof(dto));

            Customer customer = await _customersRepo.GetCustomerById(id) ?? throw new KeyNotFoundException(nameof(dto));

            if (customer.Name != dto.Name) customer.Name = dto.Name;
            if (customer.Email != dto.Email) customer.Email = dto.Email;
            if (customer.Phone != dto.Phone) customer.Phone = dto.Phone;

            await _customersRepo.UpdateCustomer(customer);
        }
    }
}
