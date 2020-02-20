using Microsoft.EntityFrameworkCore.Migrations;

namespace InternalControl.Migrations
{
    public partial class _005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnswersModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Answer = table.Column<bool>(nullable: false),
                    TypeOfFormId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswersModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswersModel_TypeOfForm_TypeOfFormId",
                        column: x => x.TypeOfFormId,
                        principalTable: "TypeOfForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswersModel_TypeOfFormId",
                table: "AnswersModel",
                column: "TypeOfFormId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswersModel");
        }
    }
}
