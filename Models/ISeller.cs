using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_project_ethanbrown3.Models
{
    /// <summary>
    /// Seller Model Interface
    /// </summary>
    public interface ISeller
    {
        IEnumerable<Seller> GetAllSellers();
        Seller GetSellerById(int pieId);
    }
}