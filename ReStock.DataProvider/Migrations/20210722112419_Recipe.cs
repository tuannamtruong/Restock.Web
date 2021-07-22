using Microsoft.EntityFrameworkCore.Migrations;

namespace ReStock.DataProvider.Migrations
{
    public partial class Recipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CookTime = table.Column<int>(type: "int", nullable: true),
                    Instruction = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Recipe",
                columns: new[] { "Id", "CookTime", "Instruction", "Name" },
                values: new object[,]
                {
                    { 1, 180, "Do this then that then boom", "Pork ribs" },
                    { 2, 20, null, "Salat" },
                    { 3, null, "Just this. Then .... Finally", "Meatballs" },
                    { 4, null, null, "Boiling Eggs" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipe");
        }
    }
}
