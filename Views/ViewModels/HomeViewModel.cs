using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_project_ethanbrown3.Models;
 

namespace final_project_ethanbrown3.ViewModels
{
    public class HomeViewModel
    {
       public string Title { get; set; }
       public List<Seller> Sellers { get; set; }
    }
}