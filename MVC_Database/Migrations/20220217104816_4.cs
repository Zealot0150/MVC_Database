using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Database.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LangugePerson",
                columns: new[] { "LanguageId", "PersonId" },
                values: new object[] { "Svenska", 1 });

            migrationBuilder.InsertData(
                table: "LangugePerson",
                columns: new[] { "LanguageId", "PersonId" },
                values: new object[] { "Tyska", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LangugePerson",
                keyColumns: new[] { "LanguageId", "PersonId" },
                keyValues: new object[] { "Svenska", 1 });

            migrationBuilder.DeleteData(
                table: "LangugePerson",
                keyColumns: new[] { "LanguageId", "PersonId" },
                keyValues: new object[] { "Tyska", 2 });
        }
    }
}
