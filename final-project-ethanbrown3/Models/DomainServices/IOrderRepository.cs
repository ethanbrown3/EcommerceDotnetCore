using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using final_project_ethanbrown3.Models.Domain;

namespace final_project_ethanbrown3.Models.DomainServices
{
    /// <summary>
    /// Order Model Interface
    /// </summary>
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int orderId);
    }
}