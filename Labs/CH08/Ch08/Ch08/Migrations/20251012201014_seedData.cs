using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ch08.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TripLogs",
                columns: new[] { "Id", "Accommodation", "AccommodationEmail", "AccommodationPhone", "Activity1", "Activity2", "Activity3", "Destination", "EndDate", "StartDate" },
                values: new object[,]
                {
                    { 1, "Grand Hotel", "Grand-Hotel@gmail.com", "555-1234", "Statue of Liberty", "Broadway Show", "Central Park", "New York City", new DateTime(2023, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Sunset Inn", "Sunset_Inn@hotelinfo.com", "555-5678", "Hollywood Tour", "Beach Day", "Theme Park", "Los Angeles", new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TripLogs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TripLogs",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
