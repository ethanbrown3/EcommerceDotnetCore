using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject4790.Models.Domain;

namespace FinalProject4790.Models.DomainServices
{
    /// <summary>
    /// Mock Seller Data Repository
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            
        }
        
        public IEnumerable<Product> Products;

        public IEnumerable<Product> GetAllProducts()
        {
            return _appDbContext.Products;
        }

        public IEnumerable<Product> GetProductsBySellerId(int sellerId)
        {
            return _appDbContext.Products.Where(p => p.SellerId == sellerId);
        }

        public Product GetProductById(int productId)
        {
            return _appDbContext.Products.FirstOrDefault(p => p.ProductId == productId);
        }
    }
}
