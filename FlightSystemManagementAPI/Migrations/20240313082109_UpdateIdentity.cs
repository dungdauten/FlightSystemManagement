using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FlightSystemManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14adbc5e-d843-4b03-9908-b77d9516859b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3315d1d2-b257-47c8-8f49-b6e1bc5b4c20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de9fe912-87f2-4e72-82e0-326e495fb466");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e715d58c-3315-429a-a01d-9cdef6120907");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02a6e40c-83a1-4dd9-85cb-e02e00c62067", "1", "Phi công", "Phi công" },
                    { "24431f6e-9bbb-4d4e-934d-9cfdce0fb119", "1", "Tiếp viên", "Tiếp viên" },
                    { "42a33b6a-b754-414c-8f2e-5d1171f51692", "1", "Nhân viên Go", "Nhân viên Go" },
                    { "f4debb4a-881b-4fed-92a9-8d4f69a47d87", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02a6e40c-83a1-4dd9-85cb-e02e00c62067");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24431f6e-9bbb-4d4e-934d-9cfdce0fb119");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42a33b6a-b754-414c-8f2e-5d1171f51692");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4debb4a-881b-4fed-92a9-8d4f69a47d87");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "14adbc5e-d843-4b03-9908-b77d9516859b", "1", "Nhân viên Go", "Nhân viên Go" },
                    { "3315d1d2-b257-47c8-8f49-b6e1bc5b4c20", "1", "Admin", "Admin" },
                    { "de9fe912-87f2-4e72-82e0-326e495fb466", "1", "Tiếp viên", "Tiếp viên" },
                    { "e715d58c-3315-429a-a01d-9cdef6120907", "1", "Phi công", "Phi công" }
                });
        }
    }
}
