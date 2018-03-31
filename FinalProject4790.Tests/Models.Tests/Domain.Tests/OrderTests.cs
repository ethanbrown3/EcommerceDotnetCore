using System;
using NUnit.Framework;
using FinalProject4790.Controllers;
using FinalProject4790.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace FinalProject4790.Tests.Models.Domain.Tests
{
    public class OrderTests
    {
        private Order order;

        [SetUp]
        public void Setup()
        {
            // Arrange
            order = new Order();
        }

        [Test]
        public void OrderSetGetId()
        {
            order.Id = 100;

            Assert.AreEqual(order.Id, 100);
        }

        [Test]
        public void OrderSetGetOrderDate()
        {
            var date = new DateTime(2018,1,2,3,4,5);
            order.OrderDate = date;

            Assert.AreEqual(order.OrderDate.Year, 2018);
            Assert.AreEqual(order.OrderDate.Month, 1);
            Assert.AreEqual(order.OrderDate.Day, 2);
            Assert.AreEqual(order.OrderDate.Hour, 3);
            Assert.AreEqual(order.OrderDate.Minute, 4);
            Assert.AreEqual(order.OrderDate.Second, 5);
        }

        [Test]
        public void OrderSetGetSeller()
        {
            var seller = new Seller();
            seller.Id = 100;

            order.SellerId = seller.Id;
            order.OrderSeller = seller;

            Assert.AreEqual(order.SellerId, 100);
            Assert.AreEqual(order.OrderSeller, seller);
        }

        [Test]
        public void OrderSetGetUserId()
        {
            order.UserId = 100;

            Assert.AreEqual(order.UserId, 100);
        }

    }
}