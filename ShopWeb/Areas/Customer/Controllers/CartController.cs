using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopWeb.Models;
using ShopWeb.Models.ViewModels;
using ShopWeb.Repository.IRepository;
using ShopWeb.Utility;
using Stripe.Checkout;
using System.Security.Claims;
using static System.Net.WebRequestMethods;

namespace ShopWeb.Areas.Customer.Controllers
{
    [Area("customer")]
   
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public ShoppingCartVM ShoppingCartVM { get; set; }
        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public IActionResult Index()
        {
            var userId = "";
            var claimsIdentity = (ClaimsIdentity)User.Identity;

            if (claimsIdentity.IsAuthenticated)
            {
                userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            }
            else { userId = "5a5e2d8d-7912-4d6d-9bc3-206e5f5dfde8"; }

            ShoppingCartVM = new()
            {
                ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId,
                includeProperties: "product")
                ,
                OrderHeader = new()
            };


            foreach (var cart in ShoppingCartVM.ShoppingCartList)
            {
                cart.Price = GetPriceBasedOnQuantity(cart);
                ShoppingCartVM.OrderHeader.OrderTotal += (cart.Price * cart.Count); 
            }

            return View(ShoppingCartVM);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            var userId = "";
            var claimsIdentity = (ClaimsIdentity)User.Identity;

            if (claimsIdentity.IsAuthenticated)
            {
                userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            }
            else { 
                userId = "5a5e2d8d-7912-4d6d-9bc3-206e5f5dfde8";
                
            }
            // Check if the product already exists in the user's cart
            var existingCartItem = _unitOfWork.ShoppingCart.GetFirstOrDefault(
                cart => cart.ApplicationUserId == userId && cart.ProductId == productId);

            if (existingCartItem != null)
            {
                // Product already in cart, update the count
                existingCartItem.Count += quantity;
                _unitOfWork.ShoppingCart.Update(existingCartItem);
            }
            else
            {
                // Product not in cart, add it
                var cartItem = new ShoppingCart
                {
                    ApplicationUserId = userId,
                    ProductId = productId,
                    Count = quantity
                };
                _unitOfWork.ShoppingCart.Add(cartItem);
            }

