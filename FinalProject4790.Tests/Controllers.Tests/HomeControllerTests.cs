using System;
using NUnit.Framework;
using FinalProject4790.Controllers;
using FinalProject4790.Models.DomainServices;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Tests
{
    public class HomeControllerTests
    {

        private MockProductRepository mockProducts;
        private MockSellerRepository mockSellers;
        private HomeController controller;

        [SetUp]
        public void Setup()
        {
            // Arrange
            mockSellers = new MockSellerRepository();
            mockProducts = new MockProductRepository();
            controller = new HomeController(mockSellers, mockProducts);
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

        [Test]
        public void HomeControllerProductListReturnsViewResult()
        {
            var result = controller.ProductList(0, "SellerNameTest") as ViewResult;
            var model = result.Model;
            
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsNotNull(model);
        }

        [Test]
        public void HomeControllerProductDetailReturnsViewResult()
        {
            var result = controller.ProductDetail(0) as ViewResult;
            var model = result.Model;
            
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsNotNull(model);
        }
    }
}