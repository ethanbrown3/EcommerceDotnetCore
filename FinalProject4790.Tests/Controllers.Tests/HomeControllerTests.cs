using System;
using NUnit.Framework;
using FinalProject4790.Controllers;
using FinalProject4790.Models.DomainServices;
using Microsoft.AspNetCore.Mvc;

namespace Tests
{
    public class HomeControllerTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void HomeControllerIndexReturnsViewResult()
        {
            // Arrange
            var mockSellers = new MockSellerRepository();
            var mockProducts = new MockProductRepository();
            var controller = new HomeController(mockSellers, mockProducts);
            // Act
            var result = controller.Index();
            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }
    }
}