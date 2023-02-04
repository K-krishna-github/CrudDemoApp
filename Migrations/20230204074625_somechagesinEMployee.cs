using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudDemoApp.Migrations
{
    /// <inheritdoc />
    public partial class somechagesinEMployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Roles_FkRole",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_FkRole",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "FkRole",
                table: "Employees");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_FkRoleId",
                table: "Employees",
                column: "FkRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Roles_FkRoleId",
                table: "Employees",
                column: "FkRoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Roles_FkRoleId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_FkRoleId",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "FkRole",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_FkRole",
                table: "Employees",
                column: "FkRole");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Roles_FkRole",
                table: "Employees",
                column: "FkRole",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
