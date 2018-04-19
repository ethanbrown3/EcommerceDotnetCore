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
        private readonly ICreditTransactionRepository _creditTransactionRepository;
        private readonly ShoppingCart _shoppingCart;
        private readonly UserManager<IdentityUser> _userManager;
        
        /// <summary>
        /// OrderController Constructor
        /// </summary>
        /// <param name="orderRepository"></param>
        /// <param name="shoppingCart"></param>
        /// <param name="userManager"></param>
        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart, UserManager<IdentityUser> userManager, ICreditTransactionRepository creditTransactionRepository)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
            _userManager = userManager;
            _creditTransactionRepository = creditTransactionRepository;
        }

        /// <summary>
        /// Checkout Screen
        /// </summary>
        /// <returns>Checkout View</returns>
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

        /// <summary>
        /// Creates an Order and CreditTransaction using input from the customer and stripe to charge their card.
        /// </summary>
        /// <param name="order">Order from view form</param>
        /// <param name="stripeEmail">Email from stripe form</param>
        /// <param name="stripeToken">Stripe auth token</param>
        /// <returns>IActionResult CheckoutComplete</returns>
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

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("","");
                return View(order);   
            }
            var customers = new StripeCustomerService();
            var charges = new StripeChargeService();

            IdentityUser user = await GetCurrentUserAsync();
            var email = user.Email;

            var customer = customers.Create(new StripeCustomerCreateOptions {
                Email = user.Email,
                SourceToken = stripeToken
            });
            var totalCharge = (int)_shoppingCart.GetShoppingCartTotal() * 100;

            // create the Stripe.net charge
            var charge = charges.Create(new StripeChargeCreateOptions {
                Amount = totalCharge,
                Description = "Sample Charge",
                Currency = "usd",
                CustomerId = customer.Id
            });


            order.OrderUserId = user.Id;
            
            _creditTransactionRepository.CreateCreditTransactionFromStripeCharge(charge, order);
            _orderRepository.CreateOrder(order);
            _shoppingCart.ClearCart();

            return RedirectToAction("CheckoutComplete");
        }

        /// <summary>
        /// Get current logged in user
        /// </summary>
        /// <returns></returns>
        private Task<IdentityUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        /// <summary>
        /// Checkout Complete view
        /// </summary>
        /// <returns></returns>
        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thank you for shopping with us!";
            return View();
        }
    }
}