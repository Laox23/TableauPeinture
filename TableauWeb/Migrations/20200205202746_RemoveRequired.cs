using Microsoft.EntityFrameworkCore.Migrations;

namespace TableauWeb.Migrations
{
    public partial class RemoveRequired : Migration
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

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "Tableaux",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FinitionId",
                table: "Tableaux",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DimensionId",
                table: "Tableaux",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "Tableaux",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FinitionId",
                table: "Tableaux",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DimensionId",
                table: "Tableaux",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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
    }
}
