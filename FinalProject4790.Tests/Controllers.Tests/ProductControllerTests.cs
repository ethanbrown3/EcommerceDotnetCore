using System;
using NUnit.Framework;
using FinalProject4790.Controllers;
using FinalProject4790.Models.DomainServices;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FinalProject4790.Tests.Controllers.Tests
{
    public class ProductControllerTests
    {

        private MockProductRepository mockProducts;
        private ProductController controller;

        [SetUp]
        public void Setup()
        {
            // Arrange
            mockProducts = new MockProductRepository();
            controller = new ProductController(mockProducts);
        }

        [Test]
        public void ProductControllerProductListReturnsViewResult()
        {
            var result = controller.ProductList(0, "SellerNameTest") as ViewResult;
            var model = result.Model;
            
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsNotNull(model);
        }

        [Test]
        public void ProductControllerProductDetailReturnsViewResult()
        {
            var result = controller.ProductDetail(0) as ViewResult;
            var model = result.Model;
            
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsNotNull(model);
        }
    }
}