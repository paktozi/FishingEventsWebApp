using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FishingEvents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Elevation", "FishingType", "LocationImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "250", "Bass,Pike", "https://svetogled.com/wp-content/uploads/2021/05/DSC_0680-800x500.jpg", "Vucha dam" },
                    { 2, "1400", "Bass,Trouth", "https://4u-luxury-villa.com/wp-content/uploads/2022/10/Dospat.jpg", "Dospat dam" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
