using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace enrolmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class courseid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "studentID",
                keyValue: "I22023292",
                column: "courseID",
                value: "BCSI");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "studentID",
                keyValue: "I22023292",
                column: "courseID",
                value: null);
        }
    }
}
