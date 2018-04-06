using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FinalProject4790.Models.Domain;

namespace FinalProject4790.Models.DomainServices
{
    public class ShoppingCart
    {
        private readonly AppDbContext _appDbContext;
        public ShoppingCart(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public string ShoppingCartId { get; set; }

        public List<LineItem> ShoppingCartLineItems { get; set; }

        /// <summary>
        /// Returns a shopping cart based on the Session
        /// </summary>
        /// <param name="services"></param>
        /// <returns>New ShoppingCart</returns>
        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<AppDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        /// <summary>
        /// Adds product and the ammount of the product to the cart
        /// </summary>
        /// <param name="product"></param>
        /// <param name="amount"></param>
        public void AddToCart(Product product, int amount)
        {
            var shoppingCartLineItem =
                    _appDbContext.LineItems.SingleOrDefault(
                        s => s.LineItemProduct.ProductId == product.ProductId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartLineItem == null)
            {
                shoppingCartLineItem = new LineItem
                {
                    ShoppingCartId = ShoppingCartId,
                    LineItemProduct = product,
                    LineItemQuantity = amount
                };

                _appDbContext.LineItems.Add(shoppingCartLineItem);
            }
            else
            {
                shoppingCartLineItem.LineItemQuantity += amount;
            }
            _appDbContext.SaveChanges();
        }

        /// <summary>
        /// Removes 1 of the given product from cart
        /// </summary>
        /// <param name="product"></param>
        /// <returns>Amount of item left in cart</returns>
        public int RemoveFromCart(Product product)
        {
            var shoppingCartLineItem =
                    _appDbContext.LineItems.SingleOrDefault(
                        s => s.LineItemProduct.ProductId == product.ProductId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartLineItem != null)
            {
                if (shoppingCartLineItem.LineItemQuantity > 1)
                {
                    shoppingCartLineItem.LineItemQuantity--;
                    localAmount = shoppingCartLineItem.LineItemQuantity;
                }
                else
                {
                    _appDbContext.LineItems.Remove(shoppingCartLineItem);
                }
            }

            _appDbContext.SaveChanges();

            return localAmount;
        }

        /// <summary>
        /// Returns a list of all the shopping cart's LineItems
        /// </summary>
        /// <returns>List of LineItems</returns>
        public List<LineItem> GetShoppingCartLineItems()
        {
            return ShoppingCartLineItems ??
                   (ShoppingCartLineItems =
                       _appDbContext.LineItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.LineItemProduct)
                           .ToList());
        }

        /// <summary>
        /// Clears all products out of the cart
        /// </summary>
        public void ClearCart()
        {
            var cartItems = _appDbContext
                .LineItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _appDbContext.LineItems.RemoveRange(cartItems);

            _appDbContext.SaveChanges();
        }


        /// <summary>
        /// Returns the total for the shopping cart. Total comes from suming all the products price's * amount.
        /// </summary>
        /// <returns>decimal total</returns>
        public decimal GetShoppingCartTotal()
        {
            var total = _appDbContext.LineItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.LineItemProduct.ProductPrice * c.LineItemQuantity).Sum();
            return total;
        }
    }
}
