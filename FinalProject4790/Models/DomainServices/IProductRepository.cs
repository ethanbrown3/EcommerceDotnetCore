using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject4790.Models.Domain;

namespace FinalProject4790.Models.DomainServices
{
    /// <summary>
    /// Product Model Interface
    /// </summary>
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsBySellerId(int sellerId);
        IEnumerable<Product> GetProductsEnabledBySellerId(int sellerId);
        Product GetProductById(int id);
        void AddProduct(Product product);
        void DisableProduct(int id);
        void EnableProduct(int id);
        void UpdateProduct(Product product);
        
    }
}