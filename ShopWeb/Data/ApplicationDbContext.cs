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
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Product>().HasData(
               new Product { Id = 1, Title = "Apex", Description = "Great Game",Maker= "Electronic Arts", Price=50,CategoryId=1 ,ImageUrl=""},
               new Product { Id = 2, Title = "MapleStory", Description = "ok Game",Maker= "Nexon", Price = 20, CategoryId = 2, ImageUrl = "" },
               new Product { Id = 3, Title = "LeugeOfLeguent", Description = "Amazing Game",Maker = "Riot Games", Price = 70, CategoryId = 3, ImageUrl = "" }
               );


        }
    }
}
