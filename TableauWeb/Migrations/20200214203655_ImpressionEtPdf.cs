using Microsoft.EntityFrameworkCore.Migrations;

namespace TableauWeb.Migrations
{
    public partial class ImpressionEtPdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Tableaux_ImageId",
                table: "Tableaux");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Finitions",
                table: "Finitions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dimensions",
                table: "Dimensions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Tableaux");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Tableaux");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Finitions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Dimensions");

            migrationBuilder.AlterColumn<int>(
                name: "NombreImpression",
                table: "Tableaux",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "FinitionId",
                table: "Tableaux",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DimensionId",
                table: "Tableaux",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TableauId",
                table: "Tableaux",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ImageTableauId",
                table: "Tableaux",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NomPdf",
                table: "Tableaux",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "NomBase",
                table: "Images",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Images",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "MaxImpression",
                table: "Images",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "ImageTableauId",
                table: "Images",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<bool>(
                name: "EstActif",
                table: "Images",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Finitions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "FinitionId",
                table: "Finitions",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<bool>(
                name: "EstActif",
                table: "Finitions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Dimensions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Largeur",
                table: "Dimensions",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "Hauteur",
                table: "Dimensions",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "DimensionId",
                table: "Dimensions",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<bool>(
                name: "EstActif",
                table: "Dimensions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tableaux",
                table: "Tableaux",
                column: "TableauId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "ImageTableauId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Finitions",
                table: "Finitions",
                column: "FinitionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dimensions",
                table: "Dimensions",
                column: "DimensionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tableaux_ImageTableauId",
                table: "Tableaux",
                column: "ImageTableauId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tableaux_Dimensions_DimensionId",
                table: "Tableaux",
                column: "DimensionId",
                principalTable: "Dimensions",
                principalColumn: "DimensionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tableaux_Finitions_FinitionId",
                table: "Tableaux",
                column: "FinitionId",
                principalTable: "Finitions",
                principalColumn: "FinitionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tableaux_Images_ImageTableauId",
                table: "Tableaux",
                column: "ImageTableauId",
                principalTable: "Images",
                principalColumn: "ImageTableauId",
                onDelete: ReferentialAction.Cascade);
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
                name: "FK_Tableaux_Images_ImageTableauId",
                table: "Tableaux");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tableaux",
                table: "Tableaux");

            migrationBuilder.DropIndex(
                name: "IX_Tableaux_ImageTableauId",
                table: "Tableaux");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Finitions",
                table: "Finitions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dimensions",
                table: "Dimensions");

            migrationBuilder.DropColumn(
                name: "TableauId",
                table: "Tableaux");

            migrationBuilder.DropColumn(
                name: "ImageTableauId",
                table: "Tableaux");

            migrationBuilder.DropColumn(
                name: "NomPdf",
                table: "Tableaux");

            migrationBuilder.DropColumn(
                name: "ImageTableauId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "EstActif",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "FinitionId",
                table: "Finitions");

            migrationBuilder.DropColumn(
                name: "EstActif",
                table: "Finitions");

            migrationBuilder.DropColumn(
                name: "DimensionId",
                table: "Dimensions");

            migrationBuilder.DropColumn(
                name: "EstActif",
                table: "Dimensions");

            migrationBuilder.AlterColumn<int>(
                name: "NombreImpression",
                table: "Tableaux",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "FinitionId",
                table: "Tableaux",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DimensionId",
                table: "Tableaux",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Tableaux",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Tableaux",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "NomBase",
                table: "Images",
                type: "text",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Images",
                type: "text",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "MaxImpression",
                table: "Images",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Images",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Finitions",
                type: "text",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Finitions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Dimensions",
                type: "text",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "Largeur",
                table: "Dimensions",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Hauteur",
                table: "Dimensions",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Dimensions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tableaux",
                table: "Tableaux",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Finitions",
                table: "Finitions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dimensions",
                table: "Dimensions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tableaux_ImageId",
                table: "Tableaux",
                column: "ImageId");

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
