using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb2.LINQ.Migrations
{
    public partial class AddedListCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Courses_CourseID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_CourseID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CourseID",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "StudentID",
                table: "Courses",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_StudentID",
                table: "Courses",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Students_StudentID",
                table: "Courses",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Students_StudentID",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_StudentID",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "CourseID",
                table: "Students",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_CourseID",
                table: "Students",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Courses_CourseID",
                table: "Students",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
