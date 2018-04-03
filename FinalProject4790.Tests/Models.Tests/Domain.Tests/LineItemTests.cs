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
        private LineItem lineItem;
        [SetUp]
        public void Setup()
        {
            // Arrange
            lineItem = new LineItem();
        }

        [Test]
        public void LineItemSetGetId()
        {
            lineItem.LineItemId = 100;

            Assert.AreEqual(lineItem.LineItemId, 100);
        }

        [Test]
        public void LineItemSetGetProductId()
        {
            var product = new Product();
            product.ProductId = 100;

            lineItem.LineItemProduct = product;
            lineItem.LineItemProductId = product.ProductId;

            Assert.AreEqual(lineItem.LineItemProductId, 100);
            Assert.AreEqual(lineItem.LineItemProduct, product);
        }

    }
}