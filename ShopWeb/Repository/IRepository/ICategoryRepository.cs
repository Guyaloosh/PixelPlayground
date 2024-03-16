using ShopWeb.Models;

namespace ShopWeb.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product Obj);
        
    }
}
