using System.Collections.Generic;
using System.Threading.Tasks;
using FinalProject4790.Auth;
using FinalProject4790.Models.Domain;
using FinalProject4790.Models.DomainServices;
using FinalProject4790.Views.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject4790.Controllers
{
    [Authorize(Roles="Admins, SellerAdmin")]
    public class ProductManagement : Controller
    {

        private IProductRepository _productRepository;
        private readonly UserManager<AppUser> _userManager;

        public ProductManagement(IProductRepository productRepository, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _productRepository = productRepository;
        }
        /// <summary>
        /// Product Management Screen
        /// </summary>
        /// <returns>ProductManagment View</returns>
        public IActionResult Index()
        {
            var userGet = GetCurrentUserAsync();
            var user = userGet.Result;
            IEnumerable<Product> products;
            if (user.SellerId == 0)
                products = _productRepository.GetAllProducts();
            else
                products = _productRepository.GetProductsBySellerId(user.SellerId);

            return View(products);
        }

        /// <summary>
        /// Get current logged in user
        /// </summary>
        /// <returns>IdentityUser user</returns>
        private Task<AppUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        /// <summary>
        /// Add Product screen
        /// </summary>
        /// <returns>AddProduct View</returns>
        public IActionResult AddProduct()
        {
            return View();
        }

        /// <summary>
        /// Add Product to DB
        /// </summary>
        /// <param name="ProductEditViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddProduct(ProductEditViewModel productEditViewModel)
        {
            if (!ModelState.IsValid) 
                return View(productEditViewModel);

            _productRepository.AddProduct(productEditViewModel.Product);
        
            return RedirectToAction("Index", _productRepository.GetAllProducts());
        }

        /// <summary>
        /// Disable Product to DB
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DisableProduct(int id)
        {
            _productRepository.DisableProduct(id);
        
            return RedirectToAction("Index", _productRepository.GetAllProducts());
        }

        /// <summary>
        /// Enable Product to DB
        /// </summary>
        /// <param name="addUserViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult EnableProduct(int id)
        {
            _productRepository.EnableProduct(id);
        
            return RedirectToAction("Index", _productRepository.GetAllProducts());
        }

        /// <summary>
        /// Edit Product Form
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Edit Product View</returns>
        public IActionResult EditProduct(int id)
        {
            var product = _productRepository.GetProductById(id);

            var productEditViewModel = new ProductEditViewModel
            {
                Product = product
            };

            return View(productEditViewModel);
        }

        /// <summary>
        /// Edit Product with productEditViewModel
        /// </summary>
        /// <param name="productEditViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult EditProduct(ProductEditViewModel productEditViewModel)
        {

            if (ModelState.IsValid)
            {
                _productRepository.UpdateProduct(productEditViewModel.Product);
                return RedirectToAction("Index");
            }
            return View(productEditViewModel);
        }
    
    }
}