using System.Collections.Generic;

namespace ShopWeb.Models.ViewModels
{
    public class OrderViewModel
    {
        public OrderHeader OrderHeader { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
