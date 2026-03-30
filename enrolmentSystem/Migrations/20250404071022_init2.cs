using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace enrolmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "adminID",
                keyValue: "A001",
                column: "adminEmail",
                value: "cpl@gmail.com");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "adminID",
                keyValue: "A002",
                column: "adminEmail",
                value: "cfk@gmail.com");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "adminID",
                keyValue: "A001",
                column: "adminEmail",
                value: "");

            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "adminID",
                keyValue: "A002",
                column: "adminEmail",
                value: "");
        }
    }
}
