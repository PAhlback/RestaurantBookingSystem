using RestaurantBookingSystem.Models;
using RestaurantBookingSystem.Models.DTOs;
using RestaurantBookingSystem.Models.ViewModels;

namespace RestaurantBookingSystem.Services.IServices
{
    public interface IReservationsService
    {
        Task CreateReservation(ReservationDTO dto);
        Task<List<ReservationAllViewModel>> GetAllReservations();
        Task<ReservationAllViewModel> GetById(int id);
    }
}
