using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Database.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3a34d5ee-6ab4-4668-b37f-08d567d3463f", "12631fdd-4e87-4ecb-a02d-71616c8e1455", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4c5d4865-a2db-4b31-a2e6-29b7055a6742", "82fe4540-3a29-43f7-9e71-856ca165d3b6", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Age", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "75e2f0c7-e448-4750-acc6-52ec7c7c4300", 0, 294, "ec5971c7-635c-4b45-85ee-b225aa3b0a36", "admin@admin.com", false, "Admin", "Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEDLtwbTKDUjy4+wbFzV35plZgvwLYFi5VqwO8DuvG5jsimttbLHOfx4KSrV5XnwyZQ==", null, false, "2774ec11-fda7-46c9-a95b-e26a435db272", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4c5d4865-a2db-4b31-a2e6-29b7055a6742", "75e2f0c7-e448-4750-acc6-52ec7c7c4300" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a34d5ee-6ab4-4668-b37f-08d567d3463f");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4c5d4865-a2db-4b31-a2e6-29b7055a6742", "75e2f0c7-e448-4750-acc6-52ec7c7c4300" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c5d4865-a2db-4b31-a2e6-29b7055a6742");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75e2f0c7-e448-4750-acc6-52ec7c7c4300");
        }
    }
}
