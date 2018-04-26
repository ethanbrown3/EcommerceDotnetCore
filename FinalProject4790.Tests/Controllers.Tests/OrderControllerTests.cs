using System;
using NUnit.Framework;
using FinalProject4790.Controllers;
using FinalProject4790.Models.DomainServices;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using FinalProject4790.Models;
using Microsoft.EntityFrameworkCore;
using FinalProject4790.Models.Domain;

namespace FinalProject4790.Tests.Controllers.Tests
{
    public class OrderControllerTests
    {

        private IOrderRepository orderRepository;
        private ICreditTransactionRepository creditTransactionRepository;
        private ShoppingCart shoppingCart;
        private MockUserManager userManager;
        private OrderController controller;
        AppDbContext appDbContext;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "testDb")
                .Options;
            appDbContext = new AppDbContext(options);
            
            appDbContext.Database.EnsureCreated();
            
            DbInitializer.Seed(appDbContext);

            userManager = new  MockUserManager();
            orderRepository = new MockOrderRepository();
            shoppingCart = new ShoppingCart(appDbContext);
            creditTransactionRepository = new MockCreditTransactionRepository();

            controller = new OrderController(orderRepository, shoppingCart, userManager, creditTransactionRepository);

        }
        
        [Test]
        public void OrderController_CheckoutReturnsRedirectWhenCartIsEmpty()
        {
            var result = controller.Checkout() as RedirectToActionResult;
            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }

        [Test]
        public void OrderController_CheckoutReturnsViewWhenCartIsNotEmpty()
        {
            var product = new Product();
            shoppingCart.AddToCart(product, 1);
            var result = controller.Checkout() as ViewResult;
            var model = result.Model;

            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsNotNull(model);
        }
    }
}