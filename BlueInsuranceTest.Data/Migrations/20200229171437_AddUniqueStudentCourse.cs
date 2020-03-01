using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueInsuranceTest.Data.Migrations
{
    public partial class AddUniqueStudentCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentCourse_CourseId",
                table: "StudentCourse");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_CourseId_StudentId",
                table: "StudentCourse",
                columns: new[] { "CourseId", "StudentId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentCourse_CourseId_StudentId",
                table: "StudentCourse");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_CourseId",
                table: "StudentCourse",
                column: "CourseId");
        }
    }
}
