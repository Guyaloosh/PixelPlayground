using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopWeb.Migrations
{
    /// <inheritdoc />
    public partial class newdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Racing");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Adventure");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 4, 4, "Strategy" },
                    { 5, 5, "Family" },
                    { 6, 6, "Music" },
                    { 7, 7, "FPS" },
                    { 8, 8, "Multiplayer" },
                    { 9, 9, "OpenWorld" },
                    { 10, 10, "Puzzle" },
                    { 11, 11, "History" },
                    { 12, 12, "Horror" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl", "Maker", "MinAge", "Popularity", "Position", "Price", "PublishPrice", "Quantity", "RealishDate", "Sold", "Title", "onSale" },
                values: new object[] { "Action RPG set in a fantasy world.", "Images/DefGameImages/1.jpg", "CD Projekt Red", 17, 95, 1, 29.99m, 49.99m, 80, new DateTime(2015, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 152, "The Witcher 3: Wild Hunt", true });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Maker", "MinAge", "Popularity", "Position", "Price", "PublishPrice", "Quantity", "RealishDate", "Sold", "Title", "onSale" },
                values: new object[] { 9, "Open-world action-adventure game.", "Images/DefGameImages/2.jpg", "Rockstar Games", 17, 96, 2, 39.99m, 59.99m, 45, new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 287, "Red Dead Redemption 2", true });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Maker", "MinAge", "Popularity", "Position", "Price", "PublishPrice", "Quantity", "RealishDate", "Sold", "Title" },
                values: new object[] { 1, "Open-world action RPG set in a dystopian future.", "~/Images/DefGameImages/3.jpg", "CD Projekt Red", 18, 90, 3, 49.99m, 59.99m, 34, new DateTime(2020, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 130, "Cyberpunk 2077" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Maker", "MinAge", "Popularity", "Position", "Price", "PublishPrice", "Quantity", "RealishDate", "Sold", "Title", "onSale" },
                values: new object[,]
                {
                    { 4, 1, "Action-adventure game set in a fictional version of Southern California.", "/Images/DefGameImages/4.jpg", "Rockstar Games", 18, 97, 4, 29.99m, 59.99m, 25, new DateTime(2013, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 140, "Grand Theft Auto V", false },
                    { 15, 1, "Action role-playing game set in the fictional province of Skyrim.", "/Images/DefGameImages/15.jpg", "Bethesda Game Studios", 17, 97, 15, 19.99m, 39.99m, 34, new DateTime(2011, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, "The Elder Scrolls V: Skyrim", false },
                    { 16, 2, "Vehicular soccer video game.", "/Images/DefGameImages/16.jpg", "Psyonix", 3, 93, 16, 19.99m, 19.99m, 82, new DateTime(2015, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 75, "Rocket League", false },
                    { 20, 1, "Tactical shooter video game developed by Ubisoft Montreal.", "/Images/DefGameImages/20.jpg", "Ubisoft", 18, 95, 20, 19.99m, 39.99m, 15, new DateTime(2015, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 65, "Tom Clancy's Rainbow Six Siege", false },
                    { 22, 3, "Action game developed by Kojima Productions.", "/Images/DefGameImages/22.jpg", "Sony Interactive Entertainment", 18, 91, 22, 29.99m, 59.99m, 42, new DateTime(2019, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 60, "Death Stranding", false },
                    { 24, 1, "Action-adventure video game developed by FromSoftware.", "/Images/DefGameImages/24.jpg", "Activision", 18, 94, 24, 29.99m, 59.99m, 27, new DateTime(2019, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, "Sekiro: Shadows Die Twice", true },
                    { 27, 3, "Action-adventure game developed and published by Nintendo.", "/Images/DefGameImages/27.jpg", "Nintendo", 10, 98, 27, 59.99m, 59.99m, 43, new DateTime(2017, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, "The Legend of Zelda: Breath of the Wild", false },
                    { 28, 3, "Action-adventure game developed by Respawn Entertainment.", "/Images/DefGameImages/28.jpg", "Electronic Arts", 16, 94, 28, 29.99m, 59.99m, 25, new DateTime(2019, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, "Star Wars Jedi: Fallen Order", false },
                    { 29, 1, "Virtual reality first-person shooter game developed and published by Valve.", "/Images/DefGameImages/29.jpg", "Valve", 16, 95, 29, 59.99m, 59.99m, 30, new DateTime(2020, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, "Half-Life: Alyx", false },
                    { 31, 1, "Action-adventure game ,More details SOON!.", "/Images/DefGameImages/31.jpg", "Rockstar Games", 18, 20000, 31, 300m, 300m, 0, new DateTime(2026, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Grand Theft Auto VI", false },
                    { 5, 8, "Battle Royale game with building mechanics.", "/Images/DefGameImages/5.jpg", "Epic Games", 13, 98, 5, 19.99m, 0m, 75, new DateTime(2017, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 350, "Fortnite", false },
                    { 6, 8, "Multiplayer online battle royale game.", "/Images/DefGameImages/6.jpg", "PUBG Corporation", 16, 92, 6, 29.99m, 39.99m, 35, new DateTime(2017, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 70, "PlayerUnknown's Battlegrounds (PUBG)", false },
                    { 7, 7, "First-person shooter video game set in the modern world.", "/Images/DefGameImages/7.jpg", "Activision", 17, 90, 7, 59.99m, 59.99m, 42, new DateTime(2019, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, "Call of Duty: Modern Warfare", true },
                    { 8, 8, "Battle Royale game mode within the Call of Duty: Modern Warfare universe.", "/Images/DefGameImages/8.jpg", "Activision", 17, 92, 8, 19.99m, 29.99m, 13, new DateTime(2020, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 80, "Call of Duty: Warzone", false },
                    { 9, 7, "Free-to-play battle royale game set in the Titanfall universe.", "/Images/DefGameImages/9.jpg", "Respawn Entertainment", 13, 95, 9, 19.99m, 29.99m, 28, new DateTime(2019, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, "Apex Legends", false },
                    { 10, 4, "Team-based multiplayer first-person shooter game.", "/Images/DefGameImages/10.jpg", "Blizzard Entertainment", 13, 92, 10, 39.99m, 59.99m, 35, new DateTime(2016, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 54, "Overwatch", false },
                    { 11, 9, "Sandbox video game where players build with various cubes in a 3D procedurally generated world.", "/Images/DefGameImages/11.jpg", "Mojang Studios", 10, 96, 11, 26.95m, 26.95m, 85, new DateTime(2011, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, "Minecraft", false },
                    { 12, 7, "Free-to-play multiplayer tactical first-person shooter.", "/Images/DefGameImages/12.jpg", "Riot Games", 13, 93, 12, 0m, 39.99m, 15, new DateTime(2020, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "Valorant", true },
                    { 13, 5, "Online multiplayer social deduction game.", "/Images/DefGameImages/13.jpg", "InnerSloth", 10, 97, 13, 4.99m, 4.99m, 15, new DateTime(2018, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, "Among Us", false },
                    { 14, 5, "Multiplayer party game with up to 60 players online.", "/Images/DefGameImages/14.jpg", "Mediatonic", 10, 95, 14, 19.99m, 19.99m, 25, new DateTime(2020, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 200, "Fall Guys: Ultimate Knockout", false },
                    { 17, 9, "Action role-playing video game set in ancient Greece.", "/Images/DefGameImages/17.jpg", "Ubisoft", 17, 91, 17, 19.99m, 59.99m, 43, new DateTime(2018, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "Assassin's Creed Odyssey", true },
                    { 18, 12, "First-person shooter video game developed by id Software.", "/Images/DefGameImages/18.jpg", "Bethesda Softworks", 17, 94, 18, 29.99m, 59.99m, 35, new DateTime(2020, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, "Doom Eternal", false },
                    { 19, 8, "Action role-playing game set in an open world environment.", "/Images/DefGameImages/19.jpg", "Capcom", 16, 90, 19, 39.99m, 59.99m, 70, new DateTime(2018, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, "Monster Hunter: World", false },
                    { 21, 8, "Action role-playing game set in an open world environment.", "/Images/DefGameImages/21.jpg", "Square Enix", 16, 93, 21, 19.99m, 59.99m, 50, new DateTime(2016, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 90, "Final Fantasy XV", false },
                    { 23, 12, "Survival horror video game developed by Capcom.", "/Images/DefGameImages/23.jpg", "Capcom", 18, 90, 23, 19.99m, 59.99m, 30, new DateTime(2017, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 82, "Resident Evil 7: Biohazard", false },
                    { 25, 10, "Action-adventure video game developed by Remedy Entertainment.", "/Images/DefGameImages/25.jpg", "505 Games", 17, 91, 25, 29.99m, 59.99m, 50, new DateTime(2019, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, "Control", true },
                    { 26, 5, "Open-world action role-playing game.", "/Images/DefGameImages/26.jpg", "miHoYo", 9, 95, 26, 0m, 0m, 13, new DateTime(2020, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 54, "Genshin Impact", false },
                    { 30, 6, "Dance with your swords! VR special!", "/Images/DefGameImages/30.jpg", "VRworld", 18, 93, 30, 39.99m, 49.99m, 56, new DateTime(2019, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 52, "BeatSaber", false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

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

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "SciFi");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "History");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUrl", "Maker", "MinAge", "Popularity", "Position", "Price", "PublishPrice", "Quantity", "RealishDate", "Sold", "Title", "onSale" },
                values: new object[] { "Great Game", "", "Electronic Arts", 0, 0, 0, 50m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Apex", false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Maker", "MinAge", "Popularity", "Position", "Price", "PublishPrice", "Quantity", "RealishDate", "Sold", "Title", "onSale" },
                values: new object[] { 2, "ok Game", "", "Nexon", 0, 0, 0, 20m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "MapleStory", false });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Description", "ImageUrl", "Maker", "MinAge", "Popularity", "Position", "Price", "PublishPrice", "Quantity", "RealishDate", "Sold", "Title" },
                values: new object[] { 3, "Amazing Game", "", "Riot Games", 0, 0, 0, 70m, 0m, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "LeugeOfLeguent" });
        }
    }
}
