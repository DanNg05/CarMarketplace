using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarMarketplace.Migrations
{
    /// <inheritdoc />
    public partial class ImageUrls_Car : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32dd1d2e-34ea-41c3-828a-3f9e2f7c01ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0d71dd2-22b1-49a1-92f7-00ff744884f4");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrls",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "18d2ac5e-f3ac-4e02-b1c0-4d562951f03c", null, "User", "USER" },
                    { "cea8ae0b-eda5-4de5-a209-afb959a46aa9", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18d2ac5e-f3ac-4e02-b1c0-4d562951f03c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cea8ae0b-eda5-4de5-a209-afb959a46aa9");

            migrationBuilder.DropColumn(
                name: "ImageUrls",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "32dd1d2e-34ea-41c3-828a-3f9e2f7c01ce", null, "Admin", "ADMIN" },
                    { "e0d71dd2-22b1-49a1-92f7-00ff744884f4", null, "User", "USER" }
                });
        }
    }
}
