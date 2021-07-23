using Microsoft.EntityFrameworkCore.Migrations;

namespace ReStock.DataProvider.Migrations
{
    public partial class seederRecipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Recipe",
                columns: new[] { "Id", "CookTime", "Instruction", "Name" },
                values: new object[,]
                {
                    { 5, 180, "Do this then that then boom", "Meat n Eggs" },
                    { 6, 20, null, "Bolognese" },
                    { 7, null, "Just this. Then .... Finally", "Steak Diane" },
                    { 8, null, null, "Lasagne" },
                    { 9, 180, "Do this then that then boom", "Fishy" },
                    { 10, 20, null, "Sushi" },
                    { 11, null, "Just this. Then .... Finally", "Stuffy" },
                    { 12, null, null, "Ricey" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipe",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Recipe",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Recipe",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Recipe",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Recipe",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Recipe",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Recipe",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Recipe",
                keyColumn: "Id",
                keyValue: 12);
        }
    }
}
