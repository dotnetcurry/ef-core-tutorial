using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCoreApp.Migrations
{
    public partial class EFCoreAppCompanyEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DeptUniqueId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Capacity = table.Column<int>(nullable: false),
                    DeptName = table.Column<string>(maxLength: 20, nullable: false),
                    DeptNo = table.Column<int>(nullable: false),
                    Location = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DeptUniqueId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmpUniqueId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DeptUniqueId = table.Column<int>(nullable: false),
                    Designation = table.Column<string>(maxLength: 20, nullable: false),
                    EmpFirstName = table.Column<string>(maxLength: 80, nullable: false),
                    EmpLastName = table.Column<string>(maxLength: 80, nullable: true),
                    EmpNo = table.Column<int>(nullable: false),
                    Salary = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmpUniqueId);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DeptUniqueId",
                        column: x => x.DeptUniqueId,
                        principalTable: "Departments",
                        principalColumn: "DeptUniqueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DeptUniqueId",
                table: "Employees",
                column: "DeptUniqueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
