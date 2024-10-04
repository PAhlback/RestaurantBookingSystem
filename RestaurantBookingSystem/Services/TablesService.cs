using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using RestaurantBookingSystem.Data.Repos.IRepos;
using RestaurantBookingSystem.Models;
using RestaurantBookingSystem.Models.DTOs;
using RestaurantBookingSystem.Models.ViewModels.Table;
using RestaurantBookingSystem.Services.IServices;
using System.Globalization;

namespace RestaurantBookingSystem.Services
{
    public class TablesService : ITablesService
    {
        readonly ITablesRepo _tableRepo;
        readonly IReservationsRepo _reservationsRepo;

        public TablesService(ITablesRepo repo, IReservationsRepo reservationsRepo)
        {
            _tableRepo = repo;
            _reservationsRepo = reservationsRepo;
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

        // TODO: Might have broken this one.
        public async Task<List<TablesAllViewModel>> GetAvailableTablesBasedOnDateTime(DateTime dateAndTime, int numberOfGuests)
        {
            ArgumentNullException.ThrowIfNull(nameof(dateAndTime));

            // Maybe unnecessary
            if (dateAndTime.Date < DateTime.Now.Date) throw new Exception("Unable to make reservation on past date.");

            List<Table> availableTables = await _tableRepo.GetTablesByNumberOfGuests(dateAndTime, numberOfGuests);

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
            // Contains a check to see if the reservation is booked at the requested time + 2h.
            List<Table> availableTables = await _tableRepo.GetTablesByAvailabilityForReservation(dateAndTime, dateAndTime.AddHours(2), numberOfGuests);

            if (availableTables.Count <= 0) throw new Exception("No tables available for reservation");

            // Returns the first table in the list, since that table should be closest in available seats to that of the number of guests.
            return availableTables.First();
        }

        public async Task UpdateTable(int id, TableDTO dto)
        {
            ArgumentNullException.ThrowIfNull(nameof(dto));

            Table table = await _tableRepo.GetTableById(id) ?? throw new KeyNotFoundException(nameof(dto));

            if (table.TableNumber != dto.TableNumber && dto.TableNumber > 0) table.TableNumber = dto.TableNumber;
            if (table.NumberOfSeats != dto.NumberOfSeats && dto.NumberOfSeats >= 0) table.NumberOfSeats += dto.NumberOfSeats;

            await _tableRepo.UpdateTable(table);
        }

        public async Task<(List<TablesAllViewModel> availableTables, List<string> availableTimeSlots)> 
            UpdatedGetAvailableTablesBasedOnDateTime(DateTime dateAndTime, int numberOfGuests)
        {
            ArgumentNullException.ThrowIfNull(nameof(dateAndTime));

            // Check for past dates
            if (dateAndTime.Date < DateTime.Now.Date)
                throw new Exception("Unable to make reservation on past date.");

            // Get available tables based on the number of guests. Include the reservations for the tables.
            List<Table> availableTables = await _tableRepo.GetTablesByNumberOfGuests(dateAndTime, numberOfGuests);

            // Calculate available time slots
            List<string> availableTimeSlots = new List<string>();
            var timeSlots = GenerateTimeSlots(dateAndTime);

            foreach (var table in availableTables)
            {
                foreach (var slot in timeSlots)
                {
                    if (await CheckTimeSlotAvailability(table, slot))
                    {
                        // Check if the time slot is already in the list before adding
                        if (!availableTimeSlots.Contains(slot))
                        {
                            availableTimeSlots.Add(slot);
                        }
                    }
                }
            }

            List<TablesAllViewModel> result = availableTables.Select(t => new TablesAllViewModel
            {
                Id = t.Id,
                TableNumber = t.TableNumber,
                NumberOfSeats = t.NumberOfSeats,
                AvailableTimeSlots = availableTimeSlots
            }).ToList();

            availableTimeSlots.Sort();

            return (result, availableTimeSlots);
        }

        private List<string> GenerateTimeSlots(DateTime dateAndTime)
        {
            List<string> timeSlots = new List<string>();

            // Define opening and closing times here. Could also be parameters, so it's possible to have different
            // opening and closing times for different days.
            TimeSpan openingTime = new TimeSpan(16, 0, 0);
            TimeSpan closingTime = new TimeSpan(23, 45, 0);
            TimeSpan interval = TimeSpan.FromMinutes(15); // 15-minute intervals

            DateTime currentSlot = dateAndTime.Date.Add(openingTime);

            while (currentSlot.TimeOfDay <= closingTime.Subtract(new TimeSpan(1, 0, 0)))
            {
                timeSlots.Add(currentSlot.ToString("HH:mm")); // 24-hour format
                currentSlot = currentSlot.Add(interval);
            }

            return timeSlots;
        }

        private async Task<bool> CheckTimeSlotAvailability(Table table, string timeSlot)
        {
            TimeOnly startTime = TimeOnly.ParseExact(timeSlot, "HH:mm", CultureInfo.InvariantCulture);
            TimeOnly endTime = startTime.AddHours(2);

            foreach (var reservation in table.Reservations)
            {
                // If the requested time is not available for booking, return false. Else move on to next table.
                if (TimeOnly.FromTimeSpan(reservation.DateAndTime.TimeOfDay) < endTime 
                    && TimeOnly.FromTimeSpan(reservation.DateAndTime.AddHours(2).TimeOfDay) > startTime)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
