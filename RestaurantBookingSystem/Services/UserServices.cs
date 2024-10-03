using Microsoft.AspNetCore.Identity;
using RestaurantBookingSystem.Models;
using RestaurantBookingSystem.Models.DTOs.Users;
using RestaurantBookingSystem.Services.IServices;

namespace RestaurantBookingSystem.Services
{
    public class UserServices(UserManager<User> userManager, SignInManager<User> signInManager) : IUserServices
    {
        private readonly UserManager<User> _userManager = userManager;
        private readonly SignInManager<User> _signInManager = signInManager;

        public async Task<UserLoginInfoViewModel> LoginUser(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);

            if (user == null)
            {
                throw new Exception("Invalid email or password");
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginDTO.Password, loginDTO.RememberMe, false);
            if (!result.Succeeded)
            {
                throw new Exception("Login failed at password");
            }

            return new UserLoginInfoViewModel { Email = user.Email, FirstName = user.FirstName, LastName = user.LastName };
        }

        public async Task LogoutUser()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task RegisterUser(UserDTO dto)
        {
            User newUser = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                UserName = dto.UserName,
            };

            var result = await _userManager.CreateAsync(newUser, dto.Password);

            if (!result.Succeeded) throw new Exception("Failed to create user");
        }
    }
}
