using ShopWeb.Data;
using ShopWeb.Models;
using ShopWeb.Repository.IRepository;
using System.Linq.Expressions;

namespace ShopWeb.Repository
{
    public class CategoryRepository :Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db) 
        {
          _db = db;
        }
       

        public void Update(Category Obj)
        {
            _db.Categories.Update(Obj);
        }
    }
}
