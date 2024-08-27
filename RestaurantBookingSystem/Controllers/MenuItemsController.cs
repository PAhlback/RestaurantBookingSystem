using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantBookingSystem.Models;
using RestaurantBookingSystem.Models.DTOs;
using RestaurantBookingSystem.Services.IServices;

namespace RestaurantBookingSystem.Controllers
{
    // Needs CRUD operations.
    // Get all menu items.
    // Get single menu item.
    // Update menu item.
    // Create menu item.
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

        [HttpGet("Menu")]
        public async Task<IActionResult> GetAllMenuItems()
        {
            try
            {
                List<MenuItem> menuItems = await _menuItemsService.GetAll();

                return Ok(menuItems);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetItem/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                MenuItem? menuItem = await _menuItemsService.GetById(id);

                return Ok(menuItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddItem")]
        public async Task<IActionResult> AddMenuItem(MenuItemDTO dto)
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
    }
}
