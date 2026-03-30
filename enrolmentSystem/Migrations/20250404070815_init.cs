using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace enrolmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    adminID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    adminName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adminEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    adminPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.adminID);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    studentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    studentEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studentPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    primaryEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    alternativeEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelNum = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    HPNum = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    permanantAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    permanantPostalCode = table.Column<int>(type: "int", nullable: false),
                    permanantArea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    permanantState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    permanantCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    currentAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    currentPostalCode = table.Column<int>(type: "int", nullable: false),
                    currentArea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    currentState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    currentCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emergencyContactRelationship = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emergencyContactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emergencyHPNum = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    bankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bankAccountNumber = table.Column<int>(type: "int", nullable: false),
                    bankHolderName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.studentID);
                });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "adminID", "adminEmail", "adminName", "adminPassword" },
                values: new object[,]
                {
                    { "A001", "", "Chong Pui Lin", "chongpuilin" },
                    { "A002", "", "Chong Fong Kim", "chongfongkim" }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "studentID", "HPNum", "TelNum", "alternativeEmail", "bankAccountNumber", "bankHolderName", "bankName", "currentAddress", "currentArea", "currentCountry", "currentPostalCode", "currentState", "emergencyContactName", "emergencyContactRelationship", "emergencyHPNum", "permanantAddress", "permanantArea", "permanantCountry", "permanantPostalCode", "permanantState", "primaryEmail", "studentEmail", "studentName", "studentPassword" },
                values: new object[] { "I22023292", "09876543210", "01234567890", "john.alternate@example.com", 1234567890, "John Doe", "ABB: Affin Bank Berhad", "456 Elm Street", "Downtown", "Country", 67890, "State B", "James Doe", "Father", "01122334455", "123 Main Street", "City Center", "Malaysia", 12345, "State A", "johndoe@example.com", "student@example.com", "John Doe", "hashedpassword123" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
