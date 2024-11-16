using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishingEvents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedGlbalAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Species",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "Name of the species",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "HabitatName",
                table: "Species",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "The habitat name where the species is typically found",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FishImageUrl",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Optional URL of an image representing the species",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FishBait",
                table: "Species",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                comment: "The type of bait typically used to catch this species",
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Species",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                comment: "Description of the species",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Species",
                type: "int",
                nullable: false,
                comment: "Primary key identifier for the species",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Locations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "Name of the location",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "LocationImageUrl",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Optional URL of an image representing the location",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FishingType",
                table: "Locations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "Type of fishing available at this location",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Elevation",
                table: "Locations",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                comment: "Elevation of the location",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Locations",
                type: "int",
                nullable: false,
                comment: "Primary key identifier for the location",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<double>(
                name: "TotalWeight",
                table: "LeaderBoards",
                type: "float",
                nullable: false,
                comment: "Total weight of all fish caught by the user during the event",
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "TotalFishCaught",
                table: "LeaderBoards",
                type: "int",
                nullable: false,
                comment: "Total number of fish caught by the user during the event",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "LeaderBoards",
                type: "nvarchar(450)",
                nullable: false,
                comment: "Foreign key linking to the participating user",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "FishingEventId",
                table: "LeaderBoards",
                type: "int",
                nullable: false,
                comment: "Foreign key linking to the associated FishingEvent",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "FishingEvents",
                type: "datetime2",
                nullable: false,
                comment: "Date and time when the event starts",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "OrganizerId",
                table: "FishingEvents",
                type: "nvarchar(450)",
                nullable: false,
                comment: "Foreign key referencing the Organizer of the event",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Foreign key for the organizer of the event");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "FishingEvents",
                type: "int",
                nullable: false,
                comment: "Foreign key referencing the event location",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "IsCompleted",
                table: "FishingEvents",
                type: "bit",
                nullable: false,
                comment: "Indicates whether the event has been completed",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "EventName",
                table: "FishingEvents",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "Name of the fishing event",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "EventImageUrl",
                table: "FishingEvents",
                type: "nvarchar(max)",
                nullable: true,
                comment: "URL of an image representing the event (optional)",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "FishingEvents",
                type: "datetime2",
                nullable: false,
                comment: "Date and time when the event ends",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "FishingEvents",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                comment: "Description of the fishing event",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "FishingEvents",
                type: "int",
                nullable: false,
                comment: "Primary key identifier for the FishingEvent",
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "FishCaughts",
                type: "float",
                nullable: false,
                comment: "Weight of the fish caught in the specified measurement unit",
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "FishCaughts",
                type: "nvarchar(450)",
                nullable: false,
                comment: "Foreign key referencing the User who caught the fish",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "SpeciesId",
                table: "FishCaughts",
                type: "int",
                nullable: false,
                comment: "Foreign key referencing the Species of the fish caught",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "Length",
                table: "FishCaughts",
                type: "float",
                nullable: false,
                comment: "Length of the fish caught in the specified measurement unit",
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "FishingEventId",
                table: "FishCaughts",
                type: "int",
                nullable: false,
                comment: "Foreign key referencing the associated FishingEvent",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCaught",
                table: "FishCaughts",
                type: "datetime2",
                nullable: false,
                comment: "Date and time when the fish was caught",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CaughtImageUrl",
                table: "FishCaughts",
                type: "nvarchar(max)",
                nullable: true,
                comment: "URL of the image showing the caught fish (optional)",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "FishCaughts",
                type: "int",
                nullable: false,
                comment: "Primary key identifier for FishCaught entry",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "FishCaught identifier")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "EventParticipants",
                type: "nvarchar(450)",
                nullable: false,
                comment: "Foreign key referencing the participating user",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "FishingEventId",
                table: "EventParticipants",
                type: "int",
                nullable: false,
                comment: "Foreign key referencing the associated FishingEvent",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "User's last name",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "User's first name",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d1d7ca33-a54c-4ea0-b96e-6ca509a57ec1", null, "GlobalAdmin", "GLOBALADMIN" });

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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f0c1090f-ba41-4420-8446-26f4efb810f1", 0, "5933bae7-b724-4c98-bc23-88ac548df81d", "globaladmin@abv.bg", true, "Global", "User", false, null, "GLOBALADMIN@ABV.BG", "GLOBALADMIN@ABV.BG", "AQAAAAIAAYagAAAAEOcSrDmhuzXTYbDLk9z3OJuHgX34RHc2BNdmKtdRs2IMDvCObkHRV6C3msBe2goFtw==", null, false, "702776d7-bff4-49b3-9727-a500155b6707", false, "globaladmin@abv.bg" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d1d7ca33-a54c-4ea0-b96e-6ca509a57ec1", "f0c1090f-ba41-4420-8446-26f4efb810f1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d1d7ca33-a54c-4ea0-b96e-6ca509a57ec1", "f0c1090f-ba41-4420-8446-26f4efb810f1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1d7ca33-a54c-4ea0-b96e-6ca509a57ec1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f0c1090f-ba41-4420-8446-26f4efb810f1");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Species",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Name of the species");

            migrationBuilder.AlterColumn<string>(
                name: "HabitatName",
                table: "Species",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "The habitat name where the species is typically found");

            migrationBuilder.AlterColumn<string>(
                name: "FishImageUrl",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Optional URL of an image representing the species");

            migrationBuilder.AlterColumn<string>(
                name: "FishBait",
                table: "Species",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60,
                oldComment: "The type of bait typically used to catch this species");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Species",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldComment: "Description of the species");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Species",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Primary key identifier for the species")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Locations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Name of the location");

            migrationBuilder.AlterColumn<string>(
                name: "LocationImageUrl",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Optional URL of an image representing the location");

            migrationBuilder.AlterColumn<string>(
                name: "FishingType",
                table: "Locations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Type of fishing available at this location");

            migrationBuilder.AlterColumn<string>(
                name: "Elevation",
                table: "Locations",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldComment: "Elevation of the location");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Locations",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Primary key identifier for the location")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<double>(
                name: "TotalWeight",
                table: "LeaderBoards",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldComment: "Total weight of all fish caught by the user during the event");

            migrationBuilder.AlterColumn<int>(
                name: "TotalFishCaught",
                table: "LeaderBoards",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Total number of fish caught by the user during the event");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "LeaderBoards",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Foreign key linking to the participating user");

            migrationBuilder.AlterColumn<int>(
                name: "FishingEventId",
                table: "LeaderBoards",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Foreign key linking to the associated FishingEvent");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "FishingEvents",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date and time when the event starts");

            migrationBuilder.AlterColumn<string>(
                name: "OrganizerId",
                table: "FishingEvents",
                type: "nvarchar(450)",
                nullable: false,
                comment: "Foreign key for the organizer of the event",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Foreign key referencing the Organizer of the event");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "FishingEvents",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Foreign key referencing the event location");

            migrationBuilder.AlterColumn<bool>(
                name: "IsCompleted",
                table: "FishingEvents",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Indicates whether the event has been completed");

            migrationBuilder.AlterColumn<string>(
                name: "EventName",
                table: "FishingEvents",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Name of the fishing event");

            migrationBuilder.AlterColumn<string>(
                name: "EventImageUrl",
                table: "FishingEvents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "URL of an image representing the event (optional)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "FishingEvents",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date and time when the event ends");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "FishingEvents",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldComment: "Description of the fishing event");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "FishingEvents",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Primary key identifier for the FishingEvent")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "FishCaughts",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldComment: "Weight of the fish caught in the specified measurement unit");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "FishCaughts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Foreign key referencing the User who caught the fish");

            migrationBuilder.AlterColumn<int>(
                name: "SpeciesId",
                table: "FishCaughts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Foreign key referencing the Species of the fish caught");

            migrationBuilder.AlterColumn<double>(
                name: "Length",
                table: "FishCaughts",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float",
                oldComment: "Length of the fish caught in the specified measurement unit");

            migrationBuilder.AlterColumn<int>(
                name: "FishingEventId",
                table: "FishCaughts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Foreign key referencing the associated FishingEvent");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCaught",
                table: "FishCaughts",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Date and time when the fish was caught");

            migrationBuilder.AlterColumn<string>(
                name: "CaughtImageUrl",
                table: "FishCaughts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "URL of the image showing the caught fish (optional)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "FishCaughts",
                type: "int",
                nullable: false,
                comment: "FishCaught identifier",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Primary key identifier for FishCaught entry")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "EventParticipants",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Foreign key referencing the participating user");

            migrationBuilder.AlterColumn<int>(
                name: "FishingEventId",
                table: "EventParticipants",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Foreign key referencing the associated FishingEvent");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "User's last name");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "User's first name");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2eff85cf-8402-45f8-bb3b-88bbafcc50d2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4aca01ef-0489-4624-a5ce-f385b9899355", "AQAAAAIAAYagAAAAEPw/tOUSBVKYi3OMlRGpjc4AsNkvp7dtmlPJoUgYUNqllYgak3F4Dvz3jB2JgFPP3A==", "20bd82f2-9239-4f48-9aac-0108710b8802" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5667e464-5a99-44f1-81cd-6e9022965a07",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c89e7fc-058a-490c-b115-dbe235450f16", "AQAAAAIAAYagAAAAECoak0V1x2aBwrcCTiJD7jTGPcU9wExbes4fD/5g6b52imvylvJ8KBAHnxW8P/UU2g==", "45af59a8-789f-4042-a3d2-3d932b2d4220" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8c148075-961f-4ddc-bdb2-416c5bfa1439",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e1487a63-7cec-4b67-9d9b-7f7908bcba4b", "AQAAAAIAAYagAAAAEF+A2b7vRNMjksFGD7jRaa5DEkZj/5nZH/Zv8GBU5tZHnMzt6kJSCFMWmW7/WJUaXg==", "06ddb7a4-4e0c-44bb-9c53-e36ff9e79f64" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef082de5-9f29-4f11-adb4-a337f90e3373",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4bffe47d-7069-4fc5-9019-0c176797188b", "AQAAAAIAAYagAAAAEFLcdtG1NAwQKzatH6jmi+YUBOrKB+0Wtj3A6aaPSMNIkQ2X3KnGitsjgawR7qQQZQ==", "42e0603f-6863-42a1-9f78-1ca3ecd430fd" });
        }
    }
}
