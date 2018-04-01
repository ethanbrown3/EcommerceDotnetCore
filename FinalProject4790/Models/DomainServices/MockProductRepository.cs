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
                    new Product {Id = 0,
                        SellerId=0,
                        ProductName = "Paintballs",
                        ProductShortDescription = "Green and Yellow Shell / Yellow Fill.",
                        ProductLongDescription = "Marballizer Paintballs. These are the best paintballs money can buy! All paintballs are fresh and arrive on a weekly basis. All cases of paint are opened before shipment to ensure that there are no broken paintballs. Once the package has been inspected then it will be re-taped and initialed to verify that it has been checked. All cases of paint are then wrapped in a bubble wrap and placed in a box surrounded by packing paper. Sorry but there are no returns on paintballs that are shipped out. We take every precaution to get you your paint in the best condition and in the shortest time.",
                        ProductPrice = 45.99M,
                        ProductImgUrl="https://cdn3.bigcommerce.com/s-9bkfd/products/400/images/834/Empire_Marballizer_Paintballs_1__97088.1398981336.500.659.jpg?c=2",
                        ProductCount=10,
                        IsEdible=false
                    },
                    new Product {Id = 1,
                        SellerId=1,
                        ProductName = "Tumbler",
                        ProductShortDescription = "Off road vehicle. Comes in black.",
                        ProductLongDescription = "The Tumbler has a pair of machine guns mounted in the nose of the car between the front wheels. In \"Attack\" mode, the driver's seat moves to the center of the car, and the driver is repositioned to lie face-down with his head in the center section between the front wheels. This serves two main purposes: first, it provides more substantial protection with the driver shielded by multiple layers of armor plating. Second, the low-down, centralized driving position makes extreme precision maneuvers easier to perform, while lying prone reduces the risk of injury a driver faces when making these maneuvers.",
                        ProductPrice = 25000000.00M,
                        ProductImgUrl="http://media.comicbook.com/uploads1/2015/01/batmobile-tumbler-118336.jpg",
                        ProductCount=3,
                        IsEdible=false
                    },
                    new Product {Id = 2,
                    SellerId=2,
                        ProductName = "Arc Reactor",
                        ProductShortDescription = "Powers a heart for over 50 lifetimes.",
                        ProductLongDescription = "Engineered by Tony Stark himself in a cave, with scraps.",
                        ProductPrice = 100000000000.00M,
                        ProductImgUrl="https://i0.wp.com/lanteanar-automated-transfer-1.blog/wp-content/uploads/2018/01/iron-man-arc-reactor-mk1-3d-model-max-obj-fbx-mtl-1.jpg?ssl=1",
                        ProductCount=1,
                        IsEdible=false
                    },
                    new Product {Id = 3,
                        SellerId=3,
                        ProductName = "Skin Bleach",
                        ProductShortDescription = "Adverse side affects.",
                        ProductLongDescription = "Probably not FDA approved.",
                        ProductPrice = 10.99M,
                        ProductImgUrl="https://mixedtees.com/image/cache/catalog/data/Shirts/Suicide%20Squad/ACE%20Chemicals/AceChemicals-PLATE-750x750.jpg",
                        ProductCount=100,
                        IsEdible=false
                    },

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
