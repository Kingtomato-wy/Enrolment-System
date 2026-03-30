using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace enrolmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class course : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "courseID",
                table: "Student",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    courseID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    courseName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.courseID);
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "courseID", "courseName" },
                values: new object[,]
                {
                    { "BCSI", "Bachelor in Computer Science" },
                    { "BITI", "Bachelor in Information Technology" }
                });

            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "studentID",
                keyValue: "I22023292",
                column: "courseID",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Student_courseID",
                table: "Student",
                column: "courseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Course_courseID",
                table: "Student",
                column: "courseID",
                principalTable: "Course",
                principalColumn: "courseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Course_courseID",
                table: "Student");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Student_courseID",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "courseID",
                table: "Student");
        }
    }
}
