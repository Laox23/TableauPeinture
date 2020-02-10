using Microsoft.EntityFrameworkCore.Migrations;

namespace TableauWeb.Migrations
{
    public partial class AjoutDataAnnotation : Migration
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

            migrationBuilder.DropColumn(
                name: "X",
                table: "Dimensions");

            migrationBuilder.DropColumn(
                name: "Y",
                table: "Dimensions");

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "Tableaux",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FinitionId",
                table: "Tableaux",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DimensionId",
                table: "Tableaux",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nom",
                table: "Tableaux",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Images",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Images",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Finitions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Hauteur",
                table: "Dimensions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Largeur",
                table: "Dimensions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nom",
                table: "Dimensions",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Tableaux_Dimensions_DimensionId",
                table: "Tableaux",
                column: "DimensionId",
                principalTable: "Dimensions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tableaux_Finitions_FinitionId",
                table: "Tableaux",
                column: "FinitionId",
                principalTable: "Finitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tableaux_Images_ImageId",
                table: "Tableaux",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
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
                name: "FK_Tableaux_Images_ImageId",
                table: "Tableaux");

            migrationBuilder.DropColumn(
                name: "Nom",
                table: "Tableaux");

            migrationBuilder.DropColumn(
                name: "Hauteur",
                table: "Dimensions");

            migrationBuilder.DropColumn(
                name: "Largeur",
                table: "Dimensions");

            migrationBuilder.DropColumn(
                name: "Nom",
                table: "Dimensions");

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "Tableaux",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "FinitionId",
                table: "Tableaux",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DimensionId",
                table: "Tableaux",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Images",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Images",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Finitions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "X",
                table: "Dimensions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Y",
                table: "Dimensions",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
