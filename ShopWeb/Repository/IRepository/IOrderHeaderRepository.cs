using ShopWeb.Models;

namespace ShopWeb.Repository.IRepository
{
    public interface IOrderHeaderRepository : IRepository<OrderHeader>
    {
        void Update(OrderHeader Obj);
        
    }
}
