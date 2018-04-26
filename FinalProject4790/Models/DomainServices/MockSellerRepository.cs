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
    public class MockSellerRepository : ISellerRepository
    {
        private List< Seller> _Sellers;

        public MockSellerRepository()
        {
            if (_Sellers == null)
            {
                InitializeSellers();
            }
        }

        private void InitializeSellers()
        {
	        _Sellers = new List<Seller>
                {
                    new Seller {SellerId = 0, SellerName = "Paintball Planet", SellerDescription = "Paintball Retailer"},
                    new Seller {SellerId = 1, SellerName = "Wayne Enterprises", SellerDescription = "Splunking Gear"},
                    new Seller {SellerId = 2, SellerName = "Stark Industries", SellerDescription = "Science Supply"},
                    new Seller {SellerId = 3, SellerName = "Ace Chemicals", SellerDescription = "Cleaning Products"},
                };
        }
        
        public IEnumerable<Seller> GetAllSellers()
        {
            return _Sellers;
        }

        public IEnumerable<Seller> GetAllEnabledSellers()
        {
            return _Sellers.Where(s => s.enabled == true);
        }

        public Seller GetSellerById(int sellerId)
        {
            return _Sellers.FirstOrDefault(s => s.SellerId == sellerId);
        }

        public void AddSeller(Seller seller)
        {
            _Sellers.Add(seller);
        }

        public void DisableSeller(int id)
        {
            var seller = GetSellerById(id);
            if (seller != null)
            {
                seller.enabled = false;
            }
        }

        public void EnableSeller(int id)
        {
            var seller = GetSellerById(id);
            if (seller != null)
            {
                seller.enabled = true;
            }
        }

        public void UpdateSeller(Seller seller)
        {
            throw new NotImplementedException();
        }
    }
}
