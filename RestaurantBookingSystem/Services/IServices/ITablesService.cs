using RestaurantBookingSystem.Models.DTOs;
using RestaurantBookingSystem.Models.ViewModels;

namespace RestaurantBookingSystem.Services.IServices
{
    public interface ITablesService
    {
        Task AddTable(TableDTO dto);
        Task DeleteTable(int id);
        Task<List<TablesAllViewModel>> GetAllTables();
        Task<TableViewModel> GetTableById(int id);
        Task UpdateTable(int id, TableDTO dto);
    }
}
