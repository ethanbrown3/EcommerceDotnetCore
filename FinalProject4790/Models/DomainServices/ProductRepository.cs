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

        /// <summary>
        /// Return product with matching productId
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>Product</returns>
        public Product GetProductById(int productId)
        {
            return _appDbContext.Products.FirstOrDefault(p => p.ProductId == productId);
        }
    }
}
