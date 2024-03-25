using ShopWeb.Data;
using ShopWeb.Models;
using ShopWeb.Repository.IRepository;
using System.Linq.Expressions;

namespace ShopWeb.Repository
{
    public class ProductRepository :Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db) 
        {
          _db = db;
        }
       

        public void Update(Product Obj)
        {
           var objFormDB=_db.Products.FirstOrDefault(u=>u.Id == Obj.Id);
            if (objFormDB != null)
            {//update existing product

                objFormDB.Title = Obj.Title;
                objFormDB.Description = Obj.Description;
                objFormDB.Price = Obj.Price;
                objFormDB.PublishPrice = Obj.PublishPrice;
                objFormDB.Maker = Obj.Maker;
                objFormDB.MinAge = Obj.MinAge;
                objFormDB.RealishDate = Obj.RealishDate;
                objFormDB.CategoryId = Obj.CategoryId;
                objFormDB.onSale = Obj.onSale;
                objFormDB.Quantity = Obj.Quantity;
                objFormDB.Position = Obj.Position;
                if(Obj.ImageUrl != null)
                {
                    objFormDB.ImageUrl = Obj.ImageUrl;
                }
            }
        }
    }
}
