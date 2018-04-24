using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FinalProject4790.Models.Domain
{
    /// <summary>
    /// Seller Model Class: Represents sellers in the application
    /// </summary>
    public class Seller
    {
        public int SellerId { get; set; }
        public string SellerName { get; set; }
        public string SellerDescription { get; set; }
        public bool enabled { get; set; }
        
        public List<Product> Products { get; set; }
    }
}