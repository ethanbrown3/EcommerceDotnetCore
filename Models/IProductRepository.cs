using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_project_ethanbrown3.Models
{
    /// <summary>
    /// Product Model Interface
    /// </summary>
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsBySellerId(int sellerId);
    }
}