using RestaurantBookingSystem.Models;

namespace RestaurantBookingSystem.Data.Repos.IRepos
{
    public interface ITablesRepo
    {
        Task<bool> TableNumberExists(int tableNumber);
        Task<List<Table>> GetAllTables();
        Task<Table> GetTableById(int id);
        Task AddTable(Table newTable);
        Task UpdateTable(Table table);
        Task DeleteTable(Table table);
        Task<List<Table>> GetTablesByDateTime(DateTime dateAndTime);
    }
}
