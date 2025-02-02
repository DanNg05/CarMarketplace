using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarMarketplace.Migrations
{
    /// <inheritdoc />
    public partial class commentPhoneNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1032b220-2afa-4c60-84bd-8be979fca2e2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76034820-4662-4788-8492-f63643acab85");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "32dd1d2e-34ea-41c3-828a-3f9e2f7c01ce", null, "Admin", "ADMIN" },
                    { "e0d71dd2-22b1-49a1-92f7-00ff744884f4", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32dd1d2e-34ea-41c3-828a-3f9e2f7c01ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0d71dd2-22b1-49a1-92f7-00ff744884f4");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Stores",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1032b220-2afa-4c60-84bd-8be979fca2e2", null, "User", "USER" },
                    { "76034820-4662-4788-8492-f63643acab85", null, "Admin", "ADMIN" }
                });
        }
    }
}
