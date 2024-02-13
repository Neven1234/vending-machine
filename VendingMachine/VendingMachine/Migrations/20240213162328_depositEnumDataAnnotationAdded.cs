using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VendingMachine.Migrations
{
    /// <inheritdoc />
    public partial class depositEnumDataAnnotationAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0a2efc3-7ed9-43a6-9605-f04371bbe283");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e919bad1-3b83-4e4d-b963-b00be1a3936a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "280dfa84-4900-4625-99b0-a6054b001b9c", "1", "Buyer", "Buyer" },
                    { "e0e8f9fe-de21-4d59-a61b-fbbfdd493156", "1", "Seller", "Seller" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "280dfa84-4900-4625-99b0-a6054b001b9c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0e8f9fe-de21-4d59-a61b-fbbfdd493156");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b0a2efc3-7ed9-43a6-9605-f04371bbe283", "1", "Seller", "Seller" },
                    { "e919bad1-3b83-4e4d-b963-b00be1a3936a", "1", "Buyer", "Buyer" }
                });
        }
    }
}
