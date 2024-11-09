using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FishingEvents.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a5f38997-71be-4d64-b6b8-0e741de5d2b5", null, "Admin", "ADMIN" },
                    { "e6c4f4e6-5f17-4a65-bfb7-64f6a33d5128", null, "User", "USER" }
                });

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

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "a5f38997-71be-4d64-b6b8-0e741de5d2b5", "2eff85cf-8402-45f8-bb3b-88bbafcc50d2" },
                    { "e6c4f4e6-5f17-4a65-bfb7-64f6a33d5128", "5667e464-5a99-44f1-81cd-6e9022965a07" },
                    { "e6c4f4e6-5f17-4a65-bfb7-64f6a33d5128", "8c148075-961f-4ddc-bdb2-416c5bfa1439" },
                    { "e6c4f4e6-5f17-4a65-bfb7-64f6a33d5128", "ef082de5-9f29-4f11-adb4-a337f90e3373" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a5f38997-71be-4d64-b6b8-0e741de5d2b5", "2eff85cf-8402-45f8-bb3b-88bbafcc50d2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e6c4f4e6-5f17-4a65-bfb7-64f6a33d5128", "5667e464-5a99-44f1-81cd-6e9022965a07" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e6c4f4e6-5f17-4a65-bfb7-64f6a33d5128", "8c148075-961f-4ddc-bdb2-416c5bfa1439" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e6c4f4e6-5f17-4a65-bfb7-64f6a33d5128", "ef082de5-9f29-4f11-adb4-a337f90e3373" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5f38997-71be-4d64-b6b8-0e741de5d2b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6c4f4e6-5f17-4a65-bfb7-64f6a33d5128");

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
        }
    }
}
