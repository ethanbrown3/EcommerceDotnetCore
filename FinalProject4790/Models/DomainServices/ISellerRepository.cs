using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject4790.Models.Domain;

namespace FinalProject4790.Models.DomainServices
{
    /// <summary>
    /// Seller Model Interface
    /// </summary>
    public interface ISellerRepository
    {
        IEnumerable<Seller> GetAllSellers();
        Seller GetSellerById(int orderId);
        void AddSeller(Seller seller);

    }
}