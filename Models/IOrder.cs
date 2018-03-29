using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_project_ethanbrown3.Models
{
    /// <summary>
    /// Order Model Interface
    /// </summary>
    public interface IOrder
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int pieId);
    }
}