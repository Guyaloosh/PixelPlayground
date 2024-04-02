using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopWeb.Migrations
{
    /// <inheritdoc />
    public partial class chengingtheseed123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Maker", "MinAge", "Popularity", "Position", "Price", "PublishPrice", "Quantity", "RealishDate", "Sold", "Title", "onSale" },
                values: new object[] { 4, 1, "Action RPG set in a fantasy world.", "", "CD Projekt Red", 0, 0, 0, 29.99m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "The Witcher 3: Wild Hunt", false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
