using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VendingMachine.Migrations
{
    /// <inheritdoc />
    public partial class AddProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4aba9444-2dbd-4677-a374-b0b20e0cbb80");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a25b5249-e224-4eea-a9b4-38bc6b5b274b");

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmountAvailable = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    SellerId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b0a2efc3-7ed9-43a6-9605-f04371bbe283", "1", "Seller", "Seller" },
                    { "e919bad1-3b83-4e4d-b963-b00be1a3936a", "1", "Buyer", "Buyer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");

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
                    { "4aba9444-2dbd-4677-a374-b0b20e0cbb80", "1", "Seller", "Seller" },
                    { "a25b5249-e224-4eea-a9b4-38bc6b5b274b", "1", "Buyer", "Buyer" }
                });
        }
    }
}
