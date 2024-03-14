using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FlightSystemManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIdentity2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a723e04-8f4d-493e-8d0c-ff9091455040");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6567b323-fc90-4e9a-b69a-645ad59a8fc0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c4bdadb-3721-4ee2-a623-10b4d704f954");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "898a7d9a-2161-4c09-80c4-99649a117b82");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0bca8133-1436-4867-8e59-574af6329dda", "1", "Nhân viên Go", "Nhân viên Go" },
                    { "5dab5785-df43-465d-a9df-008d9bae7543", "1", "Tiếp viên", "Tiếp viên" },
                    { "9914f737-2dcc-4f88-8b3e-13aa0074d30c", "1", "Admin", "Admin" },
                    { "d5394c2b-6595-4c5f-834c-99c9d1c4f4af", "1", "Phi công", "Phi công" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0bca8133-1436-4867-8e59-574af6329dda");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5dab5785-df43-465d-a9df-008d9bae7543");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9914f737-2dcc-4f88-8b3e-13aa0074d30c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5394c2b-6595-4c5f-834c-99c9d1c4f4af");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a723e04-8f4d-493e-8d0c-ff9091455040", "1", "Phi công", "Phi công" },
                    { "6567b323-fc90-4e9a-b69a-645ad59a8fc0", "1", "Nhân viên Go", "Nhân viên Go" },
                    { "6c4bdadb-3721-4ee2-a623-10b4d704f954", "1", "Admin", "Admin" },
                    { "898a7d9a-2161-4c09-80c4-99649a117b82", "1", "Tiếp viên", "Tiếp viên" }
                });
        }
    }
}
