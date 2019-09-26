using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkUdemy.Migrations
{
    public partial class NoCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Authors_AuthorId",
                table: "Courses");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Authors_AuthorId",
                table: "Courses",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Authors_AuthorId",
                table: "Courses");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Authors_AuthorId",
                table: "Courses",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
