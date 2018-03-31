using System;
using NUnit.Framework;
using FinalProject4790.Controllers;
using FinalProject4790.Models.DomainServices;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FinalProject4790.Tests.Controllers.Tests
{
    public class HomeControllerTests
    {

        private MockSellerRepository mockSellers;
        private HomeController controller;

        [SetUp]
        public void Setup()
        {
            // Arrange
            mockSellers = new MockSellerRepository();
            controller = new HomeController(mockSellers);
        }

        [Test]
        public void HomeControllerIndexReturnsViewResult()
        {
            // Act
            var result = controller.Index() as ViewResult;
            var model = result.Model;
            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsNotNull(model);
        }
    }
}