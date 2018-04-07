using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FinalProject4790.Models.Domain
{
    /// <summary>
    /// Order Model class: represents orders placed by customers
    /// </summary>
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string CreditTransactionId { get; set; }
        public int UserId { get; set; }
        public List<LineItem> OrderLineItems { get; set; }
    }
}