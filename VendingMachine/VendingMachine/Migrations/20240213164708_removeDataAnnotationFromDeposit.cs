using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VendingMachine.Migrations
{
    /// <inheritdoc />
    public partial class removeDataAnnotationFromDeposit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "158cac6d-6cc1-4d9b-b862-2facffd37a8b", "1", "Buyer", "Buyer" },
                    { "75a4a462-fe07-4a00-8bea-a0b768768eed", "1", "Seller", "Seller" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "158cac6d-6cc1-4d9b-b862-2facffd37a8b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75a4a462-fe07-4a00-8bea-a0b768768eed");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "280dfa84-4900-4625-99b0-a6054b001b9c", "1", "Buyer", "Buyer" },
                    { "e0e8f9fe-de21-4d59-a61b-fbbfdd493156", "1", "Seller", "Seller" }
                });
        }
    }
}
