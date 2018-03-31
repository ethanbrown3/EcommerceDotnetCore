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
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormatAttribute(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }
        public int LineItemId { get; set; }
        public int SellerId { get; set; }
    }
}