using System;
using NUnit.Framework;
using FinalProject4790.Controllers;
using FinalProject4790.Models.DomainServices;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using FinalProject4790.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject4790.Tests.Controllers.Tests
{
    public class ShoppingCartControllerTests
    {

        AppDbContext appDbContext;
        ShoppingCart _shoppingCart;
        ShoppingCartController controller;
        IProductRepository _mockProductRepository;

        [SetUp]
        public void Setup()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "testDb")
                .Options;
            appDbContext = new AppDbContext(options);

            DbInitializer.Seed(appDbContext);

            _shoppingCart = new ShoppingCart(appDbContext);

            _mockProductRepository = new MockProductRepository();

            controller = new ShoppingCartController(_mockProductRepository, _shoppingCart);

        }

        [Test]
        public void ShoppingCartController_IndexReturnsViewResult()
        {
            // Act
            var result = controller.Index() as ViewResult;
            var model = result.Model;
            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsNotNull(model);
        }

        [Test]
        public void ShoppingCartController_AddToShoppingCartReturnsRedirectToActionResult()
        {
            var productToAdd = _mockProductRepository.GetProductById(0);
            // Act
            var result = controller.AddToShoppingCart(0) as RedirectToActionResult;

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }

        [Test]
        public void ShoppingCartController_RemoveFromShoppingCartReturnsRedirectToActionResult()
        {
            var productToAdd = _mockProductRepository.GetProductById(0);
            // Act
            var result = controller.RemoveFromShoppingCart(0) as RedirectToActionResult;

            // Assert
            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }

    }
}