using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FlightSystemManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class Permissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a2a51a7-f440-4054-8e71-f805779276ed");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69995768-ba12-47a7-98a1-4eabd8eee5a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f2bf0f7-b62b-4448-8391-32140c948944");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1a772d0-7512-4f55-b94a-b24d7a100b19");

            migrationBuilder.CreateTable(
                name: "PermissionGroups",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Roles = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionGroups", x => x.GroupId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1bcaba73-a642-4887-8634-a8e0b5a79ef6", "1", "Tiếp viên", "Tiếp viên" },
                    { "6a02b753-a0e7-4860-ace8-413baf2bfe9f", "1", "Phi công", "Phi công" },
                    { "7ca822ac-2dce-47df-8a37-98f5755fc90a", "1", "Admin", "Admin" },
                    { "95f23b1e-0bc7-411b-aae3-622f92db5740", "1", "Nhân viên Go", "Nhân viên Go" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermissionGroups");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bcaba73-a642-4887-8634-a8e0b5a79ef6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a02b753-a0e7-4860-ace8-413baf2bfe9f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ca822ac-2dce-47df-8a37-98f5755fc90a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95f23b1e-0bc7-411b-aae3-622f92db5740");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3a2a51a7-f440-4054-8e71-f805779276ed", "1", "Tiếp viên", "Tiếp viên" },
                    { "69995768-ba12-47a7-98a1-4eabd8eee5a9", "1", "Admin", "Admin" },
                    { "6f2bf0f7-b62b-4448-8391-32140c948944", "1", "Nhân viên Go", "Nhân viên Go" },
                    { "a1a772d0-7512-4f55-b94a-b24d7a100b19", "1", "Phi công", "Phi công" }
                });
        }
    }
}
