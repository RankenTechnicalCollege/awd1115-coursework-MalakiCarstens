using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FandomFinds.Migrations
{
    /// <inheritdoc />
    public partial class ShopContextInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "Brand", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Nintendo", "Booster pack with 10 cards and a code card for online game. Each pack is random.", "Destined Rival TCG Pokemon", 5.99m },
                    { 2, "sh figuarts", "High end action figure. Highly articulated.", "S.H Figuarts Spider-Man", 65.99m },
                    { 3, "Funko", "Vinyl Collectable figure 6 inches in height", "Metal Sonic Funko Pop", 12.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
