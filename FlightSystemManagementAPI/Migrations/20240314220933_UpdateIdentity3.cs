using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FlightSystemManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIdentity3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94170890-5945-4965-9a47-372aa5167b96");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97541a90-3ed3-48d3-b53a-755b9b7b73ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b349c65c-864d-4b98-a739-91305907d871");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7877b86-2785-48f4-93ba-3db2dd2572ec");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01218737-8ad0-4d50-9d6a-b0142ba8c430", "1", "Nhân viên Go", "Nhân viên Go" },
                    { "575321e6-54f3-4904-bbb2-e15e59234c60", "1", "Phi công", "Phi công" },
                    { "652a898f-2166-4af1-9f3e-12706eafbd21", "1", "Tiếp viên", "Tiếp viên" },
                    { "e9b60f9f-6d56-4203-83bd-f5d70e9f27d5", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01218737-8ad0-4d50-9d6a-b0142ba8c430");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "575321e6-54f3-4904-bbb2-e15e59234c60");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "652a898f-2166-4af1-9f3e-12706eafbd21");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9b60f9f-6d56-4203-83bd-f5d70e9f27d5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "94170890-5945-4965-9a47-372aa5167b96", "1", "Nhân viên Go", "Nhân viên Go" },
                    { "97541a90-3ed3-48d3-b53a-755b9b7b73ff", "1", "Phi công", "Phi công" },
                    { "b349c65c-864d-4b98-a739-91305907d871", "1", "Admin", "Admin" },
                    { "b7877b86-2785-48f4-93ba-3db2dd2572ec", "1", "Tiếp viên", "Tiếp viên" }
                });
        }
    }
}
