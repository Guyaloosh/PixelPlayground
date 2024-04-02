using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopWeb.Models;

namespace ShopWeb.Data
{
    //basic configuration for entity frame work 
    public class ApplicationDbContext:IdentityDbContext<IdentityUser>
    {
        //pass the connection string 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
           
        }

        //creating a table in our data base called Categories 
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1,Name="Action",DisplayOrder= 1},
                new Category { Id = 2, Name = "Racing", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Adventure", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Strategy", DisplayOrder = 4 },
                new Category { Id = 5, Name = "Family", DisplayOrder = 5 },
                new Category { Id = 6, Name = "Music", DisplayOrder = 6 },
                new Category { Id = 7, Name = "FPS", DisplayOrder = 7 },
                new Category { Id = 8, Name = "Multiplayer", DisplayOrder = 8 },
                new Category { Id = 9, Name = "OpenWorld", DisplayOrder = 9 },
                new Category { Id = 10, Name = "Puzzle", DisplayOrder = 10 },
                new Category { Id = 11, Name = "History", DisplayOrder = 11 },
                new Category { Id = 12, Name = "Horror", DisplayOrder = 12 }
                

                );

            modelBuilder.Entity<Product>().HasData(
              //adding all default Games to database
              new Product { Id = 1, Title = "The Witcher 3: Wild Hunt", Description = "Action RPG set in a fantasy world.", Maker = "CD Projekt Red", Price = 29.99m, CategoryId = 1, ImageUrl = "/Images/DefGameImages/1.jpg", MinAge = 17, Popularity = 95, Position = 1, PublishPrice = 49.99m, Quantity = 80, RealishDate = new DateTime(2015, 5, 19), Sold = 152, onSale = true },
              new Product { Id = 2, Title = "Red Dead Redemption 2", Description = "Open-world action-adventure game.", Maker = "Rockstar Games", Price = 39.99m, CategoryId = 9, ImageUrl = "/Images/DefGameImages/2.jpg", MinAge = 17, Popularity = 96, Position = 2, PublishPrice = 59.99m, Quantity = 45, RealishDate = new DateTime(2018, 10, 26), Sold = 287, onSale = true },
              new Product { Id = 3, Title = "Cyberpunk 2077", Description = "Open-world action RPG set in a dystopian future.", Maker = "CD Projekt Red", Price = 49.99m, CategoryId = 1, ImageUrl = "/Images/DefGameImages/3.jpg", MinAge = 18, Popularity = 90, Position = 3, PublishPrice = 59.99m, Quantity = 34, RealishDate = new DateTime(2020, 12, 10), Sold = 130, onSale = false },
              new Product { Id = 4, Title = "Grand Theft Auto V", Description = "Action-adventure game set in a fictional version of Southern California.", Maker = "Rockstar Games", Price = 29.99m, CategoryId = 1, ImageUrl = "/Images/DefGameImages/4.jpg", MinAge = 18, Popularity = 97, Position = 4, PublishPrice = 59.99m, Quantity = 25, RealishDate = new DateTime(2013, 9, 17), Sold = 140, onSale = false },
              new Product { Id = 5, Title = "Fortnite", Description = "Battle Royale game with building mechanics.", Maker = "Epic Games", Price = 19.99m, CategoryId = 8, ImageUrl = "/Images/DefGameImages/5.jpg", MinAge = 13, Popularity = 98, Position = 5, PublishPrice = 0, Quantity = 75, RealishDate = new DateTime(2017, 7, 25), Sold = 350, onSale = false },
              new Product { Id = 6, Title = "PlayerUnknown's Battlegrounds (PUBG)", Description = "Multiplayer online battle royale game.", Maker = "PUBG Corporation", Price = 29.99m, CategoryId = 8, ImageUrl = "/Images/DefGameImages/6.jpg", MinAge = 16, Popularity = 92, Position = 6, PublishPrice = 39.99m, Quantity = 35, RealishDate = new DateTime(2017, 12, 20), Sold = 70, onSale = false },
              new Product { Id = 7, Title = "Call of Duty: Modern Warfare", Description = "First-person shooter video game set in the modern world.", Maker = "Activision", Price = 59.99m, CategoryId = 7, ImageUrl = "/Images/DefGameImages/7.jpg", MinAge = 17, Popularity = 90, Position = 7, PublishPrice = 59.99m, Quantity = 42, RealishDate = new DateTime(2019, 10, 25), Sold = 30, onSale = true },
              new Product { Id = 8, Title = "Call of Duty: Warzone", Description = "Battle Royale game mode within the Call of Duty: Modern Warfare universe.", Maker = "Activision", Price = 19.99m, CategoryId = 8, ImageUrl = "/Images/DefGameImages/8.jpg", MinAge = 17, Popularity = 92, Position = 8, PublishPrice = 29.99m, Quantity = 13, RealishDate = new DateTime(2020, 3, 10), Sold = 80, onSale = false },
              new Product { Id = 9, Title = "Apex Legends", Description = "Free-to-play battle royale game set in the Titanfall universe.", Maker = "Respawn Entertainment", Price = 19.99m, CategoryId = 7, ImageUrl = "/Images/DefGameImages/9.jpg", MinAge = 13, Popularity = 95, Position = 9, PublishPrice = 29.99m, Quantity = 28, RealishDate = new DateTime(2019, 2, 4), Sold = 100, onSale = false },
              new Product { Id = 10, Title = "Overwatch", Description = "Team-based multiplayer first-person shooter game.", Maker = "Blizzard Entertainment", Price = 39.99m, CategoryId = 4, ImageUrl = "/Images/DefGameImages/10.jpg", MinAge = 13, Popularity = 92, Position = 10, PublishPrice = 59.99m, Quantity = 35, RealishDate = new DateTime(2016, 5, 24), Sold = 54, onSale = false },
              new Product { Id = 11, Title = "Minecraft", Description = "Sandbox video game where players build with various cubes in a 3D procedurally generated world.", Maker = "Mojang Studios", Price = 26.95m, CategoryId = 9, ImageUrl = "/Images/DefGameImages/11.jpg", MinAge = 10, Popularity = 96, Position = 11, PublishPrice = 26.95m, Quantity = 85, RealishDate = new DateTime(2011, 11, 18), Sold = 20, onSale = false },
              new Product { Id = 12, Title = "Valorant", Description = "Free-to-play multiplayer tactical first-person shooter.", Maker = "Riot Games", Price = 0, CategoryId = 7, ImageUrl = "/Images/DefGameImages/12.jpg", MinAge = 13, Popularity = 93, Position = 12, PublishPrice = 39.99m, Quantity = 15, RealishDate = new DateTime(2020, 6, 2), Sold = 10, onSale = true },
              new Product { Id = 13, Title = "Among Us", Description = "Online multiplayer social deduction game.", Maker = "InnerSloth", Price = 4.99m, CategoryId = 5, ImageUrl = "/Images/DefGameImages/13.jpg", MinAge = 10, Popularity = 97, Position = 13, PublishPrice = 4.99m, Quantity = 15, RealishDate = new DateTime(2018, 6, 15), Sold = 50, onSale = false },
              new Product { Id = 14, Title = "Fall Guys: Ultimate Knockout", Description = "Multiplayer party game with up to 60 players online.", Maker = "Mediatonic", Price = 19.99m, CategoryId = 5, ImageUrl = "/Images/DefGameImages/14.jpg", MinAge = 10, Popularity = 95, Position = 14, PublishPrice = 19.99m, Quantity = 25, RealishDate = new DateTime(2020, 8, 4), Sold = 200, onSale = false },
              new Product { Id = 15, Title = "The Elder Scrolls V: Skyrim", Description = "Action role-playing game set in the fictional province of Skyrim.", Maker = "Bethesda Game Studios", Price = 19.99m, CategoryId = 1, ImageUrl = "/Images/DefGameImages/15.jpg", MinAge = 17, Popularity = 97, Position = 15, PublishPrice = 39.99m, Quantity = 34, RealishDate = new DateTime(2011, 11, 11), Sold = 30, onSale = false },
              new Product { Id = 16, Title = "Rocket League", Description = "Vehicular soccer video game.", Maker = "Psyonix", Price = 19.99m, CategoryId = 2, ImageUrl = "/Images/DefGameImages/16.jpg", MinAge = 3, Popularity = 93, Position = 16, PublishPrice = 19.99m, Quantity = 82, RealishDate = new DateTime(2015, 7, 7), Sold = 75, onSale = false },
              new Product { Id = 17, Title = "Assassin's Creed Odyssey", Description = "Action role-playing video game set in ancient Greece.", Maker = "Ubisoft", Price = 19.99m, CategoryId = 9, ImageUrl = "/Images/DefGameImages/17.jpg", MinAge = 17, Popularity = 91, Position = 17, PublishPrice = 59.99m, Quantity = 43, RealishDate = new DateTime(2018, 10, 5), Sold = 10, onSale = true },
              new Product { Id = 18, Title = "Doom Eternal", Description = "First-person shooter video game developed by id Software.", Maker = "Bethesda Softworks", Price = 29.99m, CategoryId = 12, ImageUrl = "/Images/DefGameImages/18.jpg", MinAge = 17, Popularity = 94, Position = 18, PublishPrice = 59.99m, Quantity = 35, RealishDate = new DateTime(2020, 3, 20), Sold = 30, onSale = false },
              new Product { Id = 19, Title = "Monster Hunter: World", Description = "Action role-playing game set in an open world environment.", Maker = "Capcom", Price = 39.99m, CategoryId = 8, ImageUrl = "/Images/DefGameImages/19.jpg", MinAge = 16, Popularity = 90, Position = 19, PublishPrice = 59.99m, Quantity = 70, RealishDate = new DateTime(2018, 8, 9), Sold = 16, onSale = false },
              new Product { Id = 20, Title = "Tom Clancy's Rainbow Six Siege", Description = "Tactical shooter video game developed by Ubisoft Montreal.", Maker = "Ubisoft", Price = 19.99m, CategoryId = 1, ImageUrl = "/Images/DefGameImages/20.jpg", MinAge = 18, Popularity = 95, Position = 20, PublishPrice = 39.99m, Quantity = 15, RealishDate = new DateTime(2015, 12, 1), Sold = 65, onSale = false },
              new Product { Id = 21, Title = "Final Fantasy XV", Description = "Action role-playing game set in an open world environment.", Maker = "Square Enix", Price = 19.99m, CategoryId = 8, ImageUrl = "/Images/DefGameImages/21.jpg", MinAge = 16, Popularity = 93, Position = 21, PublishPrice = 59.99m, Quantity = 50, RealishDate = new DateTime(2016, 11, 29), Sold = 90, onSale = false },
              new Product { Id = 22, Title = "Death Stranding", Description = "Action game developed by Kojima Productions.", Maker = "Sony Interactive Entertainment", Price = 29.99m, CategoryId = 3, ImageUrl = "/Images/DefGameImages/22.jpg", MinAge = 18, Popularity = 91, Position = 22, PublishPrice = 59.99m, Quantity = 42, RealishDate = new DateTime(2019, 11, 8), Sold = 60, onSale = false },
              new Product { Id = 23, Title = "Resident Evil 7: Biohazard", Description = "Survival horror video game developed by Capcom.", Maker = "Capcom", Price = 19.99m, CategoryId = 12, ImageUrl = "/Images/DefGameImages/23.jpg", MinAge = 18, Popularity = 90, Position = 23, PublishPrice = 59.99m, Quantity = 30, RealishDate = new DateTime(2017, 1, 24), Sold = 82, onSale = false },
              new Product { Id = 24, Title = "Sekiro: Shadows Die Twice", Description = "Action-adventure video game developed by FromSoftware.", Maker = "Activision", Price = 29.99m, CategoryId = 1, ImageUrl = "/Images/DefGameImages/24.jpg", MinAge = 18, Popularity = 94, Position = 24, PublishPrice = 59.99m, Quantity = 27, RealishDate = new DateTime(2019, 3, 22), Sold = 50, onSale = true },
              new Product { Id = 25, Title = "Control", Description = "Action-adventure video game developed by Remedy Entertainment.", Maker = "505 Games", Price = 29.99m, CategoryId = 10, ImageUrl = "/Images/DefGameImages/25.jpg", MinAge = 17, Popularity = 91, Position = 25, PublishPrice = 59.99m, Quantity = 50, RealishDate = new DateTime(2019, 8, 27), Sold = 20, onSale = true },
              new Product { Id = 26, Title = "Genshin Impact", Description = "Open-world action role-playing game.", Maker = "miHoYo", Price = 0, CategoryId = 5, ImageUrl = "/Images/DefGameImages/26.jpg", MinAge = 9, Popularity = 95, Position = 26, PublishPrice = 0, Quantity = 13, RealishDate = new DateTime(2020, 9, 28), Sold = 54, onSale = false },
              new Product { Id = 27, Title = "The Legend of Zelda: Breath of the Wild", Description = "Action-adventure game developed and published by Nintendo.", Maker = "Nintendo", Price = 59.99m, CategoryId = 3, ImageUrl = "/Images/DefGameImages/27.jpg", MinAge = 10, Popularity = 98, Position = 27, PublishPrice = 59.99m, Quantity = 43, RealishDate = new DateTime(2017, 3, 3), Sold = 23, onSale = false },
              new Product { Id = 28, Title = "Star Wars Jedi: Fallen Order", Description = "Action-adventure game developed by Respawn Entertainment.", Maker = "Electronic Arts", Price = 29.99m, CategoryId = 3, ImageUrl = "/Images/DefGameImages/28.jpg", MinAge = 16, Popularity = 94, Position = 28, PublishPrice = 59.99m, Quantity = 25, RealishDate = new DateTime(2019, 11, 15), Sold = 11, onSale = false },
              new Product { Id = 29, Title = "Half-Life: Alyx", Description = "Virtual reality first-person shooter game developed and published by Valve.", Maker = "Valve", Price = 59.99m, CategoryId = 1, ImageUrl = "/Images/DefGameImages/29.jpg", MinAge = 16, Popularity = 95, Position = 29, PublishPrice = 59.99m, Quantity = 30, RealishDate = new DateTime(2020, 3, 23), Sold = 26, onSale = false },
              new Product { Id = 30, Title = "BeatSaber", Description = "Dance with your swords! VR special!", Maker = "VRworld", Price = 39.99m, CategoryId = 6, ImageUrl = "/Images/DefGameImages/30.jpg", MinAge = 18, Popularity = 93, Position = 30, PublishPrice = 49.99m, Quantity = 56, RealishDate = new DateTime(2019, 10, 15), Sold = 52, onSale = false },
              new Product { Id = 31, Title = "Grand Theft Auto VI", Description = "Action-adventure game ,More details SOON!.", Maker = "Rockstar Games", Price = 300M, CategoryId = 1, ImageUrl = "/Images/DefGameImages/31.jpg", MinAge = 18, Popularity = 20000, Position = 31, PublishPrice = 300m, Quantity = 0, RealishDate = new DateTime(2026, 9, 17), Sold = 0, onSale = false }

            );


        }
    }
}
