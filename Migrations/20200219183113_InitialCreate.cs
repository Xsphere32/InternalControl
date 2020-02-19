using Microsoft.EntityFrameworkCore.Migrations;

namespace InternalControl.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupOfIndicators",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupOfIndicators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfForm",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfForm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Indicators",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    GroupOfIndicatorsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indicators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Indicators_GroupOfIndicators_GroupOfIndicatorsId",
                        column: x => x.GroupOfIndicatorsId,
                        principalTable: "GroupOfIndicators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    GroupOfIndicatorsId = table.Column<int>(nullable: true),
                    IndicatorsId = table.Column<int>(nullable: true),
                    Answer = table.Column<bool>(nullable: false),
                    TypeOfFormId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_GroupOfIndicators_GroupOfIndicatorsId",
                        column: x => x.GroupOfIndicatorsId,
                        principalTable: "GroupOfIndicators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Questions_Indicators_IndicatorsId",
                        column: x => x.IndicatorsId,
                        principalTable: "Indicators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Questions_TypeOfForm_TypeOfFormId",
                        column: x => x.TypeOfFormId,
                        principalTable: "TypeOfForm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Indicators_GroupOfIndicatorsId",
                table: "Indicators",
                column: "GroupOfIndicatorsId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_GroupOfIndicatorsId",
                table: "Questions",
                column: "GroupOfIndicatorsId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_IndicatorsId",
                table: "Questions",
                column: "IndicatorsId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TypeOfFormId",
                table: "Questions",
                column: "TypeOfFormId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Indicators");

            migrationBuilder.DropTable(
                name: "TypeOfForm");

            migrationBuilder.DropTable(
                name: "GroupOfIndicators");
        }
    }
}
