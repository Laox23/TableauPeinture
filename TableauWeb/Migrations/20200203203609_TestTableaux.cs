using Microsoft.EntityFrameworkCore.Migrations;

namespace TableauWeb.Migrations
{
    public partial class TestTableaux : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tableau_Dimension_DimensionId",
                table: "Tableau");

            migrationBuilder.DropForeignKey(
                name: "FK_Tableau_Finitions_FinitionId",
                table: "Tableau");

            migrationBuilder.DropForeignKey(
                name: "FK_Tableau_ImageTableau_ImageId",
                table: "Tableau");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tableau",
                table: "Tableau");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageTableau",
                table: "ImageTableau");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dimension",
                table: "Dimension");

            migrationBuilder.RenameTable(
                name: "Tableau",
                newName: "Tableaux");

            migrationBuilder.RenameTable(
                name: "ImageTableau",
                newName: "Images");

            migrationBuilder.RenameTable(
                name: "Dimension",
                newName: "Dimensions");

            migrationBuilder.RenameIndex(
                name: "IX_Tableau_ImageId",
                table: "Tableaux",
                newName: "IX_Tableaux_ImageId");

            migrationBuilder.RenameIndex(
                name: "IX_Tableau_FinitionId",
                table: "Tableaux",
                newName: "IX_Tableaux_FinitionId");

            migrationBuilder.RenameIndex(
                name: "IX_Tableau_DimensionId",
                table: "Tableaux",
                newName: "IX_Tableaux_DimensionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tableaux",
                table: "Tableaux",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dimensions",
                table: "Dimensions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tableaux_Dimensions_DimensionId",
                table: "Tableaux",
                column: "DimensionId",
                principalTable: "Dimensions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tableaux_Finitions_FinitionId",
                table: "Tableaux",
                column: "FinitionId",
                principalTable: "Finitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tableaux_Images_ImageId",
                table: "Tableaux",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tableaux_Dimensions_DimensionId",
                table: "Tableaux");

            migrationBuilder.DropForeignKey(
                name: "FK_Tableaux_Finitions_FinitionId",
                table: "Tableaux");

            migrationBuilder.DropForeignKey(
                name: "FK_Tableaux_Images_ImageId",
                table: "Tableaux");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tableaux",
                table: "Tableaux");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dimensions",
                table: "Dimensions");

            migrationBuilder.RenameTable(
                name: "Tableaux",
                newName: "Tableau");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "ImageTableau");

            migrationBuilder.RenameTable(
                name: "Dimensions",
                newName: "Dimension");

            migrationBuilder.RenameIndex(
                name: "IX_Tableaux_ImageId",
                table: "Tableau",
                newName: "IX_Tableau_ImageId");

            migrationBuilder.RenameIndex(
                name: "IX_Tableaux_FinitionId",
                table: "Tableau",
                newName: "IX_Tableau_FinitionId");

            migrationBuilder.RenameIndex(
                name: "IX_Tableaux_DimensionId",
                table: "Tableau",
                newName: "IX_Tableau_DimensionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tableau",
                table: "Tableau",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageTableau",
                table: "ImageTableau",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dimension",
                table: "Dimension",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tableau_Dimension_DimensionId",
                table: "Tableau",
                column: "DimensionId",
                principalTable: "Dimension",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tableau_Finitions_FinitionId",
                table: "Tableau",
                column: "FinitionId",
                principalTable: "Finitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tableau_ImageTableau_ImageId",
                table: "Tableau",
                column: "ImageId",
                principalTable: "ImageTableau",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
