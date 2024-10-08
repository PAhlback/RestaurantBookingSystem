﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantBookingSystem.Helpers;
using RestaurantBookingSystem.Models.DTOs;
using RestaurantBookingSystem.Models.ViewModels.Reservation;
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

        [Authorize]
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

        [Authorize]
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

        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] ReservationDTO dto)
        {
            try
            {
                if (dto.UtcTime != null && dto.UtcTime == true) 
                    dto.DateAndTime = DateAndTimeHelper.ToSwedishTime(dto.DateAndTime);

                await _reservationsService.CreateReservation(dto);

                return Created();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservation(int id, [FromBody] ReservationUpdateDTO dto)
        {
            try
            {
                await _reservationsService.UpdateReservation(id, dto);

                return NoContent();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            try
            {
                await _reservationsService.DeleteReservation(id);

                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
