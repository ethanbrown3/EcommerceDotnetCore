using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_project_ethanbrown3.Models
{
    /// <summary>
    /// ProductInventory Model: represents seller's products in inventory.
    /// </summary>
    public class ProductInventory
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImgUrl { get; set; }
        public bool IsEdible { get; set; } 
        public int InventoryCount { get; set; }
    }
}