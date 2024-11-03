using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FishingEvents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedFishCaught : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FishCaughts",
                columns: new[] { "Id", "CaughtImageUrl", "DateCaught", "FishingEventId", "Length", "SpeciesId", "UserId", "Weight" },
                values: new object[,]
                {
                    { 1, "https://targetwalleye.com/wp-content/uploads/2019/11/Jake-Caughey-winnipeg-manitoba-target-walleye-greenback_edited-1.jpg", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0.5, 1, "f22d4414-0146-4947-8aa8-4b5179bc0160", 0.25 },
                    { 2, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQeJp8v1JFGqRH1BLyOwv-48FlCGg4kwxyN-VFvtYnxvUbzVAh_VaTjBjf7xGipUG4K_c4&usqp=CAU", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0.90000000000000002, 2, "f22d4414-0146-4947-8aa8-4b5179bc0160", 1.45 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FishCaughts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FishCaughts",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
