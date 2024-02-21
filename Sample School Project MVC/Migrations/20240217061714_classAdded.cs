using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MYSchool.Migrations
{
    /// <inheritdoc />
    public partial class classAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Class",
                table: "NewStudents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Class",
                table: "NewStudents");
        }
    }
}
