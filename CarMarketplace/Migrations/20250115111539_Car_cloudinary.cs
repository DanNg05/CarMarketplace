using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarMarketplace.Migrations
{
    /// <inheritdoc />
    public partial class Car_cloudinary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c271aab2-bfc3-40e2-83df-bbe257463ad2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eddf3c55-4db8-4e43-81a7-2aec5ae0c2b4");

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
                    { "3da793d2-53e8-4b4d-b8b8-1754d9c3295b", null, "User", "USER" },
                    { "c21da3cd-247f-4590-a98d-2dac6decf16c", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3da793d2-53e8-4b4d-b8b8-1754d9c3295b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c21da3cd-247f-4590-a98d-2dac6decf16c");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Cars");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c271aab2-bfc3-40e2-83df-bbe257463ad2", null, "Admin", "ADMIN" },
                    { "eddf3c55-4db8-4e43-81a7-2aec5ae0c2b4", null, "User", "USER" }
                });
        }
    }
}
