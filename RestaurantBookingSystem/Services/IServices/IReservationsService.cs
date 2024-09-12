using RestaurantBookingSystem.Models;
using RestaurantBookingSystem.Models.DTOs;
using RestaurantBookingSystem.Models.ViewModels.Reservation;

namespace RestaurantBookingSystem.Services.IServices
{
    public interface IReservationsService
    {
        Task CreateReservation(ReservationDTO dto);
        Task DeleteReservation(int id);
        Task<List<ReservationAllViewModel>> GetAllReservations();
        Task<ReservationAllViewModel> GetById(int id);
        Task UpdateReservation(int id, ReservationUpdateDTO dto);
    }
}
