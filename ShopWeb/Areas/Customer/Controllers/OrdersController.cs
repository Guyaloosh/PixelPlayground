using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopWeb.Models; 
using ShopWeb.Models.ViewModels; 
using ShopWeb.Repository.IRepository;
using System.Linq;
using System.Security.Claims;


namespace ShopWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize] // Ensures only authenticated users
    public class OrdersController : Controller
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public OrdersController(ILogger<OrdersController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

     
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orders = _unitOfWork.OrderHeader.GetAll(o => o.ApplicationUserId == userId, includeProperties: "ApplicationUser");

            //full path to the MyOrders view located in the Home folder
            return View("~/Areas/Customer/Views/Home/MyOrders.cshtml", orders);
        }
      
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var orderHeader = _unitOfWork.OrderHeader
                .GetFirstOrDefault(o => o.Id == id && o.ApplicationUserId == userId, includeProperties: "ApplicationUser");

            if (orderHeader == null)
            {
                return NotFound();
            }

            var orderDetails = _unitOfWork.OrderDetail.GetAll(o => o.OrderHeaderId == orderHeader.Id, includeProperties: "Product");

            var viewModel = new OrderViewModel
            {
                OrderHeader = orderHeader,
                OrderDetails = orderDetails.ToList()
            };

            // path to the OrderDetails view
            return View("~/Areas/Customer/Views/Home/OrderDetails.cshtml", viewModel);
        }

   
    }
}
