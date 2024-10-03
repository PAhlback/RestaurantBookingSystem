using RestaurantBookingSystem.Models.DTOs.Users;

namespace RestaurantBookingSystem.Services.IServices
{
    public interface IUserServices
    {
        Task<UserLoginInfoViewModel> LoginUser(LoginDTO loginDTO);
        Task LogoutUser();
        Task RegisterUser(UserDTO dto);
    }
}
