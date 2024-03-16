using ShopWeb.Models;

namespace ShopWeb.Repository.IRepository
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        void Update(ShoppingCart Obj);
        
    }
}
