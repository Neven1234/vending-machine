using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VendingMachine.Migrations
{
    /// <inheritdoc />
    public partial class addDepositToUserIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ad9363c-d0e2-4b15-8c58-c34acd3c90a3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3984f839-680e-4e95-826c-20a9307fc5f7");

            migrationBuilder.AddColumn<string>(
                name: "Deposit",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04a53029-3e9f-4e24-8ec7-bfde1f51c704", "1", "Seller", "Seller" },
                    { "8c8620a1-13fd-42a9-b059-35a1d09a5b68", "1", "Buyer", "Buyer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04a53029-3e9f-4e24-8ec7-bfde1f51c704");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c8620a1-13fd-42a9-b059-35a1d09a5b68");

            migrationBuilder.DropColumn(
                name: "Deposit",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1ad9363c-d0e2-4b15-8c58-c34acd3c90a3", "1", "Buyer", "Buyer" },
                    { "3984f839-680e-4e95-826c-20a9307fc5f7", "1", "Seller", "Seller" }
                });
        }
    }
}
