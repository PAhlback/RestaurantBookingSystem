using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantBookingSystem.Models.DTOs;
using RestaurantBookingSystem.Models.ViewModels;
using RestaurantBookingSystem.Services;
using RestaurantBookingSystem.Services.IServices;

namespace RestaurantBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        readonly ICustomersService _customerService;

        public CustomersController(ICustomersService service)
        {
            _customerService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTables()
        {
            try
            {
                List<CustomerViewModel> customers = await _customerService.GetAllCustomers();

                return Ok(customers);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound("No customers found. " + ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            try
            {
                CustomerWithReservationsViewModel customer = await _customerService.GetCustomerById(id);

                return Ok(customer);
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> AddCustomer([FromBody]CustomerDTO dto)
        {
            try
            {
                await _customerService.AddCustomer(dto);

                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}/update")]
        public async Task<IActionResult> UpdateTable(int id, [FromBody]CustomerDTO dto)
        {
            try
            {
                await _customerService.UpdateCustomer(id, dto);

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

        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                await _customerService.DeleteCustomer(id);

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
