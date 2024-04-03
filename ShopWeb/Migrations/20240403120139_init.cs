using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopWeb.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShippingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrackingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Carrier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDueDate = table.Column<DateOnly>(type: "date", nullable: false),
                    SessionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentIntentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderHeaders_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Maker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PublishPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sold = table.Column<int>(type: "int", nullable: false),
                    Popularity = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    MinAge = table.Column<int>(type: "int", nullable: false),
                    onSale = table.Column<bool>(type: "bit", nullable: false),
                    RealishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderHeaderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_OrderHeaders_OrderHeaderId",
                        column: x => x.OrderHeaderId,
                        principalTable: "OrderHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Action" },
                    { 2, 2, "Racing" },
                    { 3, 3, "Adventure" },
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

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Maker", "MinAge", "Popularity", "Position", "Price", "PublishPrice", "Quantity", "RealishDate", "Sold", "Title", "onSale" },
                values: new object[,]
                {
                    { 1, 1, "Action RPG set in a fantasy world.", "/Images/DefGameImages/1.jpg", "CD Projekt Red", 17, 95, 1, 29.99m, 49.99m, 80, new DateTime(2015, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 152, "The Witcher 3: Wild Hunt", true },
                    { 2, 9, "Open-world action-adventure game.", "/Images/DefGameImages/2.jpg", "Rockstar Games", 17, 96, 2, 39.99m, 59.99m, 45, new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 287, "Red Dead Redemption 2", true },
                    { 3, 1, "Open-world action RPG set in a dystopian future.", "/Images/DefGameImages/3.jpg", "CD Projekt Red", 18, 90, 3, 49.99m, 59.99m, 34, new DateTime(2020, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 130, "Cyberpunk 2077", false },
                    { 4, 1, "Action-adventure game set in a fictional version of Southern California.", "/Images/DefGameImages/4.jpg", "Rockstar Games", 18, 97, 4, 29.99m, 59.99m, 25, new DateTime(2013, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 140, "Grand Theft Auto V", false },
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
                    { 15, 1, "Action role-playing game set in the fictional province of Skyrim.", "/Images/DefGameImages/15.jpg", "Bethesda Game Studios", 17, 97, 15, 19.99m, 39.99m, 34, new DateTime(2011, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, "The Elder Scrolls V: Skyrim", false },
                    { 16, 2, "Vehicular soccer video game.", "/Images/DefGameImages/16.jpg", "Psyonix", 3, 93, 16, 19.99m, 19.99m, 82, new DateTime(2015, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 75, "Rocket League", false },
                    { 17, 9, "Action role-playing video game set in ancient Greece.", "/Images/DefGameImages/17.jpg", "Ubisoft", 17, 91, 17, 19.99m, 59.99m, 43, new DateTime(2018, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "Assassin's Creed Odyssey", true },
                    { 18, 12, "First-person shooter video game developed by id Software.", "/Images/DefGameImages/18.jpg", "Bethesda Softworks", 17, 94, 18, 29.99m, 59.99m, 35, new DateTime(2020, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, "Doom Eternal", false },
                    { 19, 8, "Action role-playing game set in an open world environment.", "/Images/DefGameImages/19.jpg", "Capcom", 16, 90, 19, 39.99m, 59.99m, 70, new DateTime(2018, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, "Monster Hunter: World", false },
                    { 20, 1, "Tactical shooter video game developed by Ubisoft Montreal.", "/Images/DefGameImages/20.jpg", "Ubisoft", 18, 95, 20, 19.99m, 39.99m, 15, new DateTime(2015, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 65, "Tom Clancy's Rainbow Six Siege", false },
                    { 21, 8, "Action role-playing game set in an open world environment.", "/Images/DefGameImages/21.jpg", "Square Enix", 16, 93, 21, 19.99m, 59.99m, 50, new DateTime(2016, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 90, "Final Fantasy XV", false },
                    { 22, 3, "Action game developed by Kojima Productions.", "/Images/DefGameImages/22.jpg", "Sony Interactive Entertainment", 18, 91, 22, 29.99m, 59.99m, 42, new DateTime(2019, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 60, "Death Stranding", false },
                    { 23, 12, "Survival horror video game developed by Capcom.", "/Images/DefGameImages/23.jpg", "Capcom", 18, 90, 23, 19.99m, 59.99m, 30, new DateTime(2017, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 82, "Resident Evil 7: Biohazard", false },
                    { 24, 1, "Action-adventure video game developed by FromSoftware.", "/Images/DefGameImages/24.jpg", "Activision", 18, 94, 24, 29.99m, 59.99m, 27, new DateTime(2019, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, "Sekiro: Shadows Die Twice", true },
                    { 25, 10, "Action-adventure video game developed by Remedy Entertainment.", "/Images/DefGameImages/25.jpg", "505 Games", 17, 91, 25, 29.99m, 59.99m, 50, new DateTime(2019, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, "Control", true },
                    { 26, 5, "Open-world action role-playing game.", "/Images/DefGameImages/26.jpg", "miHoYo", 9, 95, 26, 0m, 0m, 13, new DateTime(2020, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 54, "Genshin Impact", false },
                    { 27, 3, "Action-adventure game developed and published by Nintendo.", "/Images/DefGameImages/27.jpg", "Nintendo", 10, 98, 27, 59.99m, 59.99m, 43, new DateTime(2017, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, "The Legend of Zelda: Breath of the Wild", false },
                    { 28, 3, "Action-adventure game developed by Respawn Entertainment.", "/Images/DefGameImages/28.jpg", "Electronic Arts", 16, 94, 28, 29.99m, 59.99m, 25, new DateTime(2019, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, "Star Wars Jedi: Fallen Order", false },
                    { 29, 1, "Virtual reality first-person shooter game developed and published by Valve.", "/Images/DefGameImages/29.jpg", "Valve", 16, 95, 29, 59.99m, 59.99m, 30, new DateTime(2020, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, "Half-Life: Alyx", false },
                    { 30, 6, "Dance with your swords! VR special!", "/Images/DefGameImages/30.jpg", "VRworld", 18, 93, 30, 39.99m, 49.99m, 56, new DateTime(2019, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 52, "BeatSaber", false },
                    { 31, 1, "Action-adventure game ,More details SOON!.", "/Images/DefGameImages/31.jpg", "Rockstar Games", 18, 20000, 31, 300m, 300m, 0, new DateTime(2026, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Grand Theft Auto VI", false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderHeaderId",
                table: "OrderDetails",
                column: "OrderHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeaders_ApplicationUserId",
                table: "OrderHeaders",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_ApplicationUserId",
                table: "ShoppingCarts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_ProductId",
                table: "ShoppingCarts",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "OrderHeaders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
