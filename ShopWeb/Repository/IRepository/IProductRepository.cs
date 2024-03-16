using ShopWeb.Models;

namespace ShopWeb.Repository.IRepository
{
    public interface ICategoryRepository :IRepository<Category>
    {
        void Update(Category Obj);
        
    }
}
