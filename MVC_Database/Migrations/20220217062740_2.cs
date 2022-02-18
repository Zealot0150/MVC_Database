using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Database.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languge",
                columns: table => new
                {
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languge", x => x.Name);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LangugePerson",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LangugePerson", x => new { x.PersonId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_LangugePerson_Languge_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languge",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LangugePerson_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Languge",
                column: "Name",
                value: "Svenska");

            migrationBuilder.InsertData(
                table: "Languge",
                column: "Name",
                value: "Tyska");

            migrationBuilder.CreateIndex(
                name: "IX_LangugePerson_LanguageId",
                table: "LangugePerson",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LangugePerson");

            migrationBuilder.DropTable(
                name: "Languge");
        }
    }
}
