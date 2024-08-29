using RestaurantBookingSystem.Models.DTOs;

namespace RestaurantBookingSystem.Services.IServices
{
    public interface IReservationsService
    {
        Task CreateReservation(ReservationDTO dto);
    }
}
