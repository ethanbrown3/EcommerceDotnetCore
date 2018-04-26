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
        public void Order_SetGetOrderId()
        {
            order.OrderId = 100;

            Assert.AreEqual(order.OrderId, 100);
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
        public void Order_SetGetUserId()
        {
            var testId = "test100";
            order.UserId = testId;
            var result = order.UserId;
            Assert.AreEqual(result, testId);
        }

        [Test]
        public void Order_SetGetLineItems()
        {
            var lineItemsTest = new List<OrderLineItem>();
            lineItemsTest.Add(
                new OrderLineItem
                {
                    OrderLineItemId = 100
                }
            );

            order.OrderLineItems = lineItemsTest;
            var result = order.OrderLineItems[0].OrderLineItemId;
            Assert.AreEqual(result, 100);
        }

        [Test]
        public void Order_SetGetTotal()
        {
            var testTotal = 100;
            order.OrderTotalInCents = testTotal;
            var result = order.OrderTotalInCents;
            Assert.AreEqual(testTotal, result);
        }

        [Test]
        public void Order_GetSetCreditId()
        {
            var testId = 100;
            order.CreditTransactionId = testId;
            var result = order.CreditTransactionId;
            Assert.AreEqual(testId, result);
        }

        [Test]
        public void Order_GetSetFirstName()
        {
            var test = "Ethan";
            order.OrderFirstName = test;
            var result = order.OrderFirstName;
            Assert.AreEqual(test, result);
        }

        [Test]
        public void Order_GetSetLastName()
        {
            var test = "Brown";
            order.OrderLastName = test;
            var result = order.OrderLastName;
            Assert.AreEqual(test, result);
        }

        [Test]
        public void Order_GetSetAddress1()
        {
            var test = "123 Fake Street";
            order.OrderStreetAddress1 = test;
            var result = order.OrderStreetAddress1;
            Assert.AreEqual(test, result);
        }

        [Test]
        public void Order_GetSetAddress2()
        {
            var test = "Suite 1";
            order.OrderStreetAddress2 = test;
            var result = order.OrderStreetAddress2;
            Assert.AreEqual(test, result);
        }

        [Test]
        public void Order_GetSetCity()
        {
            var test = "Gotham";
            order.OrderCity = test;
            var result = order.OrderCity;
            Assert.AreEqual(test, result);
        }

        [Test]
        public void Order_GetSetState()
        {
            var test = "UT";
            order.OrderState = test;
            var result = order.OrderState;
            Assert.AreEqual(test, result);
        }

        [Test]
        public void Order_GetSetZip()
        {
            var test = "88888";
            order.OrderZip = test;
            var result = order.OrderZip;
            Assert.AreEqual(test, result);
        }

        [Test]
        public void Order_GetSetPhone()
        {
            var test = "8011234567";
            order.OrderPhoneNumber = test;
            var result = order.OrderPhoneNumber;
            Assert.AreEqual(test, result);
        }
    }
}