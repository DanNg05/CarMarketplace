using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarMarketplace.Migrations
{
    /// <inheritdoc />
    public partial class checkImageFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3da793d2-53e8-4b4d-b8b8-1754d9c3295b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c21da3cd-247f-4590-a98d-2dac6decf16c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1032b220-2afa-4c60-84bd-8be979fca2e2", null, "User", "USER" },
                    { "76034820-4662-4788-8492-f63643acab85", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1032b220-2afa-4c60-84bd-8be979fca2e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76034820-4662-4788-8492-f63643acab85");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3da793d2-53e8-4b4d-b8b8-1754d9c3295b", null, "User", "USER" },
                    { "c21da3cd-247f-4590-a98d-2dac6decf16c", null, "Admin", "ADMIN" }
                });
        }
    }
}
