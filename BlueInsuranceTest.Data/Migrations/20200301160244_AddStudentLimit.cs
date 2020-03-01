using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueInsuranceTest.Data.Migrations
{
    public partial class AddStudentLimit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentLimit",
                table: "Course",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentLimit",
                table: "Course");
        }
    }
}
