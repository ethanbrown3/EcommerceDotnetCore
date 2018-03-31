using System;
using NUnit.Framework;
using FinalProject4790.Controllers;
using FinalProject4790.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace FinalProject4790.Tests.Models.Domain.Tests
{
    public class SellerTests
    { 
        [SetUp]
        public void Setup()
        {
            // Arrange
            
        }

        [Test]
        public void SellerSetGetId()
        {
            var seller = new Seller();
            seller.Id = 100;

            Assert.AreEqual(seller.Id, 100);
        }

        [Test]
        public void SellerSetGetSellerName()
        {
            var seller = new Seller();
            seller.SellerName = "TestName";

            Assert.AreEqual(seller.SellerName, "TestName");
        }

        [Test]
        public void SellerSetGetSellerDecription()
        {
            var seller = new Seller();
            seller.SellerDescription = "TestName";

            Assert.AreEqual(seller.SellerDescription, "TestName");
        }

        [Test]
        public void SellerSetGetProducts()
        {
            var seller = new Seller();
            var product = new Product();
            var products = new List<Product>();
            
            products.Add(product);

            seller.Products = products;
            Assert.AreEqual(1, seller.Products.Count);
        }
    }
}