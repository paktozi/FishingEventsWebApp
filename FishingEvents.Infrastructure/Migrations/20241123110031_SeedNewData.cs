using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FishingEvents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedNewData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "User's first name"),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "User's last name"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary key identifier for the location")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the location"),
                    Elevation = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Elevation of the location"),
                    FishingType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Type of fishing available at this location"),
                    LocationImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Optional URL of an image representing the location")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary key identifier for the species")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the species"),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, comment: "Description of the species"),
                    HabitatName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "The habitat name where the species is typically found"),
                    FishBait = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false, comment: "The type of bait typically used to catch this species"),
                    FishImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Optional URL of an image representing the species")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FishingEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary key identifier for the FishingEvent")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Name of the fishing event"),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, comment: "Description of the fishing event"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time when the event starts"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time when the event ends"),
                    LocationId = table.Column<int>(type: "int", nullable: false, comment: "Foreign key referencing the event location"),
                    EventImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "URL of an image representing the event (optional)"),
                    OrganizerId = table.Column<string>(type: "nvarchar(450)", nullable: true, comment: "Foreign key referencing the Organizer of the event"),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indicates whether the event has been completed")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FishingEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FishingEvents_AspNetUsers_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FishingEvents_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary key identifier for the Comment")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "The text content of the comment."),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date and time when the comment was created."),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "The unique identifier for the author of the comment."),
                    FishingEventId = table.Column<int>(type: "int", nullable: false, comment: "The unique identifier of the fishing event to which this comment is associated.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_FishingEvents_FishingEventId",
                        column: x => x.FishingEventId,
                        principalTable: "FishingEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventParticipants",
                columns: table => new
                {
                    FishingEventId = table.Column<int>(type: "int", nullable: false, comment: "Foreign key referencing the associated FishingEvent"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Foreign key referencing the participating user")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventParticipants", x => new { x.FishingEventId, x.UserId });
                    table.ForeignKey(
                        name: "FK_EventParticipants_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventParticipants_FishingEvents_FishingEventId",
                        column: x => x.FishingEventId,
                        principalTable: "FishingEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FishCaughts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary key identifier for FishCaught entry")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FishingEventId = table.Column<int>(type: "int", nullable: false, comment: "Foreign key referencing the associated FishingEvent"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Foreign key referencing the User who caught the fish"),
                    SpeciesId = table.Column<int>(type: "int", nullable: false, comment: "Foreign key referencing the Species of the fish caught"),
                    Weight = table.Column<double>(type: "float", nullable: false, comment: "Weight of the fish caught in the specified measurement unit"),
                    Length = table.Column<double>(type: "float", nullable: false, comment: "Length of the fish caught in the specified measurement unit"),
                    CaughtImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "URL of the image showing the caught fish (optional)"),
                    DateCaught = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time when the fish was caught")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FishCaughts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FishCaughts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FishCaughts_FishingEvents_FishingEventId",
                        column: x => x.FishingEventId,
                        principalTable: "FishingEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FishCaughts_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a5f38997-71be-4d64-b6b8-0e741de5d2b5", null, "Admin", "ADMIN" },
                    { "d1d7ca33-a54c-4ea0-b96e-6ca509a57ec1", null, "GlobalAdmin", "GLOBALADMIN" },
                    { "e6c4f4e6-5f17-4a65-bfb7-64f6a33d5128", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2eff85cf-8402-45f8-bb3b-88bbafcc50d2", 0, "65201613-2f79-4789-99c8-d75bf04c0254", "admin@abv.bg", true, "Admin", "Admin", false, null, "ADMIN@ABV.BG", "ADMIN@ABV.BG", "AQAAAAIAAYagAAAAEDOZM5C3ShQjDDfSwjt+ArFypC9aC6QiLGzHr98pZ3d6AFIcCjJxtzciG/lMER1NnQ==", null, false, "238d7913-c878-4089-af34-62479c294b19", false, "admin@abv.bg" },
                    { "5667e464-5a99-44f1-81cd-6e9022965a07", 0, "6313b7b8-5802-4de1-81da-82c772fbfdaf", "user3@abv.bg", true, "TJ", "Ott", false, null, "USER3@ABV.BG", "USER3@ABV.BG", "AQAAAAIAAYagAAAAEPwWNd+UpAcYKmc8PUWkb9zdOafskXtAmM4brx23sIiehzryvzpi3W8K/7iFgszl5g==", null, false, "1bc6b324-ca48-401f-8ec3-ca0b98d33c19", false, "user3@abv.bg" },
                    { "8c148075-961f-4ddc-bdb2-416c5bfa1439", 0, "a0dfd3fc-a0a6-4d21-a204-2d2844e5a4c9", "user1@abv.bg", true, "Dave", "Marciano", false, null, "USER1@ABV.BG", "USER1@ABV.BG", "AQAAAAIAAYagAAAAECJL8fVb4mlKXIkhAgUogMpcosUcMucEK4ivZwSbPbCPYETTMdej8vnJTZEFAJMDww==", null, false, "41818489-5a9b-4b21-995a-8ac327bd0efa", false, "user1@abv.bg" },
                    { "a7dded57-50b8-4c59-8148-619b8d2a1266", 0, "46fb855d-71d7-4168-afbb-9e967e863e68", "user4@abv.bg", true, "Dave", "Carraro", false, null, "USER4@ABV.BG", "USER4@ABV.BG", "AQAAAAIAAYagAAAAEJ1C5yILsbx1k5YNDQSV88gbiD53PKHfvIjF3rbcPb7mS1WHoM0kgBYBGu0vzFS4Tw==", null, false, "0ed589a5-c456-4ae6-ad93-796ef96113ef", false, "user4@abv.bg" },
                    { "e1f8b74c-9b90-4054-ab42-8171c32ed1b2", 0, "4199ca08-f91e-442d-8a0f-e04a19008be5", "user5@abv.bg", true, "Paul", "Hebert", false, null, "USER5@ABV.BG", "USER5@ABV.BG", "AQAAAAIAAYagAAAAEKltUjkUMO2cmMJ619T6pUkyai3yVcKcS3/Qjd8tL5Uu0/vJv2wPoGbBT5zgJ8FT1A==", null, false, "81627f61-1f3c-4b84-90ba-40b2f9075340", false, "user5@abv.bg" },
                    { "ef082de5-9f29-4f11-adb4-a337f90e3373", 0, "a7b0674e-666c-4ea1-b34f-794d9f578982", "user2@abv.bg", true, "Tyler", "McLaughlin", false, null, "USER2@ABV.BG", "USER2@ABV.BG", "AQAAAAIAAYagAAAAEGTeY1XBqtz/a2e2gbt4GM4KyIZiMqHKe137AH83dvUgeC5uMx8oQ2awx9YeYBsp6A==", null, false, "30ea865a-c85d-4cbe-a7bd-f6ed61e525b1", false, "user2@abv.bg" },
                    { "f0c1090f-ba41-4420-8446-26f4efb810f1", 0, "27792ae2-7890-42f9-8e5a-64d54a1a0d54", "globaladmin@abv.bg", true, "Global", "Global", false, null, "GLOBALADMIN@ABV.BG", "GLOBALADMIN@ABV.BG", "AQAAAAIAAYagAAAAEA6LXE+3+U7nq4Y4BRuCYqB59rOh14dr8ZS9EzNieGpoIdDDF3JMDxnQsTn1h6NNIQ==", null, false, "a942e130-0fca-4d66-aa4e-9c3d9ffb9c67", false, "globaladmin@abv.bg" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Elevation", "FishingType", "LocationImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "250", "Trolling,Jigging", "https://svetogled.com/wp-content/uploads/2021/05/DSC_0680-800x500.jpg", "Mihalkovo" },
                    { 2, "1400", "Soft Plastic Lures,Float", "https://4u-luxury-villa.com/wp-content/uploads/2022/10/Dospat.jpg", "Dospat" },
                    { 3, "2", "Live bait", "https://photos.smugmug.com/Aerials/Massachusetts/Gloucester-MA-aerial-photos/i-z7TrSmq/2/LDpDV5CVDMk29PnCDcbvDK6PsqDJVQwXPwCxvTfGF/L/_MG_9999%20-%20Version%202-L.jpg", "Gloucester,Massachusetts" },
                    { 4, "124", "Live bait,Frog lure", "https://www.iberdrolaespana.com/documents/2692041/3701769/cuenca-ebro-cantabrico-746x419.png/c49350ea-0723-6b45-e37a-49a404380b06?t=1701255674149", "Velilla de Ebro,Spain" },
                    { 5, "1", "Lure", "https://mediaim.expedia.com/destination/1/66f2da633e3df0ef6cefdc10aefc3c1f.jpg", "Kefalonia,Poros" },
                    { 6, "1", "Lure,Live bait", "https://theinsidetraveller.com/wp-content/uploads/2024/03/dji_fly_20230723_135658_518_1690174403398_photo-1.jpg?w=1024", "Lefkada" }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "Description", "FishBait", "FishImageUrl", "HabitatName", "Name" },
                values: new object[,]
                {
                    { 1, "They are generally silvery white in color and most have dark horizontal lines along their sides.", "lures, live bait, spinner baits, jig bait", "https://www.graytaxidermy.com/images/large-fishmount-photos/large-mouth-bass-silo.jpg", "Lakes or shallow bays of larger lakes.", "Bass" },
                    { 2, "Trout have fins entirely without spines, and all of them have a small adipose fin along the back, near the tail.", "lures, live bait, spinner baits, jig bait,camola", "https://images.squarespace-cdn.com/content/v1/5be9e00d5b409b36bd17e36f/a9b6dce2-17eb-4c9c-9755-78cff2f43c87/Dorado+%28Mahi+Mahi%29+Coryphaena+Hippurus.jpeg", "Trout need cold water to survive.", "Trout" },
                    { 3, "Atlantic bluefin tuna have large, torpedo-shaped bodies that are nearly circular in cross-section.", "Live bait", "https://images.squarespace-cdn.com/content/v1/5890c07bcd0f685b13dc60bf/1490802646283-GBTVAD6YM4G07UWVZJ12/image-asset.png", "Near offshore islands", "Atlantic bluefin tuna" },
                    { 4, "large spindle-shaped body", "Worms,Minnows and Small Fish", "https://cdn.shopify.com/s/files/1/2527/6546/files/brown_bullhead_480x480.jpg?v=1618523580", "Slow-flowing and swampy bodies of water", "Catfish" },
                    { 5, "The fish has a long, slender body that is tapered at the ends and thicker in the middle.", "Live bait,Lure", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQf4kpsp3YY-spyzPn86Mhq0MXFyMzHhdtYQmrDdXVcL5nNdQbVi2yt-ZBpdmqZtPXHmA&usqp=CAU", "Seagrass beds, mangroves, and coral reefs.", "Barracuda" },
                    { 6, "Perch have a long and round body shape which allows for fast swimming in the water.", "Jig,Lure,Worms", "https://portal.ct.gov/-/media/deep/fishing/freshwater/freshwater_fishes/perches-and-darters/74ayellowperchacompressed.jpg?rev=9152b888941e4650bc94dd51c0b713e3&sc_lang=en&hash=F3D205D82079E5FAA26D6BB0FE116D86q=tbn:ANd9GcSsxP5wYue8ZxzOp8mTJTMUe5pN6O0AC_NPhw&s", "Freshwater ponds, lakes, streams, or rivers.", "Perch" },
                    { 7, "The common carp is a heavy-bodied minnow with barbels on either side of the upper jaw.", "Sweetcorn,Boilies,Pellets", "https://badangling.com/wp-content/uploads/2018/06/common-carp-species.jpg", "Still or slowly flowing waters at low altitudes.", "Carp" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "a5f38997-71be-4d64-b6b8-0e741de5d2b5", "2eff85cf-8402-45f8-bb3b-88bbafcc50d2" },
                    { "e6c4f4e6-5f17-4a65-bfb7-64f6a33d5128", "5667e464-5a99-44f1-81cd-6e9022965a07" },
                    { "e6c4f4e6-5f17-4a65-bfb7-64f6a33d5128", "8c148075-961f-4ddc-bdb2-416c5bfa1439" },
                    { "e6c4f4e6-5f17-4a65-bfb7-64f6a33d5128", "a7dded57-50b8-4c59-8148-619b8d2a1266" },
                    { "e6c4f4e6-5f17-4a65-bfb7-64f6a33d5128", "e1f8b74c-9b90-4054-ab42-8171c32ed1b2" },
                    { "e6c4f4e6-5f17-4a65-bfb7-64f6a33d5128", "ef082de5-9f29-4f11-adb4-a337f90e3373" },
                    { "d1d7ca33-a54c-4ea0-b96e-6ca509a57ec1", "f0c1090f-ba41-4420-8446-26f4efb810f1" }
                });

            migrationBuilder.InsertData(
                table: "FishingEvents",
                columns: new[] { "Id", "Description", "EndDate", "EventImageUrl", "EventName", "IsCompleted", "LocationId", "OrganizerId", "StartDate" },
                values: new object[,]
                {
                    { 1, "Join us for a day of fishing and fun!", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://baileysharbor.com/wp-content/uploads/2023/03/BH-Brown-Trout-23-Logo-1.jpg", "Spring Fishing Festival", false, 1, "e1f8b74c-9b90-4054-ab42-8171c32ed1b2", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Join us for a cold day of fishing and fun!", new DateTime(2024, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://img.freepik.com/premium-vector/fishing-tournament-logo-template-isolated_384468-27.jpg", "Winter Fishing Festival", false, 2, "2eff85cf-8402-45f8-bb3b-88bbafcc50d2", new DateTime(2024, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Join us for Atlantic bluefin tuna!", new DateTime(2024, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://play-lh.googleusercontent.com/TphogImhoiplJ6NBslILTd1eko8KCWb-NDirph-RcoMSiga-v-8YfVZWddAvhLwbVSjBJg", "Wicked Tuna", false, 3, "8c148075-961f-4ddc-bdb2-416c5bfa1439", new DateTime(2024, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Go to Ionian sea", new DateTime(2024, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://static.vecteezy.com/system/resources/thumbnails/023/059/722/small_2x/design-of-barracuda-fishing-vector.jpg", "Catching Big Barracudas", false, 6, "ef082de5-9f29-4f11-adb4-a337f90e3373", new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Big Catfish in Ebro river", new DateTime(2024, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSLtFBYwC0pUKQmDLimBxIa2V3e8pZ50diWlON8SJtbqMTqvdWu0juQI9vuo-PxMZVySdE&usqp=CAU", "Catching Catfish", false, 4, "f0c1090f-ba41-4420-8446-26f4efb810f1", new DateTime(2024, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "CommentText", "CreatedOn", "FishingEventId" },
                values: new object[,]
                {
                    { 1, "a7dded57-50b8-4c59-8148-619b8d2a1266", "Great fish!", new DateTime(2024, 11, 23, 13, 0, 28, 307, DateTimeKind.Local).AddTicks(7774), 3 },
                    { 2, "8c148075-961f-4ddc-bdb2-416c5bfa1439", "Thanks!!!", new DateTime(2024, 11, 23, 13, 0, 28, 307, DateTimeKind.Local).AddTicks(7841), 3 },
                    { 3, "ef082de5-9f29-4f11-adb4-a337f90e3373", "How much does it weigh?", new DateTime(2024, 11, 23, 13, 0, 28, 307, DateTimeKind.Local).AddTicks(7844), 3 },
                    { 4, "8c148075-961f-4ddc-bdb2-416c5bfa1439", "1200 pounds(540 kg)", new DateTime(2024, 11, 23, 13, 0, 28, 307, DateTimeKind.Local).AddTicks(7846), 3 },
                    { 5, "ef082de5-9f29-4f11-adb4-a337f90e3373", "Whoooa!", new DateTime(2024, 11, 23, 13, 0, 28, 307, DateTimeKind.Local).AddTicks(7847), 3 }
                });

            migrationBuilder.InsertData(
                table: "EventParticipants",
                columns: new[] { "FishingEventId", "UserId" },
                values: new object[,]
                {
                    { 3, "8c148075-961f-4ddc-bdb2-416c5bfa1439" },
                    { 3, "a7dded57-50b8-4c59-8148-619b8d2a1266" },
                    { 3, "ef082de5-9f29-4f11-adb4-a337f90e3373" },
                    { 4, "5667e464-5a99-44f1-81cd-6e9022965a07" },
                    { 4, "e1f8b74c-9b90-4054-ab42-8171c32ed1b2" }
                });

            migrationBuilder.InsertData(
                table: "FishCaughts",
                columns: new[] { "Id", "CaughtImageUrl", "DateCaught", "FishingEventId", "Length", "SpeciesId", "UserId", "Weight" },
                values: new object[,]
                {
                    { 1, "https://www.looper.com/img/gallery/facts-about-wicked-tunas-dave-marciano-you-wont-have-to-fish-for/a-1200-pound-bluefin-tuna-was-his-largest-catch-1666893399.jpg", new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 230.0, 3, "8c148075-961f-4ddc-bdb2-416c5bfa1439", 544.0 },
                    { 2, "https://www.pressherald.com/wp-content/uploads/sites/4/2013/04/portland-press-herald_3753041.jpg?w=800", new DateTime(2024, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 195.0, 3, "a7dded57-50b8-4c59-8148-619b8d2a1266", 207.0 },
                    { 3, "https://media.distractify.com/brand-img/6Eeo0qnci/0x0/tyler-marissa-wicked-tuna-1559414259195.jpg", new DateTime(2024, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 212.0, 3, "ef082de5-9f29-4f11-adb4-a337f90e3373", 207.0 },
                    { 4, "https://a57.foxnews.com/static.foxnews.com/foxnews.com/content/uploads/2020/03/1200/675/TheFleetStrikesBack_WickedTuna_Ep707_LR_18.jpg?ve=1&tl=1", new DateTime(2024, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 208.0, 3, "8c148075-961f-4ddc-bdb2-416c5bfa1439", 230.0 },
                    { 5, "https://www.howtocatchanyfish.com/uploads/8/8/0/2/8802125/cuda2_orig.jpg", new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 172.0, 5, "5667e464-5a99-44f1-81cd-6e9022965a07", 41.0 },
                    { 6, "https://alphonsefishingco.com/wp-content/uploads/2023/06/seychelles-alphonse-island-species-barracuda-06.jpg", new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 191.0, 5, "e1f8b74c-9b90-4054-ab42-8171c32ed1b2", 52.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthorId",
                table: "Comments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_FishingEventId",
                table: "Comments",
                column: "FishingEventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipants_UserId",
                table: "EventParticipants",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FishCaughts_FishingEventId",
                table: "FishCaughts",
                column: "FishingEventId");

            migrationBuilder.CreateIndex(
                name: "IX_FishCaughts_SpeciesId",
                table: "FishCaughts",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_FishCaughts_UserId",
                table: "FishCaughts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FishingEvents_LocationId",
                table: "FishingEvents",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_FishingEvents_OrganizerId",
                table: "FishingEvents",
                column: "OrganizerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "EventParticipants");

            migrationBuilder.DropTable(
                name: "FishCaughts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "FishingEvents");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
