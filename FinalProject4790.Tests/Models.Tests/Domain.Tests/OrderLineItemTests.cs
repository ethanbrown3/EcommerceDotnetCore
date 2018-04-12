using System;
using NUnit.Framework;
using FinalProject4790.Controllers;
using FinalProject4790.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace FinalProject4790.Tests.Models.Domain.Tests
{
    public class OrderLineItemTests
    {
        private OrderLineItem orderLineItem;
        [SetUp]
        public void Setup()
        {
            // Arrange
            orderLineItem = new OrderLineItem();
        }

        [Test]
        public void OrderLineItem_SetGetId()
        {
            orderLineItem.OrderLineItemId = 100;

            Assert.AreEqual(orderLineItem.OrderLineItemId, 100);
        }

        [Test]
        public void OrderLineItem_SetGetProductId()
        {
            var product = new Product();
            product.ProductId = 100;

            orderLineItem.OrderProduct = product;
            orderLineItem.ProductId = product.ProductId;

            Assert.AreEqual(orderLineItem.ProductId, 100);
            Assert.AreEqual(orderLineItem.OrderProduct, product);
        }

        [Test]
        public void OrderLineItem_SetGetOrderLineItemPrice()
        {
            orderLineItem.OrderLineItemPrice = 100;

            Assert.AreEqual(orderLineItem.OrderLineItemPrice, 100);
        }

        [Test]
        public void OrderLineItem_SetGetOrderLineItemQuantity()
        {
            orderLineItem.OrderLineItemQuantity = 100;

            Assert.AreEqual(orderLineItem.OrderLineItemQuantity, 100);
        }

        [Test]
        public void OrderLineItem_SetGetOrderLineItemOrder()
        {
            var order = new Order()
            {
                OrderId = 10
            };
            orderLineItem.Order = order;
            orderLineItem.OrderId = order.OrderId;
            Assert.AreEqual(orderLineItem.OrderId, 10);
            Assert.AreEqual(orderLineItem.Order, order);
        }

    }
}