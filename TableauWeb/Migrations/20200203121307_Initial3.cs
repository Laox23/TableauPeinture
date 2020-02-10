using Microsoft.EntityFrameworkCore.Migrations;

namespace TableauWeb.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tableau",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageId = table.Column<int>(nullable: true),
                    DimensionId = table.Column<int>(nullable: true),
                    FinitionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tableau", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tableau_Dimension_DimensionId",
                        column: x => x.DimensionId,
                        principalTable: "Dimension",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tableau_Finitions_FinitionId",
                        column: x => x.FinitionId,
                        principalTable: "Finitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tableau_ImageTableau_ImageId",
                        column: x => x.ImageId,
                        principalTable: "ImageTableau",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tableau_DimensionId",
                table: "Tableau",
                column: "DimensionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tableau_FinitionId",
                table: "Tableau",
                column: "FinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tableau_ImageId",
                table: "Tableau",
                column: "ImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tableau");
        }
    }
}
