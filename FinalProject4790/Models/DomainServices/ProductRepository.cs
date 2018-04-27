using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject4790.Models.Domain;

namespace FinalProject4790.Models.DomainServices
{
    /// <summary>
    /// Repository for Product model
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        /// <summary>
        /// Constructor for ProductRepository
        /// </summary>
        /// <param name="appDbContext"></param>
        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            
        }
        
        /// <summary>
        /// IEnumerable of products
        /// </summary>
        public IEnumerable<Product> Products;

        /// <summary>
        /// Return all the products stored in the DB
        /// </summary>
        /// <returns>IEnumerable<Product></returns>
        public IEnumerable<Product> GetAllProducts()
        {
            return _appDbContext.Products;
        }

        /// <summary>
        /// Get Products that belong to given sellerId
        /// </summary>
        /// <param name="sellerId"></param>
        /// <returns></returns>
        public IEnumerable<Product> GetProductsBySellerId(int sellerId)
        {
            return _appDbContext.Products.Where(p => p.SellerId == sellerId);
        }


        public IEnumerable<Product> GetProductsEnabledBySellerId(int sellerId)
        {
            return _appDbContext.Products.Where(p => p.SellerId == sellerId && p.enabled == true);
        }

        /// <summary>
        /// Return product with matching productId
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>Product</returns>
        public Product GetProductById(int productId)
        {
            return _appDbContext.Products.FirstOrDefault(p => p.ProductId == productId);
        }

        /// <summary>
        /// Add Product to DB
        /// </summary>
        /// <param name="product">Product</param>
        public void AddProduct(Product product)
        {
            _appDbContext.Products.Add(product);
            _appDbContext.SaveChanges();
        }

        /// <summary>
        /// Disable a product by id
        /// </summary>
        /// <param name="id">product id</param>
        public void DisableProduct(int id)
        {
            var result = GetProductById(id);
            if (result != null)
            {
                result.enabled = false;
                _appDbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Enable a product by id
        /// </summary>
        /// <param name="id">product id</param>
        public void EnableProduct(int id)
        {
            var result = GetProductById(id);
            if (result != null)
            {
                result.enabled = true;
                _appDbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Update given product in DB
        /// </summary>
        /// <param name="product"></param>
        public void UpdateProduct(Product product)
        {
            _appDbContext.Products.Update(product);
            _appDbContext.SaveChanges();
        }

    }
}
