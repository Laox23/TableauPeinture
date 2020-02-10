using Microsoft.EntityFrameworkCore.Migrations;

namespace TableauWeb.Migrations
{
    public partial class NomBaseImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "NomBase",
                table: "Images",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomBase",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Images",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
