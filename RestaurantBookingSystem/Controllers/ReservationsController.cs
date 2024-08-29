using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantBookingSystem.Models;
using RestaurantBookingSystem.Models.DTOs;
using RestaurantBookingSystem.Models.ViewModels;
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
            try
            {
                List<ReservationAllViewModel> reservations = await _reservationsService.GetAllReservations();

                return Ok(reservations);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                ReservationAllViewModel reservation = await _reservationsService.GetById(id);

                return Ok(reservation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("reserve")]
        public async Task<IActionResult> CreateReservation([FromBody] ReservationDTO dto)
        {
            try
            {
                await _reservationsService.CreateReservation(dto);

                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}/update")]
        public async Task<IActionResult> UpdateReservation([FromBody])
        {

        }
    }
}
