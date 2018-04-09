using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject4790.Models.Domain;
 

namespace FinalProject4790.ViewModels
{
    public class OrderSummaryViewModel
    {
       public List<CartItem> OrderLineItems { get; set; }
    }
}