using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkUdemy.Migrations
{
    public partial class ChangeCourseDescriptionLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Courses",
                maxLength: 2500,
                nullable: false,
                defaultValue: "Default",
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldDefaultValue: "Default");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Courses",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "Default",
                oldClrType: typeof(string),
                oldMaxLength: 2500,
                oldDefaultValue: "Default");
        }
    }
}
