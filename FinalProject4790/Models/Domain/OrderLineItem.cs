using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FinalProject4790.Models.Domain
{
    /// <summary>
    /// OrderLineItem Model class: represents items that are part of an order
    /// </summary>
    public class OrderLineItem
    {
        public int OrderLineItemId { get; set; }
        public decimal OrderLineItemPrice { get; set; }
        public int OrderLineItemQuantity { get; set; }
        public Product OrderProduct { get; set; }
        public int ProductId { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }

    }
}