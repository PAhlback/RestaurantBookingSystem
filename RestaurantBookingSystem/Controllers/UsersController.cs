using Microsoft.AspNetCore.Mvc;
using RestaurantBookingSystem.Models.DTOs.Users;
using RestaurantBookingSystem.Services.IServices;

namespace RestaurantBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserServices userService) : ControllerBase
    {
        private readonly IUserServices _userService = userService;

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserDTO dto)
        {
            try
            {
                await _userService.RegisterUser(dto);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginDTO loginDTO)
        {
            try
            {
                await _userService.LoginUser(loginDTO);

                return Ok("Login successful");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> LogoutUser()
        {
            await _userService.LogoutUser();

            return Ok();
        }
    }
}
