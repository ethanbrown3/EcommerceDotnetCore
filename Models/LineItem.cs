using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace final_project_ethanbrown3.Models
{
    public class LineItem
    {
        public int Id { get; set; }
        public int ProductInventoryId { get; set; }
        public int LineItemQuantity { get; set; }
    }
}