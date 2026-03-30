using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace enrolmentSystem.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    adminID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    adminName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adminPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.adminID);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    courseID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    courseName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.courseID);
                });

            migrationBuilder.CreateTable(
                name: "Lecturers",
                columns: table => new
                {
                    lecturerID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    lecturerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecturers", x => x.lecturerID);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    paymentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    enrolmenttID = table.Column<int>(type: "int", nullable: true),
                    paymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    paymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    paymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.paymentID);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    sessionID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    startDate = table.Column<DateOnly>(type: "date", nullable: false),
                    endDate = table.Column<DateOnly>(type: "date", nullable: false),
                    sessionStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.sessionID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    studentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    semester = table.Column<int>(type: "int", nullable: false),
                    studentEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studentPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    studentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    primaryEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    alternativeEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelNum = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    HPNum = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    permanantAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    permanantPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    permanantArea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    permanantState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentArea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emergencyContactRelationship = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emergencyContactName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emergencyHPNum = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    bankDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    courseID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.studentID);
                    table.ForeignKey(
                        name: "FK_Students_Courses_courseID",
                        column: x => x.courseID,
                        principalTable: "Courses",
                        principalColumn: "courseID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    subjectID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    subjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subjectCredit = table.Column<int>(type: "int", nullable: false),
                    courseID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.subjectID);
                    table.ForeignKey(
                        name: "FK_Subjects_Courses_courseID",
                        column: x => x.courseID,
                        principalTable: "Courses",
                        principalColumn: "courseID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inquiries",
                columns: table => new
                {
                    inquiryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inquiries", x => x.inquiryID);
                    table.ForeignKey(
                        name: "FK_Inquiries_Students_studentID",
                        column: x => x.studentID,
                        principalTable: "Students",
                        principalColumn: "studentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubjectsOffered",
                columns: table => new
                {
                    subjectOfferedID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subjectID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    sessionID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    lecturerID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    section = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    maxSeats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectsOffered", x => x.subjectOfferedID);
                    table.ForeignKey(
                        name: "FK_SubjectsOffered_Lecturers_lecturerID",
                        column: x => x.lecturerID,
                        principalTable: "Lecturers",
                        principalColumn: "lecturerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectsOffered_Sessions_sessionID",
                        column: x => x.sessionID,
                        principalTable: "Sessions",
                        principalColumn: "sessionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubjectsOffered_Subjects_subjectID",
                        column: x => x.subjectID,
                        principalTable: "Subjects",
                        principalColumn: "subjectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enrolments",
                columns: table => new
                {
                    enrolmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    subjectOfferedID = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    enrolDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    paymentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrolments", x => x.enrolmentID);
                    table.ForeignKey(
                        name: "FK_Enrolments_Payments_paymentID",
                        column: x => x.paymentID,
                        principalTable: "Payments",
                        principalColumn: "paymentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enrolments_Students_studentID",
                        column: x => x.studentID,
                        principalTable: "Students",
                        principalColumn: "studentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enrolments_SubjectsOffered_subjectOfferedID",
                        column: x => x.subjectOfferedID,
                        principalTable: "SubjectsOffered",
                        principalColumn: "subjectOfferedID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Evaluations",
                columns: table => new
                {
                    EvaluationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    SubjectOfferedID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => x.EvaluationID);
                    table.ForeignKey(
                        name: "FK_Evaluations_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "studentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Evaluations_SubjectsOffered_SubjectOfferedID",
                        column: x => x.SubjectOfferedID,
                        principalTable: "SubjectsOffered",
                        principalColumn: "subjectOfferedID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Timetables",
                columns: table => new
                {
                    timetableID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subjectOfferedID = table.Column<int>(type: "int", nullable: false),
                    day = table.Column<int>(type: "int", nullable: false),
                    startTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    endTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    roomtType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timetables", x => x.timetableID);
                    table.ForeignKey(
                        name: "FK_Timetables_SubjectsOffered_subjectOfferedID",
                        column: x => x.subjectOfferedID,
                        principalTable: "SubjectsOffered",
                        principalColumn: "subjectOfferedID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AddDropRequests",
                columns: table => new
                {
                    requestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    subjectOfferedID = table.Column<int>(type: "int", nullable: true),
                    enrolmentID = table.Column<int>(type: "int", nullable: true),
                    adminID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    requestReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    requestDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    approvalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddDropRequests", x => x.requestID);
                    table.ForeignKey(
                        name: "FK_AddDropRequests_Admins_adminID",
                        column: x => x.adminID,
                        principalTable: "Admins",
                        principalColumn: "adminID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AddDropRequests_Enrolments_enrolmentID",
                        column: x => x.enrolmentID,
                        principalTable: "Enrolments",
                        principalColumn: "enrolmentID");
                    table.ForeignKey(
                        name: "FK_AddDropRequests_Students_studentID",
                        column: x => x.studentID,
                        principalTable: "Students",
                        principalColumn: "studentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AddDropRequests_SubjectsOffered_subjectOfferedID",
                        column: x => x.subjectOfferedID,
                        principalTable: "SubjectsOffered",
                        principalColumn: "subjectOfferedID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddDropRequests_adminID",
                table: "AddDropRequests",
                column: "adminID");

            migrationBuilder.CreateIndex(
                name: "IX_AddDropRequests_enrolmentID",
                table: "AddDropRequests",
                column: "enrolmentID");

            migrationBuilder.CreateIndex(
                name: "IX_AddDropRequests_studentID",
                table: "AddDropRequests",
                column: "studentID");

            migrationBuilder.CreateIndex(
                name: "IX_AddDropRequests_subjectOfferedID",
                table: "AddDropRequests",
                column: "subjectOfferedID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrolments_paymentID",
                table: "Enrolments",
                column: "paymentID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrolments_studentID",
                table: "Enrolments",
                column: "studentID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrolments_subjectOfferedID",
                table: "Enrolments",
                column: "subjectOfferedID",
                unique: true,
                filter: "[subjectOfferedID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_StudentID",
                table: "Evaluations",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_SubjectOfferedID",
                table: "Evaluations",
                column: "SubjectOfferedID");

            migrationBuilder.CreateIndex(
                name: "IX_Inquiries_studentID",
                table: "Inquiries",
                column: "studentID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_courseID",
                table: "Students",
                column: "courseID");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_courseID",
                table: "Subjects",
                column: "courseID");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectsOffered_lecturerID",
                table: "SubjectsOffered",
                column: "lecturerID");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectsOffered_sessionID",
                table: "SubjectsOffered",
                column: "sessionID");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectsOffered_subjectID",
                table: "SubjectsOffered",
                column: "subjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Timetables_subjectOfferedID",
                table: "Timetables",
                column: "subjectOfferedID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddDropRequests");

            migrationBuilder.DropTable(
                name: "Evaluations");

            migrationBuilder.DropTable(
                name: "Inquiries");

            migrationBuilder.DropTable(
                name: "Timetables");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Enrolments");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "SubjectsOffered");

            migrationBuilder.DropTable(
                name: "Lecturers");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
