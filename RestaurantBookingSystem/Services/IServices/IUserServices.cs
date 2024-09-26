using RestaurantBookingSystem.Models.DTOs.Users;

namespace RestaurantBookingSystem.Services.IServices
{
    public interface IUserServices
    {
        Task LoginUser(LoginDTO loginDTO);
        Task LogoutUser();
        Task RegisterUser(UserDTO dto);
    }
}
