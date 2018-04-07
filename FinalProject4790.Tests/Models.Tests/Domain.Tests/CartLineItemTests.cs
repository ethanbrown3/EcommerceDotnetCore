using System;
using NUnit.Framework;
using FinalProject4790.Controllers;
using FinalProject4790.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace FinalProject4790.Tests.Models.Domain.Tests
{
    public class LineItemTests
    {
        private CartLineItem lineItem;
        [SetUp]
        public void Setup()
        {
            // Arrange
            lineItem = new CartLineItem();
        }

        [Test]
        public void LineItemSetGetId()
        {
            lineItem.CartLineItemId = 100;

            Assert.AreEqual(lineItem.CartLineItemId, 100);
        }

        [Test]
        public void LineItemSetGetProductId()
        {
            var product = new Product();
            product.ProductId = 100;

            lineItem.CartLineItemProduct = product;
            lineItem.CartLineItemProductId = product.ProductId;

            Assert.AreEqual(lineItem.CartLineItemProductId, 100);
            Assert.AreEqual(lineItem.CartLineItemProduct, product);
        }

    }
}