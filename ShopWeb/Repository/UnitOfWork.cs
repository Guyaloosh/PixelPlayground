﻿using ShopWeb.Data;
using ShopWeb.Repository.IRepository;

namespace ShopWeb.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }

        public UnitOfWork(ApplicationDbContext db) 
        {
            _db = db;
            ApplicationUser = new ApplicationUserRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
            Category =new CategoryRepository(_db);
            Product=new ProductRepository(_db);
        }
        
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
