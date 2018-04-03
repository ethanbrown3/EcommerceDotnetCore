using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject4790.Models.Domain
{
    /// <summary>
    /// Product Model: represents seller's products in inventory
    /// </summary>
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductShortDescription { get; set; }
        public string ProductLongDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImgUrl { get; set; }
        public bool IsEdible { get; set; } 
        public int ProductCount { get; set; }

        public int SellerId { get; set; }
        public Seller Seller { get; set; }
    }
}