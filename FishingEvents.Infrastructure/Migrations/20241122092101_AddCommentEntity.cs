using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishingEvents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCommentEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OrganizerId",
                table: "FishingEvents",
                type: "nvarchar(450)",
                nullable: true,
                comment: "Foreign key referencing the Organizer of the event",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Foreign key referencing the Organizer of the event");

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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2eff85cf-8402-45f8-bb3b-88bbafcc50d2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "277397cc-2489-47ca-a93f-eb81dc0d1a88", "AQAAAAIAAYagAAAAEP61+Ne8NQ0fDNC5ZkCCb3fAAsE+b73REPh0EFOnqedQRPHdkCVfMqShsLViFRLdYA==", "d6663446-1599-4b61-9b2e-ee57777d8fe5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5667e464-5a99-44f1-81cd-6e9022965a07",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3da28cfa-b4d0-4ad3-8e88-175ba76383a6", "AQAAAAIAAYagAAAAEO/o0pESUNlNMBaWS0HTG8HMRS+mKHa8mU+Rg+Y4Ij56cRl0ZV6ZsitvQriDnw1x+w==", "a23f02af-4811-4678-bbce-dd9ad6929ce9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8c148075-961f-4ddc-bdb2-416c5bfa1439",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "365fb142-3600-4522-a74d-0245c068fd84", "AQAAAAIAAYagAAAAEGG5qfp9+BwQb6/XVXMwID0TKQrmnwrGmx+QtL/NEd75rbVjoK3HJCx5iIIZ5NF4Tg==", "e5d46227-b2ad-4c51-add0-fd812a6f113a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef082de5-9f29-4f11-adb4-a337f90e3373",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4322c284-eda0-446a-9c01-2f9dd6b73bef", "AQAAAAIAAYagAAAAEMMyFTgC0BEsyY8bv2FODXrKDCMewxZ15GFPHIi/mdPVojz8Q5AXQ6nGylMNCqAavw==", "01c3e539-161b-4659-9fa1-81181ebcfc19" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f0c1090f-ba41-4420-8446-26f4efb810f1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "18955252-8178-4639-9b9c-08a12a96b890", "AQAAAAIAAYagAAAAEIzQI5I/y+LpK2+LjUpU/g2kmI/84M99vvvS0mnaVoAqz2AVPiEzu4mpnezxvxBYcA==", "b860a569-514a-466f-b805-a1cd1dab422d" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthorId",
                table: "Comments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_FishingEventId",
                table: "Comments",
                column: "FishingEventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "OrganizerId",
                table: "FishingEvents",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                comment: "Foreign key referencing the Organizer of the event",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true,
                oldComment: "Foreign key referencing the Organizer of the event");

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
    }
}
