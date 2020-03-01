using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TableauWeb.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tableaux_AspNetUsers_UtilisateurId",
                table: "Tableaux");

            migrationBuilder.DropIndex(
                name: "IX_Tableaux_UtilisateurId",
                table: "Tableaux");

            migrationBuilder.AlterColumn<int>(
                name: "UtilisateurId",
                table: "Tableaux",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodeVerif",
                table: "Tableaux",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreation",
                table: "Tableaux",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UtilisateurId1",
                table: "Tableaux",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tableaux_UtilisateurId1",
                table: "Tableaux",
                column: "UtilisateurId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tableaux_AspNetUsers_UtilisateurId1",
                table: "Tableaux",
                column: "UtilisateurId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tableaux_AspNetUsers_UtilisateurId1",
                table: "Tableaux");

            migrationBuilder.DropIndex(
                name: "IX_Tableaux_UtilisateurId1",
                table: "Tableaux");

            migrationBuilder.DropColumn(
                name: "CodeVerif",
                table: "Tableaux");

            migrationBuilder.DropColumn(
                name: "DateCreation",
                table: "Tableaux");

            migrationBuilder.DropColumn(
                name: "UtilisateurId1",
                table: "Tableaux");

            migrationBuilder.AlterColumn<string>(
                name: "UtilisateurId",
                table: "Tableaux",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Tableaux_UtilisateurId",
                table: "Tableaux",
                column: "UtilisateurId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tableaux_AspNetUsers_UtilisateurId",
                table: "Tableaux",
                column: "UtilisateurId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
