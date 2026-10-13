using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Company_Mangement_System.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Budget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeProjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    AssignedRole = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AssignedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeProjects_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "Building A", "Human Resources" },
                    { 2, "Building B", "IT" },
                    { 3, "Building C", "Finance" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DepartmentId", "Email", "FullName", "HireDate", "Salary" },
                values: new object[,]
                {
                    { 1, 1, "john.doe@example.com", "John Doe", new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 50000m },
                    { 2, 2, "jane.smith@example.com", "Jane Smith", new DateTime(2023, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 60000m },
                    { 3, 3, "alice.johnson@example.com", "Alice Johnson", new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 70000m },
                    { 4, 1, "bob.brown@example.com", "Bob Brown", new DateTime(2025, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 80000m },
                    { 5, 2, "charlie.davis@example.com", "Charlie Davis", new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 90000m },
                    { 6, 3, "diana.evans@example.com", "Diana Evans", new DateTime(2023, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 100000m },
                    { 7, 1, "ethan.foster@example.com", "Ethan Foster", new DateTime(2023, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 110000m },
                    { 8, 2, "fiona.green@example.com", "Fiona Green", new DateTime(2023, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 120000m }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Budget", "DepartmentId", "Description", "Name", "StartDate" },
                values: new object[,]
                {
                    { 1, 50000m, 1, "Description for Project Alpha", "Project Alpha", new DateTime(2026, 9, 13, 12, 1, 4, 397, DateTimeKind.Local).AddTicks(7307) },
                    { 2, 75000m, 2, "Description for Project Beta", "Project Beta", new DateTime(2026, 9, 23, 12, 1, 4, 397, DateTimeKind.Local).AddTicks(7352) },
                    { 3, 100000m, 3, "Description for Project Gamma", "Project Gamma", new DateTime(2026, 10, 3, 12, 1, 4, 397, DateTimeKind.Local).AddTicks(7356) },
                    { 4, 120000m, 1, "Description for Project Delta", "Project Delta", new DateTime(2026, 10, 8, 12, 1, 4, 397, DateTimeKind.Local).AddTicks(7359) }
                });

            migrationBuilder.InsertData(
                table: "EmployeeProjects",
                columns: new[] { "Id", "AssignedDate", "AssignedRole", "EmployeeId", "ProjectId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 10, 3, 12, 1, 4, 397, DateTimeKind.Local).AddTicks(7386), "Developer", 1, 1 },
                    { 2, new DateTime(2026, 10, 8, 12, 1, 4, 397, DateTimeKind.Local).AddTicks(7390), "Tester", 2, 2 },
                    { 3, new DateTime(2026, 9, 28, 12, 1, 4, 397, DateTimeKind.Local).AddTicks(7392), "Manager", 3, 3 },
                    { 4, new DateTime(2026, 9, 23, 12, 1, 4, 397, DateTimeKind.Local).AddTicks(7395), "Designer", 4, 4 },
                    { 5, new DateTime(2026, 10, 5, 12, 1, 4, 397, DateTimeKind.Local).AddTicks(7397), "Developer", 5, 1 },
                    { 6, new DateTime(2026, 10, 1, 12, 1, 4, 397, DateTimeKind.Local).AddTicks(7400), "Tester", 6, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProjects_EmployeeId",
                table: "EmployeeProjects",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeProjects_ProjectId",
                table: "EmployeeProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_DepartmentId",
                table: "Projects",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "EmployeeProjects");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
