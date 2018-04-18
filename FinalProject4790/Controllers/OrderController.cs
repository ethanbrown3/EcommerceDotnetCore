using System;
using System.Threading.Tasks;
using FinalProject4790.Models.Domain;
using FinalProject4790.Models.DomainServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace FinalProject4790.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;
        private readonly UserManager<IdentityUser> _userManager;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart, UserManager<IdentityUser> userManager)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        [Authorize]
        public IActionResult Checkout()
        {
            if (_shoppingCart.GetTotalNumberOfItems() == 0)
            {
                ModelState.AddModelError("", "Your cart is empty");
                return RedirectToAction("Index", "ShoppingCart");
            }
            return View();
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Checkout(Order order, string stripeEmail, string stripeToken)
        {
            var items = _shoppingCart.GetShoppingCartLineItems();
            _shoppingCart.ShoppingCartItems = items;

            if (_shoppingCart.GetTotalNumberOfItems() == 0)
            {
                ModelState.AddModelError("", "Your cart is empty");
            }

            if (ModelState.IsValid)
            {
                
                
                var customers = new StripeCustomerService();
                var charges = new StripeChargeService();

                IdentityUser user = await GetCurrentUserAsync();
                var email = user.Email;

                var customer = customers.Create(new StripeCustomerCreateOptions {
                    Email = stripeEmail,
                    SourceToken = stripeToken
                });
                var totalCharge = (int)_shoppingCart.GetShoppingCartTotal() * 100;

                var charge = charges.Create(new StripeChargeCreateOptions {
                    Amount = totalCharge,
                    Description = "Sample Charge",
                    Currency = "usd",
                    CustomerId = customer.Id
                });
                Console.Write(charge);
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();

                return RedirectToAction("CheckoutComplete");
            }
            

            return View(order);
        }
        private Task<IdentityUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thank you for shopping with us!";
            return View();
        }
    }
}