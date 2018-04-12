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
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int CartItemQuantity { get; set; }
        
        public int CartItemProductId { get; set; }
        public Product CartItemProduct { get; set; }

        public string CartShoppingCartId { get; set; }
    }
}