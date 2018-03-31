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
            lineItem.Id = 100;

            Assert.AreEqual(lineItem.Id, 100);
        }

        [Test]
        public void LineItemSetGetProductId()
        {
            var product = new Product();
            product.Id = 100;

            lineItem.LineItemProduct = product;
            lineItem.ProductId = product.Id;

            Assert.AreEqual(lineItem.ProductId, 100);
            Assert.AreEqual(lineItem.LineItemProduct, product);
        }

    }
}