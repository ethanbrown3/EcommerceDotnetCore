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
        public void Product_SetGetId()
        {
            var product = new Product();
            product.ProductId = 100;

            Assert.AreEqual(product.ProductId, 100);
        }

        [Test]
        public void Product_SetGetProductName()
        {
            var product = new Product();
            product.ProductName = "TestName";

            Assert.AreEqual(product.ProductName, "TestName");
        }

        [Test]
        public void Product_SetGetProductShortDecription()
        {
            var product = new Product();
            product.ProductShortDescription = "TestName";

            Assert.AreEqual(product.ProductShortDescription, "TestName");
        }

        [Test]
        public void Product_SetGetProductLongDecription()
        {
            var product = new Product();
            product.ProductLongDescription = "TestName";

            Assert.AreEqual(product.ProductLongDescription, "TestName");
        }

        [Test]
        public void Product_SetGetProductPrice()
        {
            var product = new Product();
            product.ProductPrice = 1.99M;

            Assert.AreEqual(product.ProductPrice, 1.99M);
        }

        [Test]
        public void Product_SetGetProductImgUrl()
        {
            var product = new Product();
            product.ProductImgUrl = "http://placehold.it/120x120&text=image1";

            Assert.AreEqual(product.ProductImgUrl, "http://placehold.it/120x120&text=image1");
        }

        [Test]
        public void Product_SetGetIsEdible()
        {
            var product = new Product();
            product.IsEdible = true;

            Assert.True(product.IsEdible);
        }

        [Test]
        public void Product_SetGetProductCount()
        {
            var product = new Product();
            product.ProductCount = 1;

            Assert.AreEqual(product.ProductCount, 1);
        }

        [Test]
        public void Product_SetGetSellerId()
        {
            var product = new Product();
            product.SellerId = 1;

            Assert.AreEqual(product.SellerId, 1);
        }

        [Test]
        public void Product_SetGetSeller()
        {
            var product = new Product();
            var seller = new Seller();
            product.Seller = seller;

            Assert.AreEqual(product.Seller, seller);
        }

    }
}