using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantBookingSystem.Models.DTOs;
using RestaurantBookingSystem.Services.IServices;

namespace RestaurantBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        readonly IReservationsService _reservationsService;

        public ReservationsController(IReservationsService service)
        {
            _reservationsService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservations()
        {
            return Ok("Not implemented");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok("Not implemented");
        }

        [HttpPost("reserve")]
        public async Task<IActionResult> CreateReservation(ReservationDTO dto)
        {
            try
            {
                await _reservationsService.CreateReservation(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
