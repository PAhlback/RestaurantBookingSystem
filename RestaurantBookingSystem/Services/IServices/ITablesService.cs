using RestaurantBookingSystem.Models;
using RestaurantBookingSystem.Models.DTOs;
using RestaurantBookingSystem.Models.ViewModels.Table;

namespace RestaurantBookingSystem.Services.IServices
{
    public interface ITablesService
    {
        Task AddTable(TableDTO dto);
        Task DeleteTable(int id);
        Task<List<TablesAllViewModel>> GetAllTables();
        Task<List<TablesAllViewModel>> GetAvailableTablesBasedOnDateTime(DateTime dateAndTime, int numberOfGuests);
        Task<TableViewModel> GetTableById(int id);
        Task<Table> ReserveTable(int numberOfGuests, DateTime dateAndTime);
        Task UpdateTable(int id, TableDTO dto);
        Task<(List<TablesAllViewModel> availableTables, List<string> availableTimeSlots)> UpdatedGetAvailableTablesBasedOnDateTime(DateTime dateAndTime, int numberOfGuests);
    }
}
