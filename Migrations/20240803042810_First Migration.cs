using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepartmentTable",
                columns: table => new
                {
                    Dept_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dept_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentTable", x => x.Dept_Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTable",
                columns: table => new
                {
                    Emp_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Last_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dept_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTable", x => x.Emp_Id);
                    table.ForeignKey(
                        name: "FK_EmployeeTable_DepartmentTable_Dept_Id",
                        column: x => x.Dept_Id,
                        principalTable: "DepartmentTable",
                        principalColumn: "Dept_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalaryTable",
                columns: table => new
                {
                    Sal_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emp_Id = table.Column<int>(type: "int", nullable: false),
                    SalaryAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryTable", x => x.Sal_Id);
                    table.ForeignKey(
                        name: "FK_SalaryTable_EmployeeTable_Emp_Id",
                        column: x => x.Emp_Id,
                        principalTable: "EmployeeTable",
                        principalColumn: "Emp_Id",
                        onDelete: ReferentialAction.Cascade);
                });
            

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTable_Dept_Id",
                table: "EmployeeTable",
                column: "Dept_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryTable_Emp_Id",
                table: "SalaryTable",
                column: "Emp_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalaryTable");

            migrationBuilder.DropTable(
                name: "EmployeeTable");

            migrationBuilder.DropTable(
                name: "DepartmentTable");
        }
    }
}
