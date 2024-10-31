using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FishingEvents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FishingEvents",
                columns: new[] { "Id", "Description", "EndDate", "EventImageUrl", "EventName", "IsCompleted", "LocationId", "OrganizerId", "StartDate" },
                values: new object[,]
                {
                    { 1, "Join us for a day of fishing and fun!", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://baileysharbor.com/wp-content/uploads/2023/03/BH-Brown-Trout-23-Logo-1.jpg", "Spring Fishing Festival", false, 1, "f22d4414-0146-4947-8aa8-4b5179bc0160", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Join us for a cold day of fishing and fun!", new DateTime(2024, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://img.freepik.com/premium-vector/fishing-tournament-logo-template-isolated_384468-27.jpg", "Winter Fishing Festival", false, 2, "f22d4414-0146-4947-8aa8-4b5179bc0160", new DateTime(2024, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FishingEvents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FishingEvents",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
