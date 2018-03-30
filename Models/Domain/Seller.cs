using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace final_project_ethanbrown3.Models.Domain
{
    /// <summary>
    /// Seller Model Class: Represents sellers in the application
    /// </summary>
    public class Seller
    {
        public int Id { get; set; }
        public string SellerName { get; set; }
        public string SellerDescription { get; set; }
    }
}