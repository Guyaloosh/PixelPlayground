using ShopWeb.Data;
using ShopWeb.Models;
using ShopWeb.Repository.IRepository;
using System.Linq.Expressions;

namespace ShopWeb.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
	{
        private ApplicationDbContext _db;
        public OrderDetailRepository(ApplicationDbContext db) : base(db) 
        {
          _db = db;
        }
       

        public void Update(OrderDetail Obj)
        {
            _db.OrderDetails.Update(Obj);
        }
    }
}
