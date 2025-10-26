using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FandomFinds.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_products",
                table: "products");

            migrationBuilder.RenameTable(
                name: "products",
                newName: "Products");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImagePath",
                value: "/images/destined-rival.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImagePath",
                value: "/images/spiderman.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImagePath",
                value: "/images/broly.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImagePath",
                value: "/images/metal-sonic-funko.jpg");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Description", "ImagePath", "Name", "Price" },
                values: new object[,]
                {
                    { 5, "Tomy", "Collectable. Rare find", "/images/blaziken.jpg", "Pokemon figure- Mega Blaziken", 109.99m },
                    { 6, "jakks", "5in Mario figure in cat suit. Includes a question box. Exclusive movie merch", "/images/cat-mario.jpg", "Cat Mario", 14.99m },
                    { 7, "sh figuarts", "High end action figure. Highly articulated. 2 pack. Reenact scenes from the manga with the high poseable figures", "/images/chainsawman.jpg", "S.h. Figuarts Denji chainsaw man figure. Double pack", 149.99m },
                    { 8, "sh figuarts", "High end action figure. Highly articulated. Includes lightsabers.", "/images/grevious.jpg", "StarWars General Grevious figure", 89.99m },
                    { 9, "sh figuarts", "High end action figure. Highly articulated. Includes sword and cape. 12in figure.", "/images/king-cold.jpg", "King Cold-Dragonball figure", 109.99m },
                    { 10, "jakks", "4 characters all included in this special pack. Articulated. Detailed designs. Inspired by the movie! Perfect set for collectors", "/images/mario-set.jpg", "Mario Set 4 pack", 49.99m },
                    { 11, "sh figuarts", "Very rare mario figure. Brand new. Sealed.", "/images/mario-sh.jpg", "Mario S.H. Figuarts", 149.99m },
                    { 12, "jakks", "Hard to find. Articulated. Very detailed ", "/images/metal-sonic.jpg", "Metal Sonic figure", 69.99m },
                    { 13, "sh figuarts", "High end action figure. Highly articulated. Includes many accessories. Realistic.", "/images/miles.jpg", "S.H Figuarts Miles Morales figure", 89.99m },
                    { 14, "jakks", "Hard to find. Articulated. Very detailed ", "/images/metal-sonic.jpg", "Metal Sonic figure", 69.99m },
                    { 15, "Entertainment E", "Reenact classic scenes from highly popular show Stranger Things. Includes Demigorgan, Dustin and Will. ", "/images/stranger-set.jpg", "Stranger Things Character set", 29.99m },
                    { 16, "S.H Figuarts", "Hard to find. Articulated. Very detailed ", "/images/scarlet-spider.jpg", "Scarlet Spiderman", 99.99m },
                    { 17, "Entertainment E", "Hard to find. From season one of Strangers Things. Eleven in dress with shaved head.", "/images/stranger-11.jpg", "Eleven Stranger Things figure", 59.99m },
                    { 18, "S.H Figuarts", "Articulated. Very detailed. Accessories included. Collect them all!", "/images/power.jpg", "Chainsaw Man Power Figure", 79.99m },
                    { 19, "Hasbro", "Collectable. In original packaging. Perfect condition. Perfect for the collector in you life.", "/images/optimus-prime.jpg", "Transformers Optimus Prime figure", 29.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_products",
                table: "products",
                column: "Id");
        }
    }
}
