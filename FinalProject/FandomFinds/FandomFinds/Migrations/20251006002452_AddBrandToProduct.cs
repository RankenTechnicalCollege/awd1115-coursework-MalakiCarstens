using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FandomFinds.Migrations
{
    /// <inheritdoc />
    public partial class AddBrandToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Brand", "Description", "Name", "Price" },
                values: new object[] { "sh figuarts", "High end action figure. Highly articulated.", "S.H Figuarts Broly", 89.99m });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "Brand", "Description", "Name", "Price" },
                values: new object[] { 4, "Funko", "Vinyl Collectable figure 6 inches in height", "Metal Sonic Funko Pop", 12.99m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Brand", "Description", "Name", "Price" },
                values: new object[] { "Funko", "Vinyl Collectable figure 6 inches in height", "Metal Sonic Funko Pop", 12.99m });
        }
    }
}
