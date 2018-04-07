using System;
using NUnit.Framework;
using FinalProject4790.Controllers;
using FinalProject4790.Models.DomainServices;
using FinalProject4790.Models.Domain;

using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FinalProject4790.Models;

namespace FinalProject4790.Tests.Models.Tests
{
    public class ShoppingCartTests
    {
        AppDbContext appDbContext;
        ShoppingCart _shoppingCart;

        [SetUp]
        public void Setup()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "testDb")
                .Options;
            appDbContext = new AppDbContext(options);

            appDbContext.Database.EnsureCreated();
            
            DbInitializer.Seed(appDbContext);

            _shoppingCart = new ShoppingCart(appDbContext);
        }

        [Test]
        public void ShoppingCartController_SetGetLineItems()
        {
            // Act
            var Products = appDbContext.Products.ToList();
            var amount = 1;
            _shoppingCart.AddToCart(Products[0], amount);

            // Assert
            Assert.AreEqual(amount, _shoppingCart.GetShoppingCartLineItems().Count);
        }

        [Test]
        public void ShoppingCartController_AddItem()
        {
            // Act
            var Products = appDbContext.Products.ToList();
            var productToAdd = Products[0];

            var amount = 1;
            _shoppingCart.AddToCart(productToAdd, amount);

            var productAdded = _shoppingCart.GetShoppingCartLineItems()[0];
            _shoppingCart.ClearCart();
            // Assert
            Assert.AreEqual(productToAdd.ProductId, productAdded.CartLineItemProductId);
        }

        [Test]
        public void ShoppingCartController_RemoveItem()
        {
            // Act
            var Products = appDbContext.Products.ToList();
            var productToRemove = Products[0];

            var amount = 2;
            _shoppingCart.AddToCart(productToRemove, amount);

            // Assert
            Assert.AreEqual(1, _shoppingCart.RemoveFromCart(productToRemove));
        }

        [Test]
        public void ShoppingCartController_ClearCart()
        {
            // Act
            var Products = appDbContext.Products.ToList();
            
            var amount = 3;

            var productToAdd = Products[0];
            _shoppingCart.AddToCart(productToAdd, amount);

            productToAdd = Products[1];
            _shoppingCart.AddToCart(productToAdd, amount);

            _shoppingCart.ClearCart();
            // Assert
            Assert.AreEqual(0, _shoppingCart.GetShoppingCartLineItems().Count);
        }

        [Test]
        public void ShoppingCartController_GetShoppingCartTotal()
        {
            // Act
            var Products = appDbContext.Products.ToList();
            
            var amount = 1;

            var productToAdd = Products[0];
            _shoppingCart.AddToCart(productToAdd, amount);

            // Assert
            Assert.AreEqual(productToAdd.ProductPrice, _shoppingCart.GetShoppingCartTotal());
        }

        [TearDown]
        public void Dispose()
        {
            appDbContext.Database.EnsureDeleted();
            appDbContext.Dispose();
        }
    }
}