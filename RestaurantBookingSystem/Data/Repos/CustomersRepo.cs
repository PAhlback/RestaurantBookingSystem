using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestaurantBookingSystem.Data.Repos.IRepos;
using RestaurantBookingSystem.Models;

namespace RestaurantBookingSystem.Data.Repos
{
    public class CustomersRepo : ICustomersRepo
    {
        readonly ApplicationDbContext _context;

        public CustomersRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateCustomer(Customer newCustomer)
        {
            await _context.Customers.AddAsync(newCustomer);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CustomerEmailExists(string email)
        {
            return await _context.Customers.AnyAsync(c => c.NormalizedEmail == email);
        }

        public async Task DeleteCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        public Task<Customer> GetCustomerByEmail(string email)
        {
            return _context.Customers.SingleOrDefaultAsync(c => c.NormalizedEmail == email);
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _context.Customers.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }
    }
}
