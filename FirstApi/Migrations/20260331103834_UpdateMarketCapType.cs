using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FirstApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMarketCapType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57a706a7-6c63-4ed0-904b-6c80e4fe6762");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a3d8dd1-907a-4c19-bed6-c71254f7ea03");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0725e84a-3aed-44e3-bb91-1bb72fe5bbd8", null, "Admin", "ADMIN" },
                    { "5a5a52b3-0666-412a-821a-ed2caece03f5", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0725e84a-3aed-44e3-bb91-1bb72fe5bbd8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a5a52b3-0666-412a-821a-ed2caece03f5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "57a706a7-6c63-4ed0-904b-6c80e4fe6762", null, "User", "USER" },
                    { "8a3d8dd1-907a-4c19-bed6-c71254f7ea03", null, "Admin", "ADMIN" }
                });
        }
    }
}
