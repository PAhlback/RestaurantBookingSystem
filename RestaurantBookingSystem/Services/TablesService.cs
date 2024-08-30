using RestaurantBookingSystem.Data.Repos.IRepos;
using RestaurantBookingSystem.Models;
using RestaurantBookingSystem.Models.DTOs;
using RestaurantBookingSystem.Models.ViewModels;
using RestaurantBookingSystem.Services.IServices;

namespace RestaurantBookingSystem.Services
{
    public class TablesService : ITablesService
    {
        readonly ITablesRepo _tableRepo;

        public TablesService(ITablesRepo repo)
        {
            _tableRepo = repo;
        }

        public async Task AddTable(TableDTO dto)
        {
            ArgumentNullException.ThrowIfNull(nameof(dto));

            if (await _tableRepo.TableNumberExists(dto.TableNumber)) 
            {
                throw new Exception($"Table with table number {dto.TableNumber} already exists");
            };

            Table newTable = new()
            {
                TableNumber = dto.TableNumber,
                NumberOfSeats = dto.NumberOfSeats
            };

            await _tableRepo.AddTable(newTable);
        }

        public async Task DeleteTable(int id)
        {
            Table table = await _tableRepo.GetTableById(id) ?? throw new KeyNotFoundException();

            await _tableRepo.DeleteTable(table);
        }

        public async Task<List<TablesAllViewModel>> GetAllTables()
        {
            List<Table> tables = await _tableRepo.GetAllTables() ?? throw new ArgumentNullException();

            List<TablesAllViewModel> result = tables
                .Select(t => new TablesAllViewModel()
                    {
                        Id = t.Id,
                        NumberOfSeats = t.NumberOfSeats,
                        TableNumber = t.TableNumber
                    })
                .ToList();

            return result;
        }

        public async Task<List<TablesAllViewModel>> GetAvailableTablesBasedOnDateTime(DateTime dateAndTime)
        {
            ArgumentNullException.ThrowIfNull(nameof(dateAndTime));

            // Maybe unnecessary
            if (dateAndTime.Date < DateTime.Now.Date) throw new Exception("Unable to make reservation on past date.");

            List<Table> availableTables = await _tableRepo.GetTablesByDateTime(dateAndTime);

            List<TablesAllViewModel> result = availableTables
                .Select(t => new TablesAllViewModel()
                {
                    Id= t.Id,
                    NumberOfSeats= t.NumberOfSeats,
                    TableNumber = t.TableNumber
                })
                .ToList();

            return result;
        }

        public async Task<TableViewModel> GetTableById(int id)
        {
            Table table = await _tableRepo.GetTableById(id) ?? throw new KeyNotFoundException();

            var reservations = new List<TableReservationViewModel>();

            if (table.Reservations != null)
            {
                reservations = table.Reservations
                    .Select(r => new TableReservationViewModel()
                    {
                        Id = r.Id,
                        CustomerName = r.Customer.Name,
                        CustomerEmail = r.Customer.Email,
                        NumberOfGuests = r.NumberOfGuests,
                        DateAndTime = r.DateAndTime
                    })
                    .ToList();
            }

            TableViewModel result = new TableViewModel() 
            {
                Id = table.Id,
                TableNumber = table.TableNumber,
                NumberOfSeats = table.NumberOfSeats,
                Reservations = reservations
            };

            return result;
        }

        public async Task<Table> ReserveTable(int numberOfGuests, DateTime dateAndTime)
        {
            List<Table> allTables = await _tableRepo.GetAllTables();

            // Contains a check to see if the reservation is booked at the requested time + 2h.
            List<Table> availableTables = allTables
                .Where(t => t.NumberOfSeats >= numberOfGuests 
                    && (t.Reservations == null || !t.Reservations.Any(r => r.DateAndTime == dateAndTime && (double)r.DateAndTime.Hour <= (double)dateAndTime.Hour + 1.99)))
                .OrderBy(t => t.NumberOfSeats)
                .ToList();

            if (availableTables.Count <= 0) throw new Exception("No tables available for reservation");

            return availableTables.First();

            // Returns the first table in the list, since that table should be closest in available seats to that of the number of guests.
        }

        public async Task UpdateTable(int id, TableDTO dto)
        {
            ArgumentNullException.ThrowIfNull(nameof(dto));

            Table table = await _tableRepo.GetTableById(id) ?? throw new KeyNotFoundException(nameof(dto));

            if (table.TableNumber != dto.TableNumber) table.TableNumber = dto.TableNumber;
            if (table.NumberOfSeats != dto.NumberOfSeats) table.NumberOfSeats += dto.NumberOfSeats;

            await _tableRepo.UpdateTable(table);
        }
    }
}
