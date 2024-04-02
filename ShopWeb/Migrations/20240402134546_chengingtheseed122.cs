using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopWeb.Migrations
{
    /// <inheritdoc />
    public partial class chengingtheseed122 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl", "Maker", "MinAge", "Popularity", "Position", "Price", "PublishPrice", "Quantity", "RealishDate", "Sold", "Title", "onSale" },
                values: new object[] { "Great Game", "", "Electronic Arts", 0, 0, 0, 50m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Apex", false });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Maker", "MinAge", "Popularity", "Position", "Price", "PublishPrice", "Quantity", "RealishDate", "Sold", "Title", "onSale" },
                values: new object[,]
                {
                    { 2, 2, "ok Game", "", "Nexon", 0, 0, 0, 20m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "MapleStory", false },
                    { 3, 3, "Amazing Game", "", "Riot Games", 0, 0, 0, 70m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "LeugeOfLeguent", false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl", "Maker", "MinAge", "Popularity", "Position", "Price", "PublishPrice", "Quantity", "RealishDate", "Sold", "Title", "onSale" },
                values: new object[] { "Action RPG set in a fantasy world.", "Images/DefGameImages/1.jpg", "CD Projekt Red", 17, 95, 1, 29.99m, 49.99m, 80, new DateTime(2015, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 152, "The Witcher 3: Wild Hunt", true });
        }
    }
}
