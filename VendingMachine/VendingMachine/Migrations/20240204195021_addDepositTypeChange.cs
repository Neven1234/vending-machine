using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VendingMachine.Migrations
{
    /// <inheritdoc />
    public partial class addDepositTypeChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04a53029-3e9f-4e24-8ec7-bfde1f51c704");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c8620a1-13fd-42a9-b059-35a1d09a5b68");

            migrationBuilder.AlterColumn<int>(
                name: "Deposit",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4aba9444-2dbd-4677-a374-b0b20e0cbb80", "1", "Seller", "Seller" },
                    { "a25b5249-e224-4eea-a9b4-38bc6b5b274b", "1", "Buyer", "Buyer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4aba9444-2dbd-4677-a374-b0b20e0cbb80");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a25b5249-e224-4eea-a9b4-38bc6b5b274b");

            migrationBuilder.AlterColumn<string>(
                name: "Deposit",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04a53029-3e9f-4e24-8ec7-bfde1f51c704", "1", "Seller", "Seller" },
                    { "8c8620a1-13fd-42a9-b059-35a1d09a5b68", "1", "Buyer", "Buyer" }
                });
        }
    }
}
