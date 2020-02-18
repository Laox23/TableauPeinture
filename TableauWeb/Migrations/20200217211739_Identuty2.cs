using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TableauWeb.Migrations
{
    public partial class Identuty2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "92f88a80-fa82-47ce-940d-0ce50da00f1e", "693776c7-99a6-414c-826a-5112a58319d7", "Utilisateur", "UTILISATEUR" },
                    { "8e377108-955c-44b8-8b03-ecf401397e2b", "5d44af32-0b7b-4cd4-89f3-34c05c09dc2f", "Redacteur", "REDACTEUR" },
                    { "e141f344-b4e7-4fa4-9709-50307e32b313", "03f96a87-90b4-42dc-807b-4c68085c892a", "Administrateur", "ADMINISTRATEUR" }
                });

            migrationBuilder.InsertData(
                table: "IdentityUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3e7ae52a-fe23-4750-861b-bbab19ca1c3c", 0, "23b0f039-c421-4cf6-87bf-d8b9193ff5f9", null, false, false, null, null, "Administrateur", null, null, false, "aa936f6a-a89a-4aa5-8dc3-f3ac9d3d21cf", false, "Administrateur" },
                    { "55db3efc-9894-425e-bc77-77c3cec9a7c8", 0, "f06ffd8a-3c9b-4e9e-af3b-e3b2624c9d93", null, false, false, null, null, "Redacteur", null, null, false, "cc1217e3-9b22-4a60-8ba7-4dcd58b3b48b", false, "Redacteur" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityUser");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e377108-955c-44b8-8b03-ecf401397e2b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92f88a80-fa82-47ce-940d-0ce50da00f1e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e141f344-b4e7-4fa4-9709-50307e32b313");
        }
    }
}
