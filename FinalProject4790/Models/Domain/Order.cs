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
        public List<OrderLineItem> OrderLineItems { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTime OrderDate { get; set; }
        public string CreditTransactionId { get; set; }
        public int UserId { get; set; }
        public string OrderFirstName { get; set; }
        public string OrderLastName { get; set; }
        public string OrderAddressLine1 { get; set; }
        public string OrderAddressLine2 { get; set; }
        public string OrderZipCode { get; set; }
        public string OrderCity { get; set; }
        public string OrderState { get; set; }
        public string OrderCountry { get; set; }
        public string OrderPhoneNumber { get; set; }
    }
}