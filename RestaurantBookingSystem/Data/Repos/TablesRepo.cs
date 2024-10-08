﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using RestaurantBookingSystem.Data.Repos.IRepos;
using RestaurantBookingSystem.Models;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;

namespace RestaurantBookingSystem.Data.Repos
{
    public class TablesRepo : ITablesRepo
    {
        readonly ApplicationDbContext _context;

        public TablesRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddTable(Table newTable)
        {
            await _context.Tables.AddAsync(newTable);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTable(Table table)
        {
            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Table>> GetAllTables()
        {
            return await _context.Tables.Include(t => t.Reservations).ToListAsync();
        }
        public async Task<Table> GetTableById(int id)
        {
            return await _context.Tables.Include(t => t.Reservations).ThenInclude(r => r.Customer).SingleOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<Table>> GetTablesByAvailabilityForReservation(DateTime dateAndTime, DateTime endDateAndTime, int numberOfGuests)
        {
            return await _context.Tables
                .Include(t => t.Reservations)
                .Where(t => t.NumberOfSeats >= numberOfGuests
                    && (t.Reservations == null || !t.Reservations.Any(r =>
                    r.DateAndTime < endDateAndTime && r.DateAndTime.AddHours(2) > dateAndTime)))
                .OrderBy(t => t.NumberOfSeats)
                .ToListAsync();
        }

        public async Task<List<Table>> GetTablesByNumberOfGuests(DateTime dateAndTime, int numberOfGuests)
        {
            List<Table> tables = await _context.Tables
                .Include(t => t.Reservations
                    .Where(r => DateOnly.FromDateTime(r.DateAndTime) == DateOnly.FromDateTime(dateAndTime)))
                .Where(t => t.NumberOfSeats >= numberOfGuests)
                .ToListAsync();

            return tables;
        }

        public async Task<bool> TableNumberExists(int tableNumber)
        {
            return await _context.Tables.AnyAsync(t => t.TableNumber == tableNumber);
        }

        public async Task UpdateTable(Table table)
        {
            _context.Tables.Update(table);
            await _context.SaveChangesAsync();
        }
    }
}
