using RestaurantBookingSystem.Data.Repos;
using RestaurantBookingSystem.Data.Repos.IRepos;
using RestaurantBookingSystem.Models;
using RestaurantBookingSystem.Models.DTOs;
using RestaurantBookingSystem.Models.ViewModels.Customer;
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

        public async Task CreateCustomer(CustomerDTO dto)
        {
            ArgumentNullException.ThrowIfNull(nameof(dto));

            if (await _customersRepo.CustomerEmailExists(dto.Email.ToLower()))
            {
                // Add functionality for returning existing customer instead of throwing error?
                throw new Exception($"Customer with email {dto.Email} already exists");
            };

            // Ensures phone property is always null in database, for consistency. Prevents some being null and some being whitespace.
            if (string.IsNullOrWhiteSpace(dto.Phone))
            {
                dto.Phone = null;
            }

            Customer newCustomer = new()
            {
                Name = dto.Name,
                Email = dto.Email,
                NormalizedEmail = dto.Email.ToLower(),
                Phone = dto.Phone
            };

            await _customersRepo.CreateCustomer(newCustomer);
        }

        //public async Task<bool> CustomerEmailExists(string email)
        //{
        //    return await _customersRepo.CustomerEmailExists(email.ToLower());
        //}

        public async Task DeleteCustomer(int id)
        {
            Customer customer = await _customersRepo.GetCustomerById(id) ?? throw new KeyNotFoundException();

            await _customersRepo.DeleteCustomer(customer);
        }

        public async Task<List<CustomerViewModel>> GetAllCustomers()
        {
            List<Customer> customers = await _customersRepo.GetAllCustomers() ?? throw new InvalidOperationException();

            List<CustomerViewModel> result = customers
                .Select(c => new CustomerViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Email = c.NormalizedEmail,
                    Phone = c.Phone
                })
                .ToList();

            return result;
        }

        public async Task<Customer> GetCustomerByEmail(string email)
        {
            Customer customer = await _customersRepo.GetCustomerByEmail(email.ToLower()) ?? throw new KeyNotFoundException(email.ToLower());

            return customer;
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
                Email = customer.NormalizedEmail,
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
            if (customer.Phone != dto.Phone) customer.Phone = dto.Phone;
            if (customer.Email != dto.Email)
            {
                customer.Email = dto.Email;
                customer.NormalizedEmail = dto.Email.ToLower();
            };


            await _customersRepo.UpdateCustomer(customer);
        }
    }
}
