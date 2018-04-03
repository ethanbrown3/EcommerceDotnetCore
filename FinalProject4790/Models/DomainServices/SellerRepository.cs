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
    public class SellerRepository : ISellerRepository
    {
       private readonly AppDbContext _appDbContext;

        public SellerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            
        }
        public IEnumerable<Product> Sellers;


        public IEnumerable<Seller> GetAllSellers()
        {
            return _appDbContext.Sellers;
        }

        public Seller GetSellerById(int sellerId)
        {
            return _appDbContext.Sellers.FirstOrDefault(s => s.SellerId == sellerId);
        }
    }
}
