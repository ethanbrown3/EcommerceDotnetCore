using System;
using NUnit.Framework;
using FinalProject4790.Controllers;
using FinalProject4790.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace FinalProject4790.Tests.Models.Domain.Tests
{
    public class ProductTests
    {
        [SetUp]
        public void Setup()
        {
            // Arrange
            
        }

        [Test]
        public void ProductSetGetId()
        {
            var product = new Product();
            product.Id = 0;

            Assert.AreEqual(product.Id, 0);
        }

        [Test]
        public void ProductSetGetProductName()
        {
            var product = new Product();
            product.ProductName = "TestName";

            Assert.AreEqual(product.ProductName, "TestName");
        }

        [Test]
        public void ProductSetGetProductDecription()
        {
            var product = new Product();
            product.ProductDescription = "TestName";

            Assert.AreEqual(product.ProductDescription, "TestName");
        }

        [Test]
        public void ProductSetGetProductPrice()
        {
            var product = new Product();
            product.ProductPrice = 1.99M;

            Assert.AreEqual(product.ProductPrice, 1.99M);
        }

        [Test]
        public void ProductSetGetProductImgUrl()
        {
            var product = new Product();
            product.ProductImgUrl = "http://placehold.it/120x120&text=image1";

            Assert.AreEqual(product.ProductImgUrl, "http://placehold.it/120x120&text=image1");
        }

        [Test]
        public void ProductSetGetIsEdible()
        {
            var product = new Product();
            product.IsEdible = true;

            Assert.True(product.IsEdible);
        }

        [Test]
        public void ProductSetGetProductCount()
        {
            var product = new Product();
            product.ProductCount = 1;

            Assert.AreEqual(product.ProductCount, 1);
        }

        [Test]
        public void ProductSetGetSellerId()
        {
            var product = new Product();
            product.SellerId = 1;

            Assert.AreEqual(product.SellerId, 1);
        }

        [Test]
        public void ProductSetGetSeller()
        {
            var product = new Product();
            var seller = new Seller();
            product.Seller = seller;

            Assert.AreEqual(product.Seller, seller);
        }

    }
}