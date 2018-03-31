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
                    new Product {Id = 0, SellerId=0, ProductName = "Paintballs", ProductDescription = "Green and Yellow Shell / Yellow Fill.", ProductPrice = 45.99M, ProductImgUrl="https://cdn3.bigcommerce.com/s-9bkfd/products/400/images/834/Empire_Marballizer_Paintballs_1__97088.1398981336.500.659.jpg?c=2", ProductCount=10, IsEdible=false},
                    new Product {Id = 1, SellerId=1, ProductName = "Tumbler", ProductDescription = "Off road vehicle. Comes in black.", ProductPrice = 25000000.00M, ProductImgUrl="http://media.comicbook.com/uploads1/2015/01/batmobile-tumbler-118336.jpg", ProductCount=3, IsEdible=false},
                    new Product {Id = 2, SellerId=2, ProductName = "Arc Reactor", ProductDescription = "Powers a heart for over 50 lifetimes.", ProductPrice = 100000000000.00M, ProductImgUrl="https://i0.wp.com/lanteanar-automated-transfer-1.blog/wp-content/uploads/2018/01/iron-man-arc-reactor-mk1-3d-model-max-obj-fbx-mtl-1.jpg?ssl=1", ProductCount=1, IsEdible=false},
                    new Product {Id = 3, SellerId=3, ProductName = "Skin Bleach", ProductDescription = "Adverse side affects.", ProductPrice = 10.99M, ProductImgUrl="https://mixedtees.com/image/cache/catalog/data/Shirts/Suicide%20Squad/ACE%20Chemicals/AceChemicals-PLATE-750x750.jpg", ProductCount=100, IsEdible=false},

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

        public Product GetProductById(int productId)
        {
            return _Products.FirstOrDefault(p => p.Id == productId);
        }
    }
}
