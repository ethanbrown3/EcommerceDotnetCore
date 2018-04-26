using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject4790.Models.Domain;

namespace FinalProject4790.Models.DomainServices
{
    /// <summary>
    /// Mock Seller Data Repository
    /// </summary>
    public class MockOrderRepository : IOrderRepository
    {
        private List<Order> _Orders;

        public MockOrderRepository()
        {
            if (_Orders == null)
            {
                InitializeOrders();
            }
        }

        private void InitializeOrders()
        {
	        _Orders = new List<Order>
                {
                    new Order {
                        OrderId = 0,
                        OrderTotalInCents = 100,
                        OrderDate = new DateTime(2000, 1, 1, 1, 1, 1),
                        OrderFirstName = "TestFirst",
                        OrderLastName = "TestLast",
                        OrderStreetAddress1 = "Street1",
                        OrderCity = "City",
                        OrderState = "State",
                        OrderZip = "Zip",
                        OrderPhoneNumber = "123456789"
                    }
                };
        }

        public void CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
