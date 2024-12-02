using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LocalizingDepartmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DName",
                table: "Departments",
                newName: "DNameEn");

            migrationBuilder.AddColumn<string>(
                name: "DNameAr",
                table: "Departments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DNameAr",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "DNameEn",
                table: "Departments",
                newName: "DName");
        }
    }
}
