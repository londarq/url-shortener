using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace url_shortener.Migrations
{
    /// <inheritdoc />
    public partial class Description : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Description",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Description", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a9a95ad9-4487-455a-8c3c-77836f06c110",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b5a058e-ef9e-41c3-83c4-08bc8a865fa7", "AQAAAAIAAYagAAAAELkG+3sGzivGygPy9igy8hwYuDyJkd7XWFFHGuSsIHnaKmsSr4vAVuVi5w+ehZ2b5g==", "b1d9383c-b1b5-4e81-806e-11ba16a1b297" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ccd1772b-7962-4803-a18a-2526dc41430d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be879a63-71f1-4de5-8884-535a3a8ee8fe", "AQAAAAIAAYagAAAAEGIj9ezrR/U0R7IGEQShDRfCNQ1vSFbJ4RgjZQJfOim3p0jizLySdpluCtmHUkkCiQ==", "da20d5d7-d441-4b31-b67c-75775c28029d" });

            migrationBuilder.InsertData(
                table: "Description",
                columns: new[] { "Id", "Description" },
                values: new object[] { 1, "This is the default description" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Description");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a9a95ad9-4487-455a-8c3c-77836f06c110",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7882afb-b97b-47d8-a113-b8dabff2ef2a", "AQAAAAIAAYagAAAAEA4BZAZc2wRtBE+8Q0Zec2IDXWt2gAGYGq/iWl1E7rs/dLVjGWp+MIg+gNUi+71jqg==", "d23107c1-0259-498b-b635-b1a64ba1538f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ccd1772b-7962-4803-a18a-2526dc41430d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a7d2d714-54c9-4041-8f58-966d2bf82744", "AQAAAAIAAYagAAAAEF/FZC1N4MC8xKXLTltpcOOK2JPktCXe7OtZ1a7EarR8NTZ1wLrUMnO/pJbHNRwwlA==", "2e48619f-b06d-40ea-8f98-72ef96580438" });
        }
    }
}
