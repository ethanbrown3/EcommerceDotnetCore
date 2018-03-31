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
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;


        public ProductController(IProductRepository productRepository)  // Constructor Injection
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Returns the ProductList View with the list of products for the seller id provided.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ProductsList View</returns>
        public IActionResult ProductList(int id, string sellerName)
        {
            var products = _productRepository.GetProductsBySellerId(id).OrderBy(p => p.ProductName );
            Console.Write(id);
            if (products == null)
                return NotFound();

            var productListViewModel = new ProductListViewModel()
            {
                Title = sellerName,
                Products = products.ToList()
            };
            
            return View(productListViewModel);
        }
        
        /// <summary>
        /// Returns the Product Detail View for the product id provided.
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns>ProductDetail View</returns>
        public IActionResult ProductDetail(int id)
        {
            Product product = _productRepository.GetProductById(id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        /// <summary>
        /// Adds product to order and navigates to order summary screen.
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns>ProductDetail View</returns>
        public IActionResult OrderSummary()
        {

            return View();
        }
    }
}