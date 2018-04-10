using System;
using FinalProject4790.Models.Domain;

namespace FinalProject4790.Models.DomainServices
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }

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