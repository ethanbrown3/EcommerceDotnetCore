using System.Collections.Generic;
using FinalProject4790.Models.Domain;
using FinalProject4790.Models.DomainServices;
using FinalProject4790.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject4790.Views.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartLineItems();
            // var items = new List<LineItem>() { new LineItem(), new LineItem() };
            _shoppingCart.ShoppingCartLineItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(shoppingCartViewModel);
        }
    }
}