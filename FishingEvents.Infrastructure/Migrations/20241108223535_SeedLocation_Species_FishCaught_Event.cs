using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishingEvents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedLocation_Species_FishCaught_Event : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2eff85cf-8402-45f8-bb3b-88bbafcc50d2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd9250b1-c6a0-4663-bf1b-4c6e327f91a8", "AQAAAAIAAYagAAAAELuxw/sXfVd2ZvA3gkAifwr7Ef0bzTrOedY+0P4G9DKZBXBxBPmPBfriFdoMb4DRnQ==", "06549f83-4297-482c-ac0d-7898e0bb2e85" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5667e464-5a99-44f1-81cd-6e9022965a07",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3fd6ff4-2bea-438d-b5b2-b3292d33cc35", "AQAAAAIAAYagAAAAEFbMAZ3LIXo3+eK/0rVAhYO7pwF0GWCPDLCpmIBZ999uOFLveDaej364ugAHCx4qBw==", "7815fa78-dfc6-4350-bc02-1ea0866bd733" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8c148075-961f-4ddc-bdb2-416c5bfa1439",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b868028-8a18-4d6f-8fb2-e760a8a4bf7b", "AQAAAAIAAYagAAAAEAPZWFb18CvMVewX2bxmrvm7ZdtL17DsMOJ35DJGRRx/2LlmycYMaXc9vKS1tERljg==", "8d7076eb-ff79-4c69-8a89-c38f0f4fbe0a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef082de5-9f29-4f11-adb4-a337f90e3373",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bac1dd8f-06a2-4b94-ba9e-2b5f44a15e71", "AQAAAAIAAYagAAAAEOzPOHzE4S6NN22IVVVGkUNcU1UMw0ASuUDNJGlGMUGLNJYgSBjMhMC+Cd2jbQW7/w==", "fa63a502-12cb-4c25-8eb6-42146d0f283c" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Elevation", "FishingType", "LocationImageUrl", "Name" },
                values: new object[] { 8, "2", "Live bait", "https://photos.smugmug.com/Aerials/Massachusetts/Gloucester-MA-aerial-photos/i-z7TrSmq/2/LDpDV5CVDMk29PnCDcbvDK6PsqDJVQwXPwCxvTfGF/L/_MG_9999%20-%20Version%202-L.jpg", "Gloucester,Massachusetts" });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "Description", "FishBait", "FishImageUrl", "HabitatName", "Name" },
                values: new object[] { 9, "Atlantic bluefin tuna have large, torpedo-shaped bodies that are nearly circular in cross-section.", "Live bait", "https://images.squarespace-cdn.com/content/v1/5890c07bcd0f685b13dc60bf/1490802646283-GBTVAD6YM4G07UWVZJ12/image-asset.png", "Near offshore islands", "Atlantic bluefin tuna" });

            migrationBuilder.InsertData(
                table: "FishingEvents",
                columns: new[] { "Id", "Description", "EndDate", "EventImageUrl", "EventName", "IsCompleted", "LocationId", "OrganizerId", "StartDate" },
                values: new object[] { 11, "Join us for Atlantic bluefin tuna!", new DateTime(2024, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://play-lh.googleusercontent.com/TphogImhoiplJ6NBslILTd1eko8KCWb-NDirph-RcoMSiga-v-8YfVZWddAvhLwbVSjBJg", "Wicked Tuna", false, 8, "8c148075-961f-4ddc-bdb2-416c5bfa1439", new DateTime(2024, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "FishCaughts",
                columns: new[] { "Id", "CaughtImageUrl", "DateCaught", "FishingEventId", "Length", "SpeciesId", "UserId", "Weight" },
                values: new object[] { 19, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT_TKag7a673r_RBIcKFqIe-_6BjB6Oob4nqw&s", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 2.25, 9, "ef082de5-9f29-4f11-adb4-a337f90e3373", 350.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FishCaughts",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "FishingEvents",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2eff85cf-8402-45f8-bb3b-88bbafcc50d2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0062f8eb-1091-441c-9bec-2a8ef51ade1a", "AQAAAAIAAYagAAAAEIKywCJwQx9VORwJA6xsKg3HBM3yOY2QhYgjWHEqwrPKHK8W4gi1A10TiSUWiXI42w==", "3d992cab-f469-447d-b0fc-e0036688a8d0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5667e464-5a99-44f1-81cd-6e9022965a07",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a7c45981-50a8-4318-9792-09cb82c6e0f3", "AQAAAAIAAYagAAAAEJZcm8jpXiQRivf+YowGhELRdC6yBxpXlixh4jjGxLcOnGusx/2TswyqMxG0hleLcg==", "2201bf74-8364-4438-a198-0acfc0653774" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8c148075-961f-4ddc-bdb2-416c5bfa1439",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6cbff4de-e52c-409c-a9d6-a01f1b956163", "AQAAAAIAAYagAAAAEOsOjGfxFK4agcYBfldDt7GI5KEWmTwAJOFHlkI+YMvzQEUyxPQ66ZU3OuZXw5z64w==", "ed3add17-2e9a-4d8c-a570-03211f425b40" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef082de5-9f29-4f11-adb4-a337f90e3373",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "00993660-bd12-433e-8834-365847964cd3", "AQAAAAIAAYagAAAAECvn0F1E4pq5YucMUdz57yMFq0aLgXydr632laNkES+o/qcT/pN617hujofq4kx1og==", "7e57743c-3ef4-4e6e-b353-06c0dad3e54b" });
        }
    }
}
