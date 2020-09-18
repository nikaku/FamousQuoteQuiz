using Microsoft.EntityFrameworkCore.Migrations;

namespace FamousQuoteQuiz.DB.Migrations
{
    public partial class renamedQuestionAutors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestinAuthors");

            migrationBuilder.CreateTable(
                name: "QuestionAuthors",
                columns: table => new
                {
                    QuestionId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionAuthors", x => new { x.AuthorId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_QuestionAuthors_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionAuthors_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAuthors_QuestionId",
                table: "QuestionAuthors",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionAuthors");

            migrationBuilder.CreateTable(
                name: "QuestinAuthors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
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
    }
}
