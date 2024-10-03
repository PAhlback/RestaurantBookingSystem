﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantBookingSystem.Data;

#nullable disable

namespace RestaurantBookingSystem.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241001183159_CustomerEmailUniqueIndex")]
    partial class CustomerEmailUniqueIndex
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator().HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("RestaurantBookingSystem.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "pelle@larsson.com",
                            Name = "Pelle Larsson",
                            NormalizedEmail = "pelle@larsson.com"
                        },
                        new
                        {
                            Id = 2,
                            Email = "veragd@gmail.com",
                            Name = "Vera Gunnarsdottir",
                            NormalizedEmail = "veragd@gmail.com"
                        });
                });

            modelBuilder.Entity("RestaurantBookingSystem.Models.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("FK_CategoryId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPopular")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FK_CategoryId");

                    b.ToTable("MenuItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Spaghetti with pancetta, egg, Parmesan, Pecorino, and black pepper.",
                            FK_CategoryId = 2,
                            IsAvailable = true,
                            IsPopular = true,
                            Name = "Pasta Carbonara",
                            Price = 195
                        },
                        new
                        {
                            Id = 2,
                            Description = "Tomato sauce, fresh mozzarella, basil, and extra virgin olive oil.",
                            FK_CategoryId = 1,
                            IsAvailable = true,
                            IsPopular = true,
                            Name = "Margherita",
                            Price = 175
                        },
                        new
                        {
                            Id = 3,
                            Description = "Fresh tomatoes, mozzarella, basil, and extra virgin olive oil.",
                            FK_CategoryId = 3,
                            IsAvailable = true,
                            IsPopular = false,
                            Name = "Caprese Salad",
                            Price = 145
                        },
                        new
                        {
                            Id = 4,
                            Description = "Creamy Arborio rice cooked with saffron, Parmesan, and butter.",
                            FK_CategoryId = 4,
                            IsAvailable = true,
                            IsPopular = false,
                            Name = "Risotto alla Milanese",
                            Price = 215
                        },
                        new
                        {
                            Id = 5,
                            Description = "Toasted bread topped with fresh tomatoes, garlic, basil, and olive oil.",
                            FK_CategoryId = 5,
                            IsAvailable = true,
                            IsPopular = false,
                            Name = "Bruschetta al Pomodoro",
                            Price = 115
                        },
                        new
                        {
                            Id = 6,
                            Description = "Tomato sauce, mozzarella, ham and pineapple.",
                            FK_CategoryId = 1,
                            IsAvailable = true,
                            IsPopular = true,
                            Name = "Hawaii",
                            Price = 190
                        });
                });

            modelBuilder.Entity("RestaurantBookingSystem.Models.MenuItemCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("MenuItemCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Pizza"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Pasta"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Salad"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Primo"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Aperitivo"
                        });
                });

            modelBuilder.Entity("RestaurantBookingSystem.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateAndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("FK_CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("FK_TableId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfGuests")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FK_CustomerId");

                    b.HasIndex("FK_TableId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("RestaurantBookingSystem.Models.Table", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("int");

                    b.Property<int>("TableNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tables");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NumberOfSeats = 6,
                            TableNumber = 1
                        },
                        new
                        {
                            Id = 2,
                            NumberOfSeats = 6,
                            TableNumber = 2
                        },
                        new
                        {
                            Id = 3,
                            NumberOfSeats = 4,
                            TableNumber = 3
                        },
                        new
                        {
                            Id = 4,
                            NumberOfSeats = 4,
                            TableNumber = 4
                        },
                        new
                        {
                            Id = 5,
                            NumberOfSeats = 2,
                            TableNumber = 5
                        },
                        new
                        {
                            Id = 6,
                            NumberOfSeats = 2,
                            TableNumber = 6
                        });
                });

            modelBuilder.Entity("RestaurantBookingSystem.Models.User", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RestaurantBookingSystem.Models.MenuItem", b =>
                {
                    b.HasOne("RestaurantBookingSystem.Models.MenuItemCategory", "Category")
                        .WithMany("MenuItems")
                        .HasForeignKey("FK_CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("RestaurantBookingSystem.Models.Reservation", b =>
                {
                    b.HasOne("RestaurantBookingSystem.Models.Customer", "Customer")
                        .WithMany("Reservations")
                        .HasForeignKey("FK_CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantBookingSystem.Models.Table", "Table")
                        .WithMany("Reservations")
                        .HasForeignKey("FK_TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("RestaurantBookingSystem.Models.Customer", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("RestaurantBookingSystem.Models.MenuItemCategory", b =>
                {
                    b.Navigation("MenuItems");
                });

            modelBuilder.Entity("RestaurantBookingSystem.Models.Table", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
