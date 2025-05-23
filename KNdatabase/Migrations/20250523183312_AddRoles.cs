using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KNdatabase.Migrations
{
    /// <inheritdoc />
    public partial class AddRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1453bd98-41d3-4ecb-bacf-f822ef21f59c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2818daa8-3888-43a5-82df-ec2582607708");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50c27136-97d9-4aef-a80f-97e8923bcb14");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "21fe8438-6819-44cd-94e7-419f8957522c", "1", "Admin", "ADMIN" },
                    { "c246dc35-dcf9-4b54-a43c-61f8559530ee", "3", "Editor", "EDITOR" },
                    { "ea1db301-9f91-4117-aec8-7cfb1486050a", "2", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21fe8438-6819-44cd-94e7-419f8957522c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c246dc35-dcf9-4b54-a43c-61f8559530ee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea1db301-9f91-4117-aec8-7cfb1486050a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1453bd98-41d3-4ecb-bacf-f822ef21f59c", "3", "Editor", "EDITOR" },
                    { "2818daa8-3888-43a5-82df-ec2582607708", "2", "User", "USER" },
                    { "50c27136-97d9-4aef-a80f-97e8923bcb14", "1", "Admin", "ADMIN" }
                });
        }
    }
}
