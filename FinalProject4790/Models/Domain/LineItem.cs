using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FinalProject4790.Models.Domain
{
    /// <summary>
    /// LineItem Model Class: Represents line items in orders
    /// </summary>
    public class LineItem
    {
        public int LineItemId { get; set; }
        public int LineItemQuantity { get; set; }
        
        public int LineItemProductId { get; set; }
        public Product LineItemProduct { get; set; }

        public string ShoppingCartId { get; set; }
    }
}