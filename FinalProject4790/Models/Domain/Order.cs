using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FinalProject4790.Models.Domain
{
    /// <summary>
    /// Order Model class: represents orders placed by customers
    /// </summary>
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }
        public List<OrderLineItem> OrderLineItems { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderDate { get; set; }
        public string CreditTransactionId { get; set; }
        [Display(Name = "Last Name")]
        [StringLength(50)]
        [Required(ErrorMessage = "Please Enter Last Name")]
        public string OrderLastName { get; set; }
        [Display(Name = "First Name")]
        [StringLength(50)]
        [Required(ErrorMessage = "Please Enter First Name")]
        public string OrderFirstName { get; set; }
        [Display(Name = "Address 1")]
        [Required(ErrorMessage = "Please Enter a Street Address")]
        public string OrderStreetAddress1 { get; set; }
        [Display(Name = "Address 2")]
        public string OrderStreetAddress2 { get; set; }
        [Display(Name = "City")]
        [Required(ErrorMessage = "Please Enter a City")]
        public string OrderCity { get; set; }
        [Display(Name = "State")]
        [Required(ErrorMessage = "Please Enter a State")]
        public string OrderState { get; set; }
        [Display(Name = "Zip Code")]
        [Required(ErrorMessage = "Please Enter a Zip Code")]
        public string OrderZip { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string OrderPhoneNumber { get; set; }
    }
}