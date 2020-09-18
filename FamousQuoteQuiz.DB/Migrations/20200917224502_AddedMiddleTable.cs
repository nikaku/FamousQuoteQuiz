using Microsoft.EntityFrameworkCore.Migrations;

namespace FamousQuoteQuiz.DB.Migrations
{
    public partial class AddedMiddleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "QuestinAuthors",
                columns: table => new
                {
                    QuestionId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestinAuthors", x => new { x.AuthorId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_QuestinAuthors_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestinAuthors_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestinAuthors_QuestionId",
                table: "QuestinAuthors",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestinAuthors");

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "Authors",
                type: "int",
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
    }
}
