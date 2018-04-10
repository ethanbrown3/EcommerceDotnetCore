using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalProject4790.Models;
using FinalProject4790.Views.ViewModels;
using FinalProject4790.Models.DomainServices;
using FinalProject4790.Models.Domain;

namespace FinalProject4790.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ShoppingCart _shoppingCart;

        /// <summary>
        /// Controller that handles requests related to the shopping cart
        /// </summary>
        /// <param name="productRepository"></param>
        /// <param name="shoppingCart"></param>
        public ShoppingCartController(IProductRepository productRepository, ShoppingCart shoppingCart)
        {
            _productRepository = productRepository;
            _shoppingCart = shoppingCart;
        }
        
        /// <summary>
        /// Navigates to the shopping cart summary page
        /// </summary>
        /// <returns>Shopping Cart Summary View</returns>
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartLineItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        /// <summary>
        /// After adding an item to a shopping cart, redirect to the shopping cart summary
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>Redirect to Cart Summary</returns>
        public RedirectToActionResult AddToShoppingCart(int productId)
        {
            var productToAdd = _productRepository.GetProductById(productId);

            if (productToAdd != null)
            {
                _shoppingCart.AddToCart(productToAdd, 1);
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Handles requests to remove items from the cart
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>Redirect to Cart Summary</returns>
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