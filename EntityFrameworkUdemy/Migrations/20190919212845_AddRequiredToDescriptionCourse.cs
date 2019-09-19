using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkUdemy.Migrations
{
    public partial class AddRequiredToDescriptionCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Courses",
                nullable: false,
                defaultValue: "Default",
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Courses",
                nullable: true,
                oldClrType: typeof(string),
                oldDefaultValue: "Default");
        }
    }
}
