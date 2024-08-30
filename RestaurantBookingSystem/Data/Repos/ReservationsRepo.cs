using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestaurantBookingSystem.Data.Repos.IRepos;
using RestaurantBookingSystem.Models;

namespace RestaurantBookingSystem.Data.Repos
{
    public class ReservationsRepo : IReservationsRepo
    {
        readonly ApplicationDbContext _context;

        public ReservationsRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateReservation(Reservation newReservation)
        {
            await _context.Reservations.AddAsync(newReservation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTable(Reservation reservation)
        {
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Reservation>> GetAllReservations()
        {
            return await _context.Reservations
                .Include(r => r.Table)
                .Include(r => r.Customer)
                .ToListAsync();
        }

        public async Task<Reservation> GetById(int id)
        {
            return await _context.Reservations
                .Include(r => r.Table)
                .Include(r => r.Customer)
                .SingleOrDefaultAsync(r => r.Id == id);
        }

        public async Task UpdateReservation(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
        }
    }
}
