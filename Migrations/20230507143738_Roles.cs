using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace url_shortener.Migrations
{
    /// <inheritdoc />
    public partial class Roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Urls_AspNetUsers_UserId",
                table: "Urls");

            migrationBuilder.DropIndex(
                name: "IX_Urls_UserId",
                table: "Urls");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Urls");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Urls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "567622b0-bba7-4734-9648-6a47e133a48c", null, "User", "USER" },
                    { "dec2a85e-3612-4b81-b3fe-310dc4e2ecf8", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a9a95ad9-4487-455a-8c3c-77836f06c110", 0, "c7882afb-b97b-47d8-a113-b8dabff2ef2a", null, false, false, null, null, "USER", "AQAAAAIAAYagAAAAEA4BZAZc2wRtBE+8Q0Zec2IDXWt2gAGYGq/iWl1E7rs/dLVjGWp+MIg+gNUi+71jqg==", null, false, "d23107c1-0259-498b-b635-b1a64ba1538f", false, "user" },
                    { "ccd1772b-7962-4803-a18a-2526dc41430d", 0, "a7d2d714-54c9-4041-8f58-966d2bf82744", null, false, false, null, null, "ADMIN", "AQAAAAIAAYagAAAAEF/FZC1N4MC8xKXLTltpcOOK2JPktCXe7OtZ1a7EarR8NTZ1wLrUMnO/pJbHNRwwlA==", null, false, "2e48619f-b06d-40ea-8f98-72ef96580438", false, "admin" }
                });

            migrationBuilder.UpdateData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserName",
                value: "admin");

            migrationBuilder.UpdateData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserName",
                value: "user");

            migrationBuilder.UpdateData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserName",
                value: "user");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "567622b0-bba7-4734-9648-6a47e133a48c", "a9a95ad9-4487-455a-8c3c-77836f06c110" },
                    { "567622b0-bba7-4734-9648-6a47e133a48c", "ccd1772b-7962-4803-a18a-2526dc41430d" },
                    { "dec2a85e-3612-4b81-b3fe-310dc4e2ecf8", "ccd1772b-7962-4803-a18a-2526dc41430d" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "567622b0-bba7-4734-9648-6a47e133a48c", "a9a95ad9-4487-455a-8c3c-77836f06c110" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "567622b0-bba7-4734-9648-6a47e133a48c", "ccd1772b-7962-4803-a18a-2526dc41430d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "dec2a85e-3612-4b81-b3fe-310dc4e2ecf8", "ccd1772b-7962-4803-a18a-2526dc41430d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "567622b0-bba7-4734-9648-6a47e133a48c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dec2a85e-3612-4b81-b3fe-310dc4e2ecf8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a9a95ad9-4487-455a-8c3c-77836f06c110");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ccd1772b-7962-4803-a18a-2526dc41430d");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Urls");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Urls",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Urls",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Urls_UserId",
                table: "Urls",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Urls_AspNetUsers_UserId",
                table: "Urls",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