            _unitOfWork.Save();
            // Redirect to cart page
            return RedirectToAction("Index", "Cart"); 
        }


        public IActionResult Summary()
        { 
            var userId = "";
            var claimsIdentity = (ClaimsIdentity)User.Identity;

            if (claimsIdentity.IsAuthenticated)
            {
                userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

                ShoppingCartVM = new()
                {
                    ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId,
                    includeProperties: "product")
                    ,
                    OrderHeader = new()
                };

                ShoppingCartVM.OrderHeader.ApplicationUser = _unitOfWork.ApplicationUser.Get(u => u.Id == userId);

                ShoppingCartVM.OrderHeader.Name = ShoppingCartVM.OrderHeader.ApplicationUser.Name;
                ShoppingCartVM.OrderHeader.PhoneNumber = ShoppingCartVM.OrderHeader.ApplicationUser.PhoneNumber;
                ShoppingCartVM.OrderHeader.StreetAddress = ShoppingCartVM.OrderHeader.ApplicationUser.StreetAdress;
                ShoppingCartVM.OrderHeader.City = ShoppingCartVM.OrderHeader.ApplicationUser.City;
                ShoppingCartVM.OrderHeader.State = ShoppingCartVM.OrderHeader.ApplicationUser.State;
                ShoppingCartVM.OrderHeader.PostalCode = ShoppingCartVM.OrderHeader.ApplicationUser.PostalCode;

            }
            else { userId = "5a5e2d8d-7912-4d6d-9bc3-206e5f5dfde8";
                ShoppingCartVM = new()
                {
                    ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId,
                       includeProperties: "product")
                       ,
                    OrderHeader = new()
                };

            }

            foreach (var cart in ShoppingCartVM.ShoppingCartList)
            {
                cart.Price = GetPriceBasedOnQuantity(cart);
                ShoppingCartVM.OrderHeader.OrderTotal += (cart.Price * cart.Count);
            }
            
            return View(ShoppingCartVM);
        }
        [HttpPost]
        [ActionName("Summary")]
        public IActionResult SummaryPOST()
        {
            var userId = "";
            var claimsIdentity = (ClaimsIdentity)User.Identity;

            if (claimsIdentity.IsAuthenticated)
            {
                userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            }
            else { userId = "5a5e2d8d-7912-4d6d-9bc3-206e5f5dfde8"; }


            ShoppingCartVM.ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId,
                includeProperties: "product");

            ShoppingCartVM.OrderHeader.OrderDate = System.DateTime.Now;
            ShoppingCartVM.OrderHeader.ApplicationUserId = userId;

            ShoppingCartVM.OrderHeader.ApplicationUser = _unitOfWork.ApplicationUser.Get(u => u.Id == userId);

            foreach (var cart in ShoppingCartVM.ShoppingCartList)
            {
                cart.Price = GetPriceBasedOnQuantity(cart);
                ShoppingCartVM.OrderHeader.OrderTotal += (cart.Price * cart.Count);

                // Check if the quantity of the product is sufficient
                if (cart.product.Quantity < cart.Count)
                {
                    TempData["error"] = "There is not enough of " + cart.product.Title + " available. Please try again later.";
                    return RedirectToAction(nameof(Index));
                }
            }

            ShoppingCartVM.OrderHeader.PaymentStatus = SD.PaymentStatusPending;
            ShoppingCartVM.OrderHeader.OrderStatus = SD.StatusPending;

            _unitOfWork.OrderHeader.Add(ShoppingCartVM.OrderHeader);
            _unitOfWork.Save();

            foreach (var cart in ShoppingCartVM.ShoppingCartList)
            {
                OrderDetail orderDetail = new()
                {
                    ProductId = cart.ProductId,
                    OrderHeaderId = ShoppingCartVM.OrderHeader.Id,
                    Price = cart.Price * cart.Count,
                    Count = cart.Count,
                };
                _unitOfWork.OrderDetail.Add(orderDetail);
                _unitOfWork.Save();
            }

            //local host
            var domain = "https://localhost:7034/";

            var options = new Stripe.Checkout.SessionCreateOptions
            {
                SuccessUrl = domain + $"customer/cart/OrderConfirmation?id={ShoppingCartVM.OrderHeader.Id}",
                CancelUrl = domain + "customer/cart/index",
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
            };

            foreach (var item in ShoppingCartVM.ShoppingCartList)
            {
                var sessionLineItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(item.Price * 100), 
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = item.product.Title
                        }
                    },
                    Quantity = item.Count,
                };

                options.LineItems.Add(sessionLineItem);
            }
            
            var service = new Stripe.Checkout.SessionService();
            Session session = service.Create(options);

            _unitOfWork.OrderHeader.UpdateStripePaymentID(ShoppingCartVM.OrderHeader.Id, session.Id, session.PaymentIntentId);
            _unitOfWork.Save();
            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }

        public IActionResult OrderConfirmation(int id)
        {
            var userId = "";
            var claimsIdentity = (ClaimsIdentity)User.Identity;

            if (claimsIdentity.IsAuthenticated)
            {
                userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            }
            else { userId = "5a5e2d8d-7912-4d6d-9bc3-206e5f5dfde8"; }


            ShoppingCartVM = new()
			{
				ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId,
	            includeProperties: "product")
			};

			OrderHeader orderHeader = _unitOfWork.OrderHeader.GetFirstOrDefault(u => u.Id == id, includeProperties: "ApplicationUser");
            
            if(orderHeader == null)
            {
				return PayPalConfirmation(id);
			}
            
                if (orderHeader.PaymentStatus != SD.PaymentStatusDelayedPayment)
                {
                    var service = new SessionService();
                    Session session = service.Get(orderHeader.SessionId);
                    //check the stripe status
                    if (session.PaymentStatus.ToLower() == "paid")
                    {
                        _unitOfWork.OrderHeader.UpdateStripePaymentID(id, orderHeader.SessionId, session.PaymentIntentId);
                        _unitOfWork.OrderHeader.UpdateStatus(id, SD.StatusApproved, SD.PaymentStatusApproved);
                        _unitOfWork.Save();
                    }
                }

            //payment was successeful - remove the cart from data base
            List<ShoppingCart> shoppingCarts = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId ==
            orderHeader.ApplicationUserId).ToList();

            //update the quantity in the database.
            ShoppingCartVM.ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId,
                includeProperties: "product");

            foreach (var cart in ShoppingCartVM.ShoppingCartList)
            {
                cart.product.Quantity -= cart.Count;
                cart.product.Sold += cart.Count;
            }

            _unitOfWork.ShoppingCart.RemoveRange(shoppingCarts);
            _unitOfWork.Save();
            return View(id);
        }

        public IActionResult PayPalConfirmation(int id)
        {
            var userId = "";
            var claimsIdentity = (ClaimsIdentity)User.Identity;

            if (claimsIdentity.IsAuthenticated)
            {
                userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            }
            else { userId = "5a5e2d8d-7912-4d6d-9bc3-206e5f5dfde8"; }


            ShoppingCartVM = new()
			{
				ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId,
				includeProperties: "product")
				,
				OrderHeader = new()
			};

			ShoppingCartVM.OrderHeader.ApplicationUser = _unitOfWork.ApplicationUser.Get(u => u.Id == userId);

			ShoppingCartVM.OrderHeader.Name = ShoppingCartVM.OrderHeader.ApplicationUser.Name;
			ShoppingCartVM.OrderHeader.PhoneNumber = ShoppingCartVM.OrderHeader.ApplicationUser.PhoneNumber;
			ShoppingCartVM.OrderHeader.StreetAddress = ShoppingCartVM.OrderHeader.ApplicationUser.StreetAdress;
			ShoppingCartVM.OrderHeader.City = ShoppingCartVM.OrderHeader.ApplicationUser.City;
			ShoppingCartVM.OrderHeader.State = ShoppingCartVM.OrderHeader.ApplicationUser.State;
			ShoppingCartVM.OrderHeader.PostalCode = ShoppingCartVM.OrderHeader.ApplicationUser.PostalCode;


			foreach (var cart in ShoppingCartVM.ShoppingCartList)
			{
				cart.Price = GetPriceBasedOnQuantity(cart);
				ShoppingCartVM.OrderHeader.OrderTotal += (cart.Price * cart.Count);
			}


			ShoppingCartVM.OrderHeader.OrderDate = System.DateTime.Now;
			ShoppingCartVM.OrderHeader.ApplicationUserId = userId;

			_unitOfWork.OrderHeader.Add(ShoppingCartVM.OrderHeader);
			_unitOfWork.Save();

			foreach (var cart in ShoppingCartVM.ShoppingCartList)
			{
				OrderDetail orderDetail = new()
				{
					ProductId = cart.ProductId,
					OrderHeaderId = ShoppingCartVM.OrderHeader.Id,
					Price = cart.Price * cart.Count,
					Count = cart.Count,
				};
				_unitOfWork.OrderDetail.Add(orderDetail);
				_unitOfWork.Save();
			}
            
			//payment was successeful - remove the cart from data base
			List<ShoppingCart> shoppingCarts = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId ==
			ShoppingCartVM.OrderHeader.ApplicationUserId).ToList();

            //update payment status
            ShoppingCartVM.OrderHeader.PaymentStatus = SD.PaymentStatusApproved;
            ShoppingCartVM.OrderHeader.OrderStatus = SD.StatusApproved;


            //update the quantity in the database.
            ShoppingCartVM.ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId,
				includeProperties: "product");

			foreach (var cart in ShoppingCartVM.ShoppingCartList)
			{
				cart.product.Quantity -= cart.Count;
				cart.product.Sold += cart.Count;
			}
            //clean the cart.
			_unitOfWork.ShoppingCart.RemoveRange(shoppingCarts);
			_unitOfWork.Save();

			return View(ShoppingCartVM.OrderHeader.Id);
        }

        public IActionResult Plus(int cartId, ShoppingCart shoppingCart)
        {
            var cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.Id == cartId);
            cartFromDb.Count += 1;
            //cartFromDb.product.tempQuantity -= 1;
            _unitOfWork.ShoppingCart.Update(cartFromDb);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));

        }


        public IActionResult Minus(int cartId)
        {
            var cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.Id == cartId);
            if (cartFromDb.Count <= 1)
            {
                _unitOfWork.ShoppingCart.Remove(cartFromDb);
            }
            else
            {
                cartFromDb.Count -= 1;
                _unitOfWork.ShoppingCart.Update(cartFromDb);

            }
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int cartId)
        {
            var cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.Id == cartId);
            _unitOfWork.ShoppingCart.Remove(cartFromDb);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        private decimal GetPriceBasedOnQuantity(ShoppingCart shoppingCart)
        {
            return shoppingCart.product.Price;
        }
    }
}
