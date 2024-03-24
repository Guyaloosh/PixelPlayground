using ShopWeb.Models;

namespace ShopWeb.Repository.IRepository
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {
        void Update(OrderDetail Obj);
        
    }
}
