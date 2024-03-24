using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopWeb.Models;
using ShopWeb.Repository.IRepository;
using System.Diagnostics;
using System.Security.Claims;

namespace ShopWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger,IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category");

            // Ensure ViewBag.Categories is populated
            ViewBag.Categories = _unitOfWork.Category.GetAll().ToList();

            return View(productList);
        }
        public IActionResult Details(int productId)
        {
            ShoppingCart cart = new()
            {
                product = _unitOfWork.Product.Get(u => u.Id == productId, includeProperties: "Category"),
                Count = 1,
                ProductId = productId
            };
            return View(cart);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Details(ShoppingCart shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            shoppingCart.ApplicationUserId = userId;

            ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.ApplicationUserId == userId &&
            u.ProductId == shoppingCart.ProductId);

            if(cartFromDb != null)
            {
                //shoppingCart Exists.
                cartFromDb.Count += shoppingCart.Count;
                _unitOfWork.ShoppingCart.Update(cartFromDb);
            }
            else
            {
                _unitOfWork.ShoppingCart.Add(shoppingCart);
            }

            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public IActionResult Filter(string[] selectedCategories, decimal? minPrice, decimal? maxPrice)
        {
            IEnumerable<Product> filteredProducts = _unitOfWork.Product.GetAll(includeProperties: "Category");

            if (selectedCategories.Any())
            {
                filteredProducts = filteredProducts.Where(p => selectedCategories.Contains(p.CategoryId.ToString()));
            }
            if (minPrice.HasValue)
            {
                filteredProducts = filteredProducts.Where(p => p.Price >= minPrice.Value);
            }
            if (maxPrice.HasValue)
            {
                filteredProducts = filteredProducts.Where(p => p.Price <= maxPrice.Value);
            }

            // Assuming "_ProductListPartial" is your partial view to display the product list.
            return PartialView("_ProductListPartial", filteredProducts);
        }
        [HttpGet]
        public IActionResult SortProducts(string sortType)
        {
            IEnumerable<Product> sortedProducts = null;

            switch (sortType)
            {
                case "PriceHighToLow":
                    sortedProducts = _unitOfWork.Product.GetAll(includeProperties: "Category")
                        .OrderByDescending(p => p.Price);
                    break;
                case "PriceLowToHigh":
                    sortedProducts = _unitOfWork.Product.GetAll(includeProperties: "Category")
                        .OrderBy(p => p.Price);
                    break;
                case "Trending":
                    // Implement your trending sorting logic here
                    // Example: sorting by product name alphabetically
                    sortedProducts = _unitOfWork.Product.GetAll(includeProperties: "Category")
                        .OrderBy(p => p.Title);
                    break;
                default:
                    // Default sorting if sortType is not recognized
                    sortedProducts = _unitOfWork.Product.GetAll(includeProperties: "Category");
                    break;
            }

            // Render the sorted products as a partial view
            return PartialView("_ProductListPartial", sortedProducts);
        }


    }
}
