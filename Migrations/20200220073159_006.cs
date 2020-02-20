using Microsoft.EntityFrameworkCore.Migrations;

namespace InternalControl.Migrations
{
    public partial class _006 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswersModel_TypeOfForm_TypeOfFormId",
                table: "AnswersModel");

            migrationBuilder.DropIndex(
                name: "IX_AnswersModel_TypeOfFormId",
                table: "AnswersModel");

            migrationBuilder.DropColumn(
                name: "TypeOfFormId",
                table: "AnswersModel");

            migrationBuilder.AddColumn<int>(
                name: "AnswerId",
                table: "Questions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_AnswerId",
                table: "Questions",
                column: "AnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_AnswersModel_AnswerId",
                table: "Questions",
                column: "AnswerId",
                principalTable: "AnswersModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_AnswersModel_AnswerId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_AnswerId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "AnswerId",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "TypeOfFormId",
                table: "AnswersModel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnswersModel_TypeOfFormId",
                table: "AnswersModel",
                column: "TypeOfFormId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswersModel_TypeOfForm_TypeOfFormId",
                table: "AnswersModel",
                column: "TypeOfFormId",
                principalTable: "TypeOfForm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
