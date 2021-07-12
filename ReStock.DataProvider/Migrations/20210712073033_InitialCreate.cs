using Microsoft.EntityFrameworkCore.Migrations;

namespace ReStock.DataProvider.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StockItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StockType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockItem", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "StockItem",
                columns: new[] { "Id", "Amount", "Name", "StockType" },
                values: new object[] { 1, "2", "Thing", "FruitsAndVeggies" });

            migrationBuilder.InsertData(
                table: "StockItem",
                columns: new[] { "Id", "Amount", "Name", "StockType" },
                values: new object[] { 2, "1", "Thing 2", "Proteins" });

            migrationBuilder.InsertData(
                table: "StockItem",
                columns: new[] { "Id", "Amount", "Name", "StockType" },
                values: new object[] { 3, "4", "Thing 3", "Spices" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockItem");
        }
    }
}
