using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Migrations
{
    /// <inheritdoc />
    public partial class EigthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_RoleTable_Emp_Id",
                table: "RoleTable",
                column: "Emp_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleTable_EmployeeTable_Emp_Id",
                table: "RoleTable",
                column: "Emp_Id",
                principalTable: "EmployeeTable",
                principalColumn: "Emp_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleTable_EmployeeTable_Emp_Id",
                table: "RoleTable");

            migrationBuilder.DropIndex(
                name: "IX_RoleTable_Emp_Id",
                table: "RoleTable");
        }
    }
}
