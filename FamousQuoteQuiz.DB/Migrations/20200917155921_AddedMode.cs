using Microsoft.EntityFrameworkCore.Migrations;

namespace FamousQuoteQuiz.DB.Migrations
{
    public partial class AddedMode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Mode",
                table: "Games",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mode",
                table: "Games");
        }
    }
}
