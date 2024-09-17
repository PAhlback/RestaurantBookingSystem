using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantBookingSystem.Models;
using RestaurantBookingSystem.Models.DTOs;
using RestaurantBookingSystem.Models.ViewModels.MenuItem;
using RestaurantBookingSystem.Services.IServices;

namespace RestaurantBookingSystem.Controllers
{
    // GO THROUGH THESE FOR ERROR HANDLING
    // Get all menu items.
    // Get single menu item.
    // Create menu item.

    // DONE
    // Update menu item.
    // Delete menu item. Return "No content"?

    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemsController : ControllerBase
    {
        readonly IMenuItemsService _menuItemsService;

        public MenuItemsController(IMenuItemsService service)
        {
            _menuItemsService = service;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllMenuItems()
        {
            try
            {
                ICollection<MenuItemViewModel> menuItems = await _menuItemsService.GetAll();

                return Ok(menuItems);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuItemById(int id)
        {
            try
            {
                MenuItem? menuItem = await _menuItemsService.GetById(id);

                return Ok(menuItem);
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

        [HttpGet("popular")]
        public async Task<IActionResult> GetPopularMenuItems()
        {
            try
            {
                ICollection<MenuItemViewModel> popularItems = await _menuItemsService.GetPopular();

                return Ok(popularItems);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost()]
        public async Task<IActionResult> AddMenuItem([FromBody] MenuItemDTO dto)
        {
            try
            {
                await _menuItemsService.AddMenuItem(dto);

                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenuItem(int id, [FromBody] MenuItemDTO dto)
        {
            try
            {
                await _menuItemsService.UpdateMenuItem(id, dto);

                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                // Add logging for the exception?
                return NotFound($"Failed to locate menu item with id {id}.");
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest("All fields are required.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            try
            {
                await _menuItemsService.DeleteItem(id);

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
