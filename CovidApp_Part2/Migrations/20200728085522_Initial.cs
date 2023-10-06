using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CovidApp_Part2.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    GenderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.GenderId);
                });

            migrationBuilder.CreateTable(
                name: "Lab",
                columns: table => new
                {
                    LabId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LabName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lab", x => x.LabId);
                });

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    ProvinceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinceName = table.Column<string>(nullable: false),
                    ProvinceAbbreviation = table.Column<string>(maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.ProvinceId);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "TestResult",
                columns: table => new
                {
                    TestResultId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestResultName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestResult", x => x.TestResultId);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    PatientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientAge = table.Column<int>(nullable: false),
                    GenderId = table.Column<int>(nullable: false),
                    ProvinceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_Patient_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "GenderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patient_Province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Province",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientStatus",
                columns: table => new
                {
                    PatientStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    PatientStatusDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientStatus", x => x.PatientStatusId);
                    table.ForeignKey(
                        name: "FK_PatientStatus_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientStatus_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    TestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestDate = table.Column<DateTime>(nullable: false),
                    PatientId = table.Column<int>(nullable: false),
                    LabId = table.Column<int>(nullable: false),
                    TestResultId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.TestId);
                    table.ForeignKey(
                        name: "FK_Test_Lab_LabId",
                        column: x => x.LabId,
                        principalTable: "Lab",
                        principalColumn: "LabId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Test_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Test_TestResult_TestResultId",
                        column: x => x.TestResultId,
                        principalTable: "TestResult",
                        principalColumn: "TestResultId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "GenderId", "GenderName" },
                values: new object[,]
                {
                    { 1, "Female" },
                    { 2, "Male" }
                });

            migrationBuilder.InsertData(
                table: "Lab",
                columns: new[] { "LabId", "LabName" },
                values: new object[,]
                {
                    { 1, "Private" },
                    { 2, "Public" }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "ProvinceId", "ProvinceAbbreviation", "ProvinceName" },
                values: new object[,]
                {
                    { 9, "WC", "Western Cape" },
                    { 8, "NW", "North West" },
                    { 7, "NC", "Northern Cape" },
                    { 5, "L", "Limpopo" },
                    { 6, "MP", "Mpumalanga" },
                    { 3, "GP", "Gauteng" },
                    { 2, "FS", "Free State" },
                    { 1, "EC", "Eastern Cape" },
                    { 4, "KZN", "KwaZulu-Natal" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "StatusId", "StatusName" },
                values: new object[,]
                {
                    { 1, "Active" },
                    { 2, "Deceased" },
                    { 3, "Recovered" },
                    { 4, "Not infected" }
                });

            migrationBuilder.InsertData(
                table: "TestResult",
                columns: new[] { "TestResultId", "TestResultName" },
                values: new object[,]
                {
                    { 1, "Positive" },
                    { 2, "Negative" }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "PatientId", "GenderId", "PatientAge", "ProvinceId" },
                values: new object[,]
                {
                    { 17, 1, 32, 2 },
                    { 105, 1, 64, 6 },
                    { 62, 1, 55, 6 },
                    { 15, 2, 27, 6 },
                    { 61, 1, 29, 5 },
                    { 104, 1, 55, 4 },
                    { 103, 1, 54, 4 },
                    { 102, 1, 59, 4 },
                    { 80, 1, 3, 4 },
                    { 79, 1, 5, 4 },
                    { 78, 2, 59, 4 },
                    { 77, 1, 48, 4 },
                    { 51, 1, 34, 4 },
                    { 38, 1, 47, 4 },
                    { 23, 1, 52, 4 },
                    { 22, 1, 79, 4 },
                    { 14, 1, 38, 4 },
                    { 12, 1, 40, 4 },
                    { 7, 1, 38, 4 },
                    { 6, 1, 45, 4 },
                    { 5, 1, 38, 4 },
                    { 4, 2, 38, 4 },
                    { 3, 2, 38, 4 },
                    { 1, 1, 38, 4 },
                    { 101, 2, 71, 3 },
                    { 100, 2, 21, 3 },
                    { 106, 2, 56, 6 },
                    { 99, 1, 3, 3 },
                    { 13, 1, 36, 9 },
                    { 32, 1, 27, 9 },
                    { 114, 1, 51, 9 },
                    { 113, 2, 54, 9 },
                    { 112, 1, 51, 9 },
                    { 111, 1, 60, 9 },
                    { 110, 2, 27, 9 },
                    { 109, 2, 35, 9 },
                    { 108, 1, 51, 9 },
                    { 107, 1, 2, 9 },
                    { 85, 2, 71, 9 },
                    { 84, 2, 62, 9 },
                    { 83, 1, 2, 9 },
                    { 82, 1, 58, 9 },
                    { 81, 1, 3, 9 },
                    { 60, 1, 15, 9 },
                    { 59, 1, 39, 9 },
                    { 50, 1, 35, 9 },
                    { 49, 1, 33, 9 },
                    { 48, 1, 50, 9 },
                    { 47, 2, 42, 9 },
                    { 46, 2, 35, 9 },
                    { 37, 1, 32, 9 },
                    { 36, 1, 73, 9 },
                    { 35, 2, 14, 9 },
                    { 34, 1, 49, 9 },
                    { 33, 2, 33, 9 },
                    { 24, 1, 50, 9 },
                    { 98, 1, 20, 3 },
                    { 97, 1, 37, 3 },
                    { 96, 1, 34, 3 },
                    { 52, 1, 33, 3 },
                    { 45, 1, 29, 3 },
                    { 44, 2, 53, 3 },
                    { 43, 2, 21, 3 },
                    { 42, 1, 27, 3 },
                    { 41, 1, 54, 3 },
                    { 40, 1, 36, 3 },
                    { 39, 1, 60, 3 },
                    { 31, 2, 19, 3 },
                    { 30, 1, 62, 3 },
                    { 29, 1, 38, 3 },
                    { 28, 1, 52, 3 },
                    { 27, 1, 47, 3 },
                    { 26, 2, 72, 3 },
                    { 25, 1, 76, 3 },
                    { 21, 1, 57, 3 },
                    { 20, 2, 21, 3 },
                    { 19, 1, 50, 3 },
                    { 18, 2, 39, 3 },
                    { 16, 1, 43, 3 },
                    { 11, 1, 57, 3 },
                    { 10, 2, 33, 3 },
                    { 9, 1, 34, 3 },
                    { 8, 2, 33, 3 },
                    { 2, 2, 30, 3 },
                    { 53, 2, 68, 3 },
                    { 54, 1, 30, 3 },
                    { 55, 1, 39, 3 },
                    { 56, 2, 43, 3 },
                    { 95, 1, 35, 3 },
                    { 94, 2, 30, 3 },
                    { 93, 2, 36, 3 },
                    { 92, 2, 30, 3 },
                    { 91, 2, 34, 3 },
                    { 90, 1, 35, 3 },
                    { 89, 2, 49, 3 },
                    { 88, 1, 52, 3 },
                    { 87, 1, 45, 3 },
                    { 86, 1, 25, 3 },
                    { 76, 2, 32, 3 },
                    { 75, 2, 26, 3 },
                    { 115, 2, 26, 9 },
                    { 74, 1, 34, 3 },
                    { 72, 2, 37, 3 },
                    { 71, 1, 60, 3 },
                    { 70, 1, 57, 3 },
                    { 69, 1, 59, 3 },
                    { 68, 2, 52, 3 },
                    { 67, 1, 25, 3 },
                    { 66, 1, 52, 3 },
                    { 65, 2, 54, 3 },
                    { 64, 1, 37, 3 },
                    { 63, 1, 45, 3 },
                    { 58, 1, 37, 3 },
                    { 57, 1, 50, 3 },
                    { 73, 2, 21, 3 },
                    { 116, 1, 68, 9 }
                });

            migrationBuilder.InsertData(
                table: "PatientStatus",
                columns: new[] { "PatientStatusId", "PatientId", "PatientStatusDate", "StatusId" },
                values: new object[,]
                {
                    { 17, 17, new DateTime(2020, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 101, 101, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 1, 1, new DateTime(2020, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 117, 1, new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 3, 3, new DateTime(2020, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 119, 3, new DateTime(2020, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, 4, new DateTime(2020, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 120, 4, new DateTime(2020, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, 5, new DateTime(2020, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 121, 5, new DateTime(2020, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 6, 6, new DateTime(2020, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 122, 6, new DateTime(2020, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, 7, new DateTime(2020, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 123, 7, new DateTime(2020, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 12, 12, new DateTime(2020, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 14, 14, new DateTime(2020, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 22, 22, new DateTime(2020, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 23, 23, new DateTime(2020, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 100, 100, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 38, 38, new DateTime(2020, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 99, 99, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 97, 97, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 71, 71, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 72, 72, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 73, 73, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 74, 74, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 75, 75, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 76, 76, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 86, 86, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 87, 87, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 88, 88, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 89, 89, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 90, 90, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 91, 91, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 92, 92, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 93, 93, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 94, 94, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 95, 95, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 96, 96, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 116, 116, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 51, 51, new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 77, 77, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 78, 78, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 50, 50, new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 59, 59, new DateTime(2020, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 60, 60, new DateTime(2020, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 81, 81, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 82, 82, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 83, 83, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 84, 84, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 85, 85, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 107, 107, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 108, 108, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 109, 109, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 110, 110, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 111, 111, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 112, 112, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 113, 113, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 114, 114, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 115, 115, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 49, 49, new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 48, 48, new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 47, 47, new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 46, 46, new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 79, 79, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 80, 80, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 102, 102, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 103, 103, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 104, 104, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 61, 61, new DateTime(2020, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 15, 15, new DateTime(2020, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 62, 62, new DateTime(2020, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 70, 70, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 105, 105, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 13, 13, new DateTime(2020, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 24, 24, new DateTime(2020, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 32, 32, new DateTime(2020, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 33, 33, new DateTime(2020, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 34, 34, new DateTime(2020, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 35, 35, new DateTime(2020, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 36, 36, new DateTime(2020, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 37, 37, new DateTime(2020, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 106, 106, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 69, 69, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 98, 98, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 27, 27, new DateTime(2020, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 9, 9, new DateTime(2020, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 44, 44, new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 57, 57, new DateTime(2020, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 125, 9, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 39, 39, new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 56, 56, new DateTime(2020, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 20, 20, new DateTime(2020, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 40, 40, new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 55, 55, new DateTime(2020, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 10, 10, new DateTime(2020, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 126, 10, new DateTime(2020, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 54, 54, new DateTime(2020, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 41, 41, new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 53, 53, new DateTime(2020, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 19, 19, new DateTime(2020, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 52, 52, new DateTime(2020, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 11, 11, new DateTime(2020, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 42, 42, new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 45, 45, new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 16, 16, new DateTime(2020, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 18, 18, new DateTime(2020, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 21, 21, new DateTime(2020, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 58, 58, new DateTime(2020, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 43, 43, new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 31, 31, new DateTime(2020, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 68, 68, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 28, 28, new DateTime(2020, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 67, 67, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, new DateTime(2020, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 26, 26, new DateTime(2020, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 118, 2, new DateTime(2020, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 66, 66, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 65, 65, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 30, 30, new DateTime(2020, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 29, 29, new DateTime(2020, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 25, 25, new DateTime(2020, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, 8, new DateTime(2020, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 63, 63, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 64, 64, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 124, 8, new DateTime(2020, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.InsertData(
                table: "Test",
                columns: new[] { "TestId", "LabId", "PatientId", "TestDate", "TestResultId" },
                values: new object[,]
                {
                    { 21, 1, 21, new DateTime(2020, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 36, 1, 36, new DateTime(2020, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 26, 1, 26, new DateTime(2020, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 18, 1, 18, new DateTime(2020, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 15, 1, 15, new DateTime(2020, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 106, 1, 106, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 105, 1, 105, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 32, 1, 32, new DateTime(2020, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 20, 1, 20, new DateTime(2020, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 34, 1, 34, new DateTime(2020, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 19, 1, 19, new DateTime(2020, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 13, 1, 13, new DateTime(2020, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 62, 1, 62, new DateTime(2020, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 33, 1, 33, new DateTime(2020, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 25, 1, 25, new DateTime(2020, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 35, 1, 35, new DateTime(2020, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 24, 1, 24, new DateTime(2020, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 123, 2, 10, new DateTime(2020, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 16, 1, 16, new DateTime(2020, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 115, 1, 115, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 17, 1, 17, new DateTime(2020, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 114, 1, 114, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 113, 1, 113, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 112, 1, 112, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 1, 2, new DateTime(2020, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 111, 1, 111, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 118, 2, 2, new DateTime(2020, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 110, 1, 110, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 109, 1, 109, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 108, 1, 108, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, 1, 8, new DateTime(2020, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 107, 1, 107, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 121, 1, 8, new DateTime(2020, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 85, 1, 85, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 84, 1, 84, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 83, 1, 83, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 46, 1, 46, new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 47, 1, 47, new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 11, 1, 11, new DateTime(2020, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 48, 1, 48, new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 49, 1, 49, new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 61, 1, 61, new DateTime(2020, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 37, 1, 37, new DateTime(2020, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 50, 1, 50, new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 59, 1, 59, new DateTime(2020, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 60, 1, 60, new DateTime(2020, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 81, 1, 81, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 122, 1, 9, new DateTime(2020, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 82, 1, 82, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 9, 1, 9, new DateTime(2020, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 10, 1, 10, new DateTime(2020, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 69, 1, 69, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 77, 1, 77, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 27, 1, 27, new DateTime(2020, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 99, 1, 99, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 98, 1, 98, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 54, 1, 54, new DateTime(2020, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 97, 1, 97, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 96, 1, 96, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 55, 1, 55, new DateTime(2020, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 95, 1, 95, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 94, 1, 94, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 56, 1, 56, new DateTime(2020, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 93, 1, 93, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 92, 1, 92, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 57, 1, 57, new DateTime(2020, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 91, 1, 91, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 90, 1, 90, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 58, 1, 58, new DateTime(2020, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 89, 1, 89, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 88, 1, 88, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 70, 1, 70, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 67, 1, 67, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 71, 1, 71, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 72, 1, 72, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 66, 1, 66, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 73, 1, 73, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 53, 1, 53, new DateTime(2020, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 74, 1, 74, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 75, 1, 75, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 76, 1, 76, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 64, 1, 64, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 86, 1, 86, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 87, 1, 87, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 63, 1, 63, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 65, 1, 65, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 100, 1, 100, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 101, 1, 101, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 52, 1, 52, new DateTime(2020, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 22, 1, 22, new DateTime(2020, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 23, 1, 23, new DateTime(2020, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 31, 1, 31, new DateTime(2020, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 38, 1, 38, new DateTime(2020, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 51, 1, 51, new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 30, 1, 30, new DateTime(2020, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 39, 1, 39, new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 68, 1, 68, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 29, 1, 29, new DateTime(2020, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 79, 1, 79, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 80, 1, 80, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 28, 1, 28, new DateTime(2020, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 102, 1, 102, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 103, 1, 103, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 78, 1, 78, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 104, 1, 104, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 14, 1, 14, new DateTime(2020, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 40, 1, 40, new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 1, 1, 1, new DateTime(2020, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 117, 1, 1, new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 45, 1, 45, new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, 1, 3, new DateTime(2020, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 119, 2, 3, new DateTime(2020, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 44, 1, 44, new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 12, 1, 12, new DateTime(2020, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, 1, 4, new DateTime(2020, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, 1, 5, new DateTime(2020, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 120, 2, 5, new DateTime(2020, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 42, 1, 42, new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, 1, 6, new DateTime(2020, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 41, 1, 41, new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, 1, 7, new DateTime(2020, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 43, 1, 43, new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 116, 1, 116, new DateTime(2020, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patient_GenderId",
                table: "Patient",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_ProvinceId",
                table: "Patient",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientStatus_PatientId",
                table: "PatientStatus",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientStatus_StatusId",
                table: "PatientStatus",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Test_LabId",
                table: "Test",
                column: "LabId");

            migrationBuilder.CreateIndex(
                name: "IX_Test_PatientId",
                table: "Test",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Test_TestResultId",
                table: "Test",
                column: "TestResultId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientStatus");

            migrationBuilder.DropTable(
                name: "Test");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Lab");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "TestResult");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Province");
        }
    }
}
