using Microsoft.EntityFrameworkCore.Migrations;

namespace FamousQuoteQuiz.DB.Migrations
{
    public partial class AddedEstimates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "Authors",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Authors_QuestionId",
                table: "Authors",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Questions_QuestionId",
                table: "Authors",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Questions_QuestionId",
                table: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Authors_QuestionId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Authors");
        }
    }
}
