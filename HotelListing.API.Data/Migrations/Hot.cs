using Microsoft.EntityFrameworkCore.Migrations;


#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelListeing.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "38973872-9420-4a4d-8a39-16182c18a165", "c76c5708-3f79-4ab5-8c4d-7adb04e0f09e", "User", "USER" },
                    { "4da7bac7-238e-4e60-87d2-ece119f29335", "0c74b842-e023-4019-a63c-f3407774987d", "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38973872-9420-4a4d-8a39-16182c18a165");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4da7bac7-238e-4e60-87d2-ece119f29335");
        }
    }
}