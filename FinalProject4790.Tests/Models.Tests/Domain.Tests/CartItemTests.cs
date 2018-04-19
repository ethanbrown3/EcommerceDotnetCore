using System;
using NUnit.Framework;
using FinalProject4790.Controllers;
using FinalProject4790.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace FinalProject4790.Tests.Models.Domain.Tests
{
    public class CartItemTests
    {
        private CartItem lineItem;
        [SetUp]
        public void Setup()
        {
            // Arrange
            lineItem = new CartItem();
        }

        [Test]
        public void LineItemSetGetId()
        {
            lineItem.CartItemId = 100;

            Assert.AreEqual(lineItem.CartItemId, 100);
        }

        [Test]
        public void LineItemSetGetProductId()
        {
            var product = new Product();
            product.ProductId = 100;

            lineItem.CartItemProduct = product;
            lineItem.CartItemProductId = product.ProductId;

            Assert.AreEqual(lineItem.CartItemProductId, 100);
            Assert.AreEqual(lineItem.CartItemProduct, product);
        }

        [Test]
        public void CartItem_SetGetQuantity()
        {
            lineItem.CartItemQuantity = 100;

            Assert.AreEqual(lineItem.CartItemQuantity, 100);
        }

        [Test]
        public void CartItem_SetGetShoppingCartId()
        {
            lineItem.CartShoppingCartId = "cartIDTest";

            Assert.AreEqual(lineItem.CartShoppingCartId, "cartIDTest");
        }

    }
}