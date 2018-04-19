using System;
using FinalProject4790.Models.Domain;

namespace FinalProject4790.Models.DomainServices
{
    /// <summary>
    /// Repository for Orders
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;

        /// <summary>
        /// Constructor for OrderRepository
        /// </summary>
        /// <param name="appDbContext"></param>
        /// <param name="shoppingCart"></param>
        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }

        /// <summary>
        /// Save passed in Order in DB
        /// </summary>
        /// <param name="order"></param>
        public void CreateOrder(Order order)
        {
            order.OrderDate = DateTime.Now;

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;
            _appDbContext.Orders.Add(order);
            foreach(var shoppingCartItem in shoppingCartItems)
            {
                var orderLineItem = new OrderLineItem()
                {
                    OrderLineItemQuantity = shoppingCartItem.CartItemQuantity,
                    ProductId = shoppingCartItem.CartItemProductId,
                    OrderId = order.OrderId,
                    OrderLineItemPrice = shoppingCartItem.CartItemProduct.ProductPrice
                };

                _appDbContext.OrderLineItems.Add(orderLineItem);
            }
            _appDbContext.SaveChanges();
        }
    }
}