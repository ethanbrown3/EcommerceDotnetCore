using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_project_ethanbrown3.Models
{
    /// <summary>
    /// Mock Seller Data Repository
    /// </summary>
    public class MockProductRepository : IProductRepository
    {
        private List<Product> _Products;

        public MockProductRepository()
        {
            if (_Products == null)
            {
                InitializeProducts();
            }
        }

        private void InitializeProducts()
        {
	        _Products = new List<Product>
                {
                    new Product {Id = 0, SellerId=0, ProductName = "Paintballs", ProductDescription = "Green and Yellow Shell / Yellow Fill", ProductPrice = 45.99M, ProductImgUrl="https://cdn3.bigcommerce.com/s-9bkfd/products/400/images/834/Empire_Marballizer_Paintballs_1__97088.1398981336.500.659.jpg?c=2", ProductCount=10, IsEdible=false},
                };
        }
        
        public IEnumerable<Product> GetAllProducts()
        {
            return _Products;
        }

        public IEnumerable<Product> GetProductsBySellerId(int sellerId)
        {
            return _Products.Where(p => p.SellerId == sellerId);
        }
    }
}
