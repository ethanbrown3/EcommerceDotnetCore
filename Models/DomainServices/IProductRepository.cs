using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_project_ethanbrown3.Models.Domain;

namespace final_project_ethanbrown3.Models.DomainServices
{
    /// <summary>
    /// Product Model Interface
    /// </summary>
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsBySellerId(int sellerId);
        Product GetProductById(int id);
    }
}