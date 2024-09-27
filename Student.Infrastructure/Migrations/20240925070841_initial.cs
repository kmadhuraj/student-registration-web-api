using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseID);
                });

            migrationBuilder.CreateTable(
                name: "Hobbies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hobbie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StudentDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmailD = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MobileNumber = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Pincode = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StudentDetails_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Qualifications",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    ClassXBoard = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ClassXPercentage = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ClassXYearOfPassing = table.Column<int>(type: "int", nullable: false),
                    ClassX11Board = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Class11Percentage = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ClassX11YearOfPassing = table.Column<int>(type: "int", nullable: false),
                    GraduationBoard = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GraduationPercentage = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    GraduationYearOfPasssing = table.Column<int>(type: "int", nullable: false),
                    MastersBoard = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MastersPercentage = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    MastersYearOfPasssing = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualifications", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Qualifications_StudentDetails_StudentID",
                        column: x => x.StudentID,
                        principalTable: "StudentDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentHobbies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    Hobbie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentHobbies", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StudentHobbies_StudentDetails_StudentID",
                        column: x => x.StudentID,
                        principalTable: "StudentDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Qualifications_StudentID",
                table: "Qualifications",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDetails_CourseID",
                table: "StudentDetails",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentHobbies_StudentID",
                table: "StudentHobbies",
                column: "StudentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hobbies");

            migrationBuilder.DropTable(
                name: "Qualifications");

            migrationBuilder.DropTable(
                name: "StudentHobbies");

            migrationBuilder.DropTable(
                name: "StudentDetails");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
