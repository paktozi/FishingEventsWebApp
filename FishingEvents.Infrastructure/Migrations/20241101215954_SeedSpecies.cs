using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FishingEvents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedSpecies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "Description", "FishBait", "FishImageUrl", "HabitatName", "Name" },
                values: new object[,]
                {
                    { 1, "They are generally silvery white in color and most have dark horizontal lines along their sides.", "lures, live bait, spinner baits, jig bait", "https://www.graytaxidermy.com/images/large-fishmount-photos/large-mouth-bass-silo.jpg", "Lakes or shallow bays of larger lakes.", "Bass" },
                    { 2, "Trout have fins entirely without spines, and all of them have a small adipose fin along the back, near the tail.", "lures, live bait, spinner baits, jig bait,camola", "https://images.squarespace-cdn.com/content/v1/5be9e00d5b409b36bd17e36f/a9b6dce2-17eb-4c9c-9755-78cff2f43c87/Dorado+%28Mahi+Mahi%29+Coryphaena+Hippurus.jpeg", "Trout need cold water to survive.", "Trout" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
