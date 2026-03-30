using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace enrolmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "studentID",
                keyValue: "I22023292",
                columns: new[] { "HPNum", "TelNum", "currentCountry", "emergencyHPNum" },
                values: new object[] { "+609876543210", "+601234567890", "Malaysia", "+601122334455" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "studentID",
                keyValue: "I22023292",
                columns: new[] { "HPNum", "TelNum", "currentCountry", "emergencyHPNum" },
                values: new object[] { "09876543210", "01234567890", "Country", "01122334455" });
        }
    }
}
