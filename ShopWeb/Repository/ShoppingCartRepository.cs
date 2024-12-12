using Microsoft.EntityFrameworkCore;
using ShopWeb.Data;
using ShopWeb.Models;
using ShopWeb.Repository.IRepository;
using System.Linq.Expressions;

namespace ShopWeb.Repository
{
    public class ShoppingCartRepository :Repository<ShoppingCart>, IShoppingCartRepository
    {
        private ApplicationDbContext _db;
        public ShoppingCartRepository(ApplicationDbContext db) : base(db) 
        {
          _db = db;
        }
        // Modify your repository method to include the related product
        public IEnumerable<ShoppingCart> GetAllWithProduct(Expression<Func<ShoppingCart, bool>> filter = null,
            Func<IQueryable<ShoppingCart>, IOrderedQueryable<ShoppingCart>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<ShoppingCart> query = _db.ShoppingCarts;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }



        public void Update(ShoppingCart Obj)
        {
            _db.ShoppingCarts.Update(Obj);
        }
    }
}
