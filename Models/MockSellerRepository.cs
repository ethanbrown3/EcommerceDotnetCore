using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_project_ethanbrown3.Models
{
    /// <summary>
    /// Mock Seller Data Repository
    /// </summary>
    public class MockSellerRepository : ISellerRepository
    {
        private List< Seller> _Sellers;

        public MockSellerRepository()
        {
            if (_Sellers == null)
            {
                InitializePies();
            }
        }

        private void InitializePies()
        {
	        _Sellers = new List<Seller>
                {
                    new Seller {Id = 1, SellerName = "Paintball Planet", SellerDescription = "Paintball Retailer"},
                    new Seller {Id = 2, SellerName = "Wayne Enterprises", SellerDescription = "Splunking Gear"},
                    new Seller {Id = 3, SellerName = "Stark Industries", SellerDescription = "Science Supply"},
                    new Seller {Id = 4, SellerName = "Ace Chemicals", SellerDescription = "Cleaning Products"},
                };
        }
        
        public IEnumerable<Seller> GetAllSellers()
        {
            return _Sellers;
        }

        public Seller GetSellerById(int sellerId)
        {
            return _Sellers.FirstOrDefault(s => s.Id == sellerId);
        }
    }
}
