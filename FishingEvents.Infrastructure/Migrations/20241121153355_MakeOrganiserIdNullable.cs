using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishingEvents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MakeOrganiserIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2eff85cf-8402-45f8-bb3b-88bbafcc50d2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5550a537-bb9e-423e-ad89-13e0e9fdaafd", "AQAAAAIAAYagAAAAEGAnHsF8YQjXeY3FKeVTYvPBXvgF+ydwis6MT33Tgk/MPJDOgIMXGKmkImB+xz0z/w==", "687194d7-6439-4dd2-b9ff-e432cbb7acaa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5667e464-5a99-44f1-81cd-6e9022965a07",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a25e2718-f715-46fd-a8a7-079b80796cc2", "AQAAAAIAAYagAAAAEPm1n5WzhseZs6P6yEakDjWs8166QXnrGfMaOtRNSOMvy+GN2I6CFpima62dqTdk5w==", "1054fcf8-70e4-468a-9b04-f350a87744e8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8c148075-961f-4ddc-bdb2-416c5bfa1439",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "42451c90-2b20-4785-82cc-befaf279b6da", "AQAAAAIAAYagAAAAEL9Hg9VZPlQqjETC0iWKJGzVP1yTYdCzngw6ZhZEalrONGS17xnQweYrBesqBAD5tg==", "1c462df7-50e2-465b-afc2-ba548deacba1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef082de5-9f29-4f11-adb4-a337f90e3373",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a984a4ef-2336-43f7-8815-decdb3b0f43c", "AQAAAAIAAYagAAAAEMW0ZG9F+RCF4FEl/gesu0n8Jq44Fg+Vll6G6aVH8f2o1RJUdV5hnyBOtR66MQ7anw==", "f8485a56-aff3-4bae-814a-dd6855e8ddfe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f0c1090f-ba41-4420-8446-26f4efb810f1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3f9471e6-ffcc-4383-8581-f60d128599dc", "AQAAAAIAAYagAAAAEHwJt406dyd9XLT5k+lDpys/ufoR9ZQOLyCI7SbY1BjRnZ+vA95ShIV0ls65tzq8TA==", "4ea79af7-b3f8-4d98-81eb-19a1776d7386" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2eff85cf-8402-45f8-bb3b-88bbafcc50d2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e587fbf5-5510-4cdc-ae85-5f427a0d95f8", "AQAAAAIAAYagAAAAEHl5qiOQhGeHFIG95hrhBzAGmCiFbbFQy/CxE4XPQ43SuSNxZp89LXMpcz4I/r2Qcw==", "7aa6728b-3cb4-4e64-915b-6a197a63f073" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5667e464-5a99-44f1-81cd-6e9022965a07",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3fccd168-931a-473c-bf3c-8ce00bec6c1f", "AQAAAAIAAYagAAAAEM7PIFWvjHiwOAUd0oHuWTPI0nKTreo8b0JgCgM9JrAh1oJUe+7rCyacAzgWHaVDTg==", "7c2b01b0-df10-4987-8f16-a4c03bdd4ee8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8c148075-961f-4ddc-bdb2-416c5bfa1439",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25d941d0-09c8-4b50-beae-c798f60c0029", "AQAAAAIAAYagAAAAEGgmINrki/fr+OzOpDp+uSyl7oEKc41kOGqQUoDfjTR0cb4nceuoFa7tji7WqgulAQ==", "a5a5fe79-f4c5-4bfc-a89b-aa509502eb0f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef082de5-9f29-4f11-adb4-a337f90e3373",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6fcdd1b-28ba-4fda-a93f-bbf7b6e661cc", "AQAAAAIAAYagAAAAEB5nmST6fqONQ+GQT2gNVCbxLCEumcs1uVzG9rnjcCMInI2q22i7EwXie4P7meGiGA==", "7f857ae7-4181-43b9-9f76-ec76a91bcda5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f0c1090f-ba41-4420-8446-26f4efb810f1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5933bae7-b724-4c98-bc23-88ac548df81d", "AQAAAAIAAYagAAAAEOcSrDmhuzXTYbDLk9z3OJuHgX34RHc2BNdmKtdRs2IMDvCObkHRV6C3msBe2goFtw==", "702776d7-bff4-49b3-9727-a500155b6707" });
        }
    }
}
