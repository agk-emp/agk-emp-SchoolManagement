using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InstructorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentStudID",
                table: "StudentSubjects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InsManager",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    InsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ENameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ENameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupervisorId = table.Column<int>(type: "int", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.InsId);
                    table.ForeignKey(
                        name: "FK_Instructor_Departments_DID",
                        column: x => x.DID,
                        principalTable: "Departments",
                        principalColumn: "DID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Instructor_Instructor_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "Instructor",
                        principalColumn: "InsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ins_Subject",
                columns: table => new
                {
                    InsId = table.Column<int>(type: "int", nullable: false),
                    SubId = table.Column<int>(type: "int", nullable: false),
                    InstructorInsId = table.Column<int>(type: "int", nullable: true),
                    SubjectsSubID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ins_Subject", x => new { x.SubId, x.InsId });
                    table.ForeignKey(
                        name: "FK_Ins_Subject_Instructor_InsId",
                        column: x => x.InsId,
                        principalTable: "Instructor",
                        principalColumn: "InsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ins_Subject_Instructor_InstructorInsId",
                        column: x => x.InstructorInsId,
                        principalTable: "Instructor",
                        principalColumn: "InsId");
                    table.ForeignKey(
                        name: "FK_Ins_Subject_Subjectss_SubId",
                        column: x => x.SubId,
                        principalTable: "Subjectss",
                        principalColumn: "SubID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ins_Subject_Subjectss_SubjectsSubID",
                        column: x => x.SubjectsSubID,
                        principalTable: "Subjectss",
                        principalColumn: "SubID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubjects_StudentStudID",
                table: "StudentSubjects",
                column: "StudentStudID");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_InsManager",
                table: "Departments",
                column: "InsManager",
                unique: true,
                filter: "[InsManager] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Ins_Subject_InsId",
                table: "Ins_Subject",
                column: "InsId");

            migrationBuilder.CreateIndex(
                name: "IX_Ins_Subject_InstructorInsId",
                table: "Ins_Subject",
                column: "InstructorInsId");

            migrationBuilder.CreateIndex(
                name: "IX_Ins_Subject_SubjectsSubID",
                table: "Ins_Subject",
                column: "SubjectsSubID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_DID",
                table: "Instructor",
                column: "DID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_SupervisorId",
                table: "Instructor",
                column: "SupervisorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Instructor_InsManager",
                table: "Departments",
                column: "InsManager",
                principalTable: "Instructor",
                principalColumn: "InsId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Students_StudentStudID",
                table: "StudentSubjects",
                column: "StudentStudID",
                principalTable: "Students",
                principalColumn: "StudID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Instructor_InsManager",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Students_StudentStudID",
                table: "StudentSubjects");

            migrationBuilder.DropTable(
                name: "Ins_Subject");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropIndex(
                name: "IX_StudentSubjects_StudentStudID",
                table: "StudentSubjects");

            migrationBuilder.DropIndex(
                name: "IX_Departments_InsManager",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "StudentStudID",
                table: "StudentSubjects");

            migrationBuilder.DropColumn(
                name: "InsManager",
                table: "Departments");
        }
    }
}
