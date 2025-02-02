using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarMarketplace.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "793b852c-efe4-4a51-a5dc-2c737053ec7e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4f51b25-3c56-47e7-8b31-6b80f6d894e4");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c271aab2-bfc3-40e2-83df-bbe257463ad2", null, "Admin", "ADMIN" },
                    { "eddf3c55-4db8-4e43-81a7-2aec5ae0c2b4", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c271aab2-bfc3-40e2-83df-bbe257463ad2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eddf3c55-4db8-4e43-81a7-2aec5ae0c2b4");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Stores");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "793b852c-efe4-4a51-a5dc-2c737053ec7e", null, "User", "USER" },
                    { "a4f51b25-3c56-47e7-8b31-6b80f6d894e4", null, "Admin", "ADMIN" }
                });
        }
    }
}
