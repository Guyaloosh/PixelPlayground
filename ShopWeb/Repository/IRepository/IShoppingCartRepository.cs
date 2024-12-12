using ShopWeb.Models;
using System.Linq.Expressions;

namespace ShopWeb.Repository.IRepository
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        void Update(ShoppingCart Obj);
        
    }

}
