using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FishingEvents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdminAndUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2eff85cf-8402-45f8-bb3b-88bbafcc50d2", 0, "0062f8eb-1091-441c-9bec-2a8ef51ade1a", "admin@abv.bg", true, "Admin", "User", false, null, "ADMIN@ABV.BG", "ADMIN@ABV.BG", "AQAAAAIAAYagAAAAEIKywCJwQx9VORwJA6xsKg3HBM3yOY2QhYgjWHEqwrPKHK8W4gi1A10TiSUWiXI42w==", null, false, "3d992cab-f469-447d-b0fc-e0036688a8d0", false, "admin@abv.bg" },
                    { "5667e464-5a99-44f1-81cd-6e9022965a07", 0, "a7c45981-50a8-4318-9792-09cb82c6e0f3", "user3@abv.bg", true, "TJ", "Ott", false, null, "USER3@ABV.BG", "USER3@ABV.BG", "AQAAAAIAAYagAAAAEJZcm8jpXiQRivf+YowGhELRdC6yBxpXlixh4jjGxLcOnGusx/2TswyqMxG0hleLcg==", null, false, "2201bf74-8364-4438-a198-0acfc0653774", false, "user3@abv.bg" },
                    { "8c148075-961f-4ddc-bdb2-416c5bfa1439", 0, "6cbff4de-e52c-409c-a9d6-a01f1b956163", "user1@abv.bg", true, "Dave", "Marciano", false, null, "USER1@ABV.BG", "USER1@ABV.BG", "AQAAAAIAAYagAAAAEOsOjGfxFK4agcYBfldDt7GI5KEWmTwAJOFHlkI+YMvzQEUyxPQ66ZU3OuZXw5z64w==", null, false, "ed3add17-2e9a-4d8c-a570-03211f425b40", false, "user1@abv.bg" },
                    { "ef082de5-9f29-4f11-adb4-a337f90e3373", 0, "00993660-bd12-433e-8834-365847964cd3", "user2@abv.bg", true, "Tyler", "McLaughlin", false, null, "USER2@ABV.BG", "USER2@ABV.BG", "AQAAAAIAAYagAAAAECvn0F1E4pq5YucMUdz57yMFq0aLgXydr632laNkES+o/qcT/pN617hujofq4kx1og==", null, false, "7e57743c-3ef4-4e6e-b353-06c0dad3e54b", false, "user2@abv.bg" }
                });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Mihalkovo");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Dospat");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2eff85cf-8402-45f8-bb3b-88bbafcc50d2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5667e464-5a99-44f1-81cd-6e9022965a07");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8c148075-961f-4ddc-bdb2-416c5bfa1439");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef082de5-9f29-4f11-adb4-a337f90e3373");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Vucha dam");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Dospat dam");
        }
    }
}
