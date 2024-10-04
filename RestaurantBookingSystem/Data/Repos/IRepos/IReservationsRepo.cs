using RestaurantBookingSystem.Models;

namespace RestaurantBookingSystem.Data.Repos.IRepos
{
    public interface IReservationsRepo
    {
        Task CreateReservation(Reservation newReservation);
        Task DeleteTable(Reservation reservation);
        Task<List<Reservation>> GetAllReservations();
        Task<Reservation> GetById(int id);
        Task<List<Reservation>> GetReservationTimeSlots(int tableId, DateTime startDateTime, DateTime endDateTime);
        Task UpdateReservation(Reservation reservation);
    }
}
