using Microsoft.EntityFrameworkCore.Migrations;

namespace ReStock.DataProvider.Migrations
{
    public partial class ShoppingItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoppingItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingItem", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ShoppingItem",
                columns: new[] { "Id", "Amount", "ItemName" },
                values: new object[,]
                {
                    { 1, "200g", "Beans" },
                    { 2, "300g", "Butter" },
                    { 3, "1 box", "Grapes" }
                });

            migrationBuilder.UpdateData(
                table: "StockItem",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Bell pepper");

            migrationBuilder.UpdateData(
                table: "StockItem",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Fish");

            migrationBuilder.UpdateData(
                table: "StockItem",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Salt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingItem");

            migrationBuilder.UpdateData(
                table: "StockItem",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Thing");

            migrationBuilder.UpdateData(
                table: "StockItem",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Thing 2");

            migrationBuilder.UpdateData(
                table: "StockItem",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Thing 3");
        }
    }
}
