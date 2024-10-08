﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantBookingSystem.Models;

namespace RestaurantBookingSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<MenuItemCategory> MenuItemCategories { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Table>().HasData
            (
                new Table { Id = 1, TableNumber = 1, NumberOfSeats = 6 },
                new Table { Id = 2, TableNumber = 2, NumberOfSeats = 6 },
                new Table { Id = 3, TableNumber = 3, NumberOfSeats = 4 },
                new Table { Id = 4, TableNumber = 4, NumberOfSeats = 4 },
                new Table { Id = 5, TableNumber = 5, NumberOfSeats = 2 },
                new Table { Id = 6, TableNumber = 6, NumberOfSeats = 2 }
            );

            modelBuilder.Entity<Customer>().HasData
            (
                new Customer { Id = 1, Name = "Pelle Larsson", Email = "pelle@larsson.com", NormalizedEmail = "pelle@larsson.com", Phone = null },
                new Customer { Id = 2, Name = "Vera Gunnarsdottir", Email = "veragd@gmail.com", NormalizedEmail = "veragd@gmail.com", Phone = null }
            );

            modelBuilder.Entity<MenuItemCategory>().HasData
            (
                new MenuItemCategory { Id = 1, Name = "Pizza" },
                new MenuItemCategory { Id = 2, Name = "Pasta" },
                new MenuItemCategory { Id = 3, Name = "Salad" },
                new MenuItemCategory { Id = 4, Name = "Primo" },
                new MenuItemCategory { Id = 5, Name = "Aperitivo" }
            );

            modelBuilder.Entity<MenuItem>().HasData
            (
                new MenuItem { Id = 1, Name = "Pasta Carbonara", Description = "Spaghetti with pancetta, egg, Parmesan, Pecorino, and black pepper.", Price = 195, IsAvailable = true, FK_CategoryId = 2, IsPopular = true },
                new MenuItem { Id = 2, Name = "Margherita", Description = "Tomato sauce, fresh mozzarella, basil, and extra virgin olive oil.", Price = 175, IsAvailable = true, FK_CategoryId = 1, IsPopular = true },
                new MenuItem { Id = 3, Name = "Caprese Salad", Description = "Fresh tomatoes, mozzarella, basil, and extra virgin olive oil.", Price = 145, IsAvailable = true, FK_CategoryId = 3 },
                new MenuItem { Id = 4, Name = "Risotto alla Milanese", Description = "Creamy Arborio rice cooked with saffron, Parmesan, and butter.", Price = 215, IsAvailable = true, FK_CategoryId = 4 },
                new MenuItem { Id = 5, Name = "Bruschetta al Pomodoro", Description = "Toasted bread topped with fresh tomatoes, garlic, basil, and olive oil.", Price = 115, IsAvailable = true, FK_CategoryId = 5 },
                new MenuItem { Id = 6, Name = "Hawaii", Description = "Tomato sauce, mozzarella, ham and pineapple.", Price = 190, IsAvailable = true, FK_CategoryId = 1, IsPopular = true }
            );
        }
    }
}
