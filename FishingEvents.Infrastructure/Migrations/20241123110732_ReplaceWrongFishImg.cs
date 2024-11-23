using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishingEvents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ReplaceWrongFishImg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2eff85cf-8402-45f8-bb3b-88bbafcc50d2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff623c4c-5aae-4ee1-9a51-5de93a329332", "AQAAAAIAAYagAAAAEAtm8Gqa9XVM/KfzCCEup1cIpXsm88h1uyzu4nPJQT+0uNiCF/bbOPeMLgnGPQDdfg==", "abe2b93c-2ff7-4af7-bcf4-c43d03d9fea7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5667e464-5a99-44f1-81cd-6e9022965a07",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea80835c-70b2-4dce-864f-0dc85739dccc", "AQAAAAIAAYagAAAAEMosCPH5qnOx+c9uH+9nEvHZ9nzjuoeiH8pv4SfVbwU0T9Qe8lLGYm5aAqbr0UUEuA==", "8cf77433-4979-45ee-bf05-c22cbc410264" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8c148075-961f-4ddc-bdb2-416c5bfa1439",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7cd607da-ea9b-4f06-acd3-1b3bd2b26c43", "AQAAAAIAAYagAAAAEE3grZUvHWWfjSGkoQ0q1U6EH0O4xal9YULxyP/VmPP6mOqGRDpx0MxFmhiKTYqrQg==", "74521359-6d6e-405d-8a07-e9814eb098eb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a7dded57-50b8-4c59-8148-619b8d2a1266",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d67da72-eb21-4dcc-a725-6e19c1b56a55", "AQAAAAIAAYagAAAAEEeoHc28ZKlIFK85cHO6lMiQa4QX8hfBdKNoErGMRdKP/FqOcJRjLhlw3+opfaVV4Q==", "46d04109-906a-45db-88bb-c7cc930b41c0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e1f8b74c-9b90-4054-ab42-8171c32ed1b2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0042d6d-650d-42f1-a2ea-c4ab8a4cd459", "AQAAAAIAAYagAAAAEBb/NuWFQOiSMUl+6PZfv2wiyPz/a06Yli0ewTtHq942U2JjN88IBkWvoa7rZGrsxg==", "e156f47a-6162-4efd-aa00-9f0e4e27c7ba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef082de5-9f29-4f11-adb4-a337f90e3373",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "06721c84-745f-4a20-968d-74faab7ed380", "AQAAAAIAAYagAAAAEL54/o3WDDWGgPRzpJlYcli7coVTsLKDxTQfGQqS3wIl/7A1Gmy16ycDjSofF/gBSA==", "9fd776de-3c17-4426-b381-71f76b9e0c03" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f0c1090f-ba41-4420-8446-26f4efb810f1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "749c3621-28ac-4293-8247-e93cea7b7fbb", "AQAAAAIAAYagAAAAECI4UtQT7+Vhr/vpB+VP6oOEJeFqbICipiesXMqWEoqOzglXrc5bfB+8cGM5hg0IvA==", "5b553c47-c8bd-4f23-a5d8-110d9d4788bd" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 23, 13, 7, 31, 883, DateTimeKind.Local).AddTicks(3062));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 23, 13, 7, 31, 883, DateTimeKind.Local).AddTicks(3112));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 23, 13, 7, 31, 883, DateTimeKind.Local).AddTicks(3114));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 23, 13, 7, 31, 883, DateTimeKind.Local).AddTicks(3116));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 23, 13, 7, 31, 883, DateTimeKind.Local).AddTicks(3118));

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 2,
                column: "FishImageUrl",
                value: "https://media.istockphoto.com/id/1491004547/vector/watercolor-rainbow-trout-hand-drawn-fish-illustration-isolated-on-white-background.jpg?s=612x612&w=0&k=20&c=HgyqU9_bg_ytNEIiFclu1oNnnoc44PmUc_vvMF4FEbo=");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2eff85cf-8402-45f8-bb3b-88bbafcc50d2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65201613-2f79-4789-99c8-d75bf04c0254", "AQAAAAIAAYagAAAAEDOZM5C3ShQjDDfSwjt+ArFypC9aC6QiLGzHr98pZ3d6AFIcCjJxtzciG/lMER1NnQ==", "238d7913-c878-4089-af34-62479c294b19" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5667e464-5a99-44f1-81cd-6e9022965a07",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6313b7b8-5802-4de1-81da-82c772fbfdaf", "AQAAAAIAAYagAAAAEPwWNd+UpAcYKmc8PUWkb9zdOafskXtAmM4brx23sIiehzryvzpi3W8K/7iFgszl5g==", "1bc6b324-ca48-401f-8ec3-ca0b98d33c19" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8c148075-961f-4ddc-bdb2-416c5bfa1439",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0dfd3fc-a0a6-4d21-a204-2d2844e5a4c9", "AQAAAAIAAYagAAAAECJL8fVb4mlKXIkhAgUogMpcosUcMucEK4ivZwSbPbCPYETTMdej8vnJTZEFAJMDww==", "41818489-5a9b-4b21-995a-8ac327bd0efa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a7dded57-50b8-4c59-8148-619b8d2a1266",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46fb855d-71d7-4168-afbb-9e967e863e68", "AQAAAAIAAYagAAAAEJ1C5yILsbx1k5YNDQSV88gbiD53PKHfvIjF3rbcPb7mS1WHoM0kgBYBGu0vzFS4Tw==", "0ed589a5-c456-4ae6-ad93-796ef96113ef" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e1f8b74c-9b90-4054-ab42-8171c32ed1b2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4199ca08-f91e-442d-8a0f-e04a19008be5", "AQAAAAIAAYagAAAAEKltUjkUMO2cmMJ619T6pUkyai3yVcKcS3/Qjd8tL5Uu0/vJv2wPoGbBT5zgJ8FT1A==", "81627f61-1f3c-4b84-90ba-40b2f9075340" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef082de5-9f29-4f11-adb4-a337f90e3373",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a7b0674e-666c-4ea1-b34f-794d9f578982", "AQAAAAIAAYagAAAAEGTeY1XBqtz/a2e2gbt4GM4KyIZiMqHKe137AH83dvUgeC5uMx8oQ2awx9YeYBsp6A==", "30ea865a-c85d-4cbe-a7bd-f6ed61e525b1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f0c1090f-ba41-4420-8446-26f4efb810f1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "27792ae2-7890-42f9-8e5a-64d54a1a0d54", "AQAAAAIAAYagAAAAEA6LXE+3+U7nq4Y4BRuCYqB59rOh14dr8ZS9EzNieGpoIdDDF3JMDxnQsTn1h6NNIQ==", "a942e130-0fca-4d66-aa4e-9c3d9ffb9c67" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 23, 13, 0, 28, 307, DateTimeKind.Local).AddTicks(7774));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 23, 13, 0, 28, 307, DateTimeKind.Local).AddTicks(7841));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 23, 13, 0, 28, 307, DateTimeKind.Local).AddTicks(7844));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 23, 13, 0, 28, 307, DateTimeKind.Local).AddTicks(7846));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 11, 23, 13, 0, 28, 307, DateTimeKind.Local).AddTicks(7847));

            migrationBuilder.UpdateData(
                table: "Species",
                keyColumn: "Id",
                keyValue: 2,
                column: "FishImageUrl",
                value: "https://images.squarespace-cdn.com/content/v1/5be9e00d5b409b36bd17e36f/a9b6dce2-17eb-4c9c-9755-78cff2f43c87/Dorado+%28Mahi+Mahi%29+Coryphaena+Hippurus.jpeg");
        }
    }
}
