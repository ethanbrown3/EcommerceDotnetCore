using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalProject4790.Models;
using FinalProject4790.ViewModels;
using FinalProject4790.Models.DomainServices;
using FinalProject4790.Models.Domain;

namespace FinalProject4790.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IProductRepository productRepository, ShoppingCart shoppingCart)
        {
            _productRepository = productRepository;
            _shoppingCart = shoppingCart;
        }
        
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartLineItems();
            _shoppingCart.ShoppingCartLineItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

                public RedirectToActionResult AddToShoppingCart(int productId)
        {
            var productToAdd = _productRepository.GetProductById(productId);

            if (productToAdd != null)
            {
                _shoppingCart.AddToCart(productToAdd, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int productId)
        {
            var productToRemove = _productRepository.GetProductById(productId);

            if (productToRemove != null)
            {
                _shoppingCart.RemoveFromCart(productToRemove);
            }
            return RedirectToAction("Index");
        }
    }
}