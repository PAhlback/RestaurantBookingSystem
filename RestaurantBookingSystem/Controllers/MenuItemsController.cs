using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantBookingSystem.Models;
using RestaurantBookingSystem.Services.IServices;

namespace RestaurantBookingSystem.Controllers
{
    // Needs CRUD operations.
    // Get all menu items.
    // Get single menu item.
    // Update menu item.
    // Create menu item.
    // Delete menu item.

    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemsController : ControllerBase
    {
        readonly IMenuItemsService _menuItemsService;

        public MenuItemsController(IMenuItemsService service)
        {
            _menuItemsService = service;
        }

        [HttpGet("GetAll")]
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

        [HttpGet("{id}")]
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
    }
}
