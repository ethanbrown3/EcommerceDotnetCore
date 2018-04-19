using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject4790.Models.Domain;

namespace FinalProject4790.Models.DomainServices
{
    /// <summary>
    /// Seller model Repository
    /// </summary>
    public class SellerRepository : ISellerRepository
    {
       private readonly AppDbContext _appDbContext;

        public SellerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            
        }
        public IEnumerable<Product> Sellers;

        /// <summary>
        /// Get all sellers objects in the DB
        /// </summary>
        /// <returns>IEnumberable<Seller></returns>
        public IEnumerable<Seller> GetAllSellers()
        {
            return _appDbContext.Sellers;
        }
        
        /// <summary>
        /// Get the seller with matching sellerId
        /// </summary>
        /// <param name="sellerId"></param>
        /// <returns>Seller</returns>
        public Seller GetSellerById(int sellerId)
        {
            return _appDbContext.Sellers.FirstOrDefault(s => s.SellerId == sellerId);
        }
    }
}
