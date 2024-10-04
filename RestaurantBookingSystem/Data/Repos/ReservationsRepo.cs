using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestaurantBookingSystem.Data.Repos.IRepos;
using RestaurantBookingSystem.Models;
using System.ComponentModel;

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
                .OrderBy(r => r.DateAndTime)
                .ToListAsync();
        }

        public async Task<Reservation> GetById(int id)
        {
            return await _context.Reservations
                .Include(r => r.Table)
                .Include(r => r.Customer)
                .SingleOrDefaultAsync(r => r.Id == id);
        }

        // Unnecessary method? Was used in the time slot generation methods in TableService.
        public async Task<List<Reservation>> GetReservationTimeSlots(int tableId, DateTime startDateTime, DateTime endDateTime)
        {
            var reservations = await _context.Reservations
                .Where(r => r.FK_TableId == tableId &&
                            r.DateAndTime < endDateTime &&
                            r.DateAndTime.AddHours(2) > startDateTime)
                .ToListAsync();

            return reservations;
        }

        public async Task UpdateReservation(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
        }
    }
}
