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
        private ShoppingCart(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public string ShoppingCartId { get; set; }

        public List<LineItem> ShoppingCartLineItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<AppDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

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

        public List<LineItem> GetShoppingCartLineItems()
        {
            return ShoppingCartLineItems ??
                   (ShoppingCartLineItems =
                       _appDbContext.LineItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.LineItemProduct)
                           .ToList());
        }

        public void ClearCart()
        {
            var cartItems = _appDbContext
                .LineItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _appDbContext.LineItems.RemoveRange(cartItems);

            _appDbContext.SaveChanges();
        }



        public decimal GetShoppingCartTotal()
        {
            var total = _appDbContext.LineItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.LineItemProduct.ProductPrice * c.LineItemQuantity).Sum();
            return total;
        }
    }
}
