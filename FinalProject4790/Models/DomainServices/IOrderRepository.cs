using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject4790.Models.Domain;

namespace FinalProject4790.Models.DomainServices
{
    /// <summary>
    /// Order Model Interface
    /// </summary>
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders();
        IEnumerable<Order> GetAllSellersOrders(int sellerId);
        IEnumerable<Order> GetAllUserOrders(int userId);
        Order GetOrderById(int orderId);
    }
}