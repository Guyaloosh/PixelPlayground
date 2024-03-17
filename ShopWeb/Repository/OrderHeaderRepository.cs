using ShopWeb.Data;
using ShopWeb.Models;
using ShopWeb.Repository.IRepository;
using System.Linq.Expressions;

namespace ShopWeb.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
	{
        private ApplicationDbContext _db;
        public OrderHeaderRepository(ApplicationDbContext db) : base(db) 
        {
          _db = db;
        }
       

        public void Update(OrderHeader Obj)
        {
            _db.OrderHeaders.Update(Obj);
        }
    }
}
