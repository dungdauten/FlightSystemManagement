using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FlightSystemManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "FlightNo",
                table: "FlightBookings",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "FlightNo",
                table: "FlightBookings");

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
    }
}
