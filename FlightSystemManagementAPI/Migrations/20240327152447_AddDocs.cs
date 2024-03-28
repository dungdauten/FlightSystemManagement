using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FlightSystemManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddDocs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "List<string>");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14ebd996-07b5-4817-86da-91984dcecc7a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55bd5796-eab3-40e9-965f-d2caa8e6952a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77b6c2ff-53cb-41bf-bf4e-53cc2f2bae21");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d93667ff-d604-4c91-88c5-aadc894bb649");

            migrationBuilder.AddColumn<int>(
                name: "PermissionGroupsGroupId",
                table: "AspNetRoles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DocRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocRoles_Documents_Id",
                        column: x => x.Id,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "PermissionGroupsGroupId" },
                values: new object[,]
                {
                    { "51df59d0-b1fd-4630-b59e-cfd2de1911e0", "1", "Nhân viên Go", "Nhân viên Go", null },
                    { "5f60473d-babd-42e0-b6cd-9c80ced2979b", "1", "Tiếp viên", "Tiếp viên", null },
                    { "69e424ac-0426-4e55-a324-6b050b08f0bc", "1", "Admin", "Admin", null },
                    { "f8732cfb-715e-43a0-8147-d2dd220b960e", "1", "Phi công", "Phi công", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_PermissionGroupsGroupId",
                table: "AspNetRoles",
                column: "PermissionGroupsGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoles_PermissionGroups_PermissionGroupsGroupId",
                table: "AspNetRoles",
                column: "PermissionGroupsGroupId",
                principalTable: "PermissionGroups",
                principalColumn: "GroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoles_PermissionGroups_PermissionGroupsGroupId",
                table: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "DocRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetRoles_PermissionGroupsGroupId",
                table: "AspNetRoles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51df59d0-b1fd-4630-b59e-cfd2de1911e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f60473d-babd-42e0-b6cd-9c80ced2979b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69e424ac-0426-4e55-a324-6b050b08f0bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8732cfb-715e-43a0-8147-d2dd220b960e");

            migrationBuilder.DropColumn(
                name: "PermissionGroupsGroupId",
                table: "AspNetRoles");

            migrationBuilder.CreateTable(
                name: "List<string>",
                columns: table => new
                {
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "14ebd996-07b5-4817-86da-91984dcecc7a", "1", "Tiếp viên", "Tiếp viên" },
                    { "55bd5796-eab3-40e9-965f-d2caa8e6952a", "1", "Admin", "Admin" },
                    { "77b6c2ff-53cb-41bf-bf4e-53cc2f2bae21", "1", "Nhân viên Go", "Nhân viên Go" },
                    { "d93667ff-d604-4c91-88c5-aadc894bb649", "1", "Phi công", "Phi công" }
                });
        }
    }
}
