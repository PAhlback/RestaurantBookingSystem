using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantBookingSystem.Models.DTOs;
using RestaurantBookingSystem.Models.ViewModels;
using RestaurantBookingSystem.Services.IServices;

namespace RestaurantBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        readonly ITablesService _tablesService;

        public TablesController(ITablesService tablesService)
        {
            _tablesService = tablesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTables()
        {
            try
            {
                List<TablesAllViewModel> tables = await _tablesService.GetAllTables();

                return Ok(tables);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound("No tables found. " + ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTableById([FromRoute] int id)
        {
            try
            {
                TableViewModel result = await _tablesService.GetTableById(id);

                return Ok(result);
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

        [HttpPost()]
        public async Task<IActionResult> AddTable([FromBody] TableDTO dto)
        {
            try
            {
                await _tablesService.AddTable(dto);

                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}/update")]
        public async Task<IActionResult> UpdateTable([FromRoute] int id, [FromBody] TableDTO dto)
        {
            try
            {
                await _tablesService.UpdateTable(id, dto);

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
        public async Task<IActionResult> DeleteTable([FromRoute] int id)
        {
            try
            {
                await _tablesService.DeleteTable(id);

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

        [HttpGet("check-for-available-tables/{dateAndTime}")]
        public async Task<IActionResult> CheckAvailableTablesBasedOnDateTime([FromRoute] DateTime dateAndTime)
        {
            try
            {
                List<TablesAllViewModel> availableTables = await _tablesService.GetAvailableTablesBasedOnDateTime(dateAndTime);

                return Ok(availableTables);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
