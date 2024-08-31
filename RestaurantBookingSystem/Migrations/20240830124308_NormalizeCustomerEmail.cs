using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class NormalizeCustomerEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "pelle@larsson.com", "Pelle Larsson", null },
                    { 2, "veragd@gmail.com", "Vera Gunnarsdottir", null }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Description", "IsAvailable", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Spaghetti with pancetta, egg, Parmesan, Pecorino, and black pepper.", true, "Pasta Carbonara", 195 },
                    { 2, "Tomato sauce, fresh mozzarella, basil, and extra virgin olive oil.", true, "Margherita", 175 },
                    { 3, "Fresh tomatoes, mozzarella, basil, and extra virgin olive oil.", true, "Caprese Salad", 145 },
                    { 4, "Creamy Arborio rice cooked with saffron, Parmesan, and butter.", true, "Risotto alla Milanese", 215 },
                    { 5, "Toasted bread topped with fresh tomatoes, garlic, basil, and olive oil.", true, "Bruschetta al Pomodoro", 115 }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "NumberOfSeats", "TableNumber" },
                values: new object[,]
                {
                    { 1, 6, 1 },
                    { 2, 6, 1 },
                    { 3, 4, 2 },
                    { 4, 4, 3 },
                    { 5, 2, 4 },
                    { 6, 2, 5 }
                });
        }
    }
}
