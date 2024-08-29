using RestaurantBookingSystem.Models;

namespace RestaurantBookingSystem.Data.Repos.IRepos
{
    public interface IReservationsRepo
    {
        Task CreateReservation(Reservation newReservation);
        Task<List<Reservation>> GetAllReservations();
        Task<Reservation> GetById(int id);
    }
}
