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
    public class CartLineItem
    {
        public int CartLineItemId { get; set; }
        public int CartLineItemQuantity { get; set; }
        
        public int CartLineItemProductId { get; set; }
        public Product CartLineItemProduct { get; set; }

        public string CartShoppingCartId { get; set; }
    }
}