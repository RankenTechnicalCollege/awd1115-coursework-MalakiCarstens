using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HOT3.Migrations
{
    /// <inheritdoc />
    public partial class DeskShop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TableId = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "Brand", "Description", "ImageFileName", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Homary", "This accent desk is made from hardwood and wrought metal, with one floating drawer.", "desk1.jpg", "Homary Cabstract Executive Office Desk", 879.99m },
                    { 2, "BYBLIGHT", "Rectangular White wood 2-drawer computer desk", "desk2.jpg", "BYBLIGHT Capen", 214.24m },
                    { 3, "Homary", "Rising and Lowering wooden desk", "desk3.jpg", "Modern Standing/sitting desk", 319.49m },
                    { 4, "BYBLIGHT", "L-Shaped Brown Engineered wood 4-drawer computer desk", "desk4.jpg", "BYBLIGHT Lanita", 559.99m },
                    { 5, "BYBLIGHT", "Space-Saving corner workstation with storage shelves", "desk5.jpg", "SILKYDRY Small Corner Desk", 119.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_TableId",
                table: "Purchases",
                column: "TableId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Tables");
        }
    }
}
