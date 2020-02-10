using Microsoft.EntityFrameworkCore.Migrations;

namespace TableauWeb.Migrations
{
    public partial class AjoutMaxImpression : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxImpression",
                table: "Images",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxImpression",
                table: "Images");
        }
    }
}
