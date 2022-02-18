using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Database.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LangugePerson_Languge_LanguageId",
                table: "LangugePerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Languge",
                table: "Languge");

            migrationBuilder.RenameTable(
                name: "Languge",
                newName: "Language");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Language",
                table: "Language",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_LangugePerson_Language_LanguageId",
                table: "LangugePerson",
                column: "LanguageId",
                principalTable: "Language",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LangugePerson_Language_LanguageId",
                table: "LangugePerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Language",
                table: "Language");

            migrationBuilder.RenameTable(
                name: "Language",
                newName: "Languge");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Languge",
                table: "Languge",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_LangugePerson_Languge_LanguageId",
                table: "LangugePerson",
                column: "LanguageId",
                principalTable: "Languge",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
