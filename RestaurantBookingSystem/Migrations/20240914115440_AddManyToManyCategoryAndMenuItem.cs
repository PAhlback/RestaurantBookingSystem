using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddManyToManyCategoryAndMenuItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsPopular",
                value: true);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsPopular",
                value: true);

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Description", "FK_CategoryId", "IsAvailable", "IsPopular", "Name", "Price" },
                values: new object[] { 6, "Tomato sauce, mozzarella, ham and pineapple.", 1, true, true, "Hawaii", 190 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsPopular",
                value: false);

            migrationBuilder.UpdateData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsPopular",
                value: false);
        }
    }
}
