using System;
using NUnit.Framework;
using FinalProject4790.Controllers;
using FinalProject4790.Models.DomainServices;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using FinalProject4790.Models;
using Microsoft.EntityFrameworkCore;
using FinalProject4790.Views.ViewModels;
using System.Threading.Tasks;

namespace FinalProject4790.Tests.Controllers.Tests
{
    public class AccountControllerTests
    {
        AppDbContext appDbContext;
        private MockSignInManager signInManager;
        private MockUserManager userManager;
        private AccountController controller;
        private LoginViewModel loginViewModel;
        
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "testDb")
                .Options;
            appDbContext = new AppDbContext(options);
            appDbContext.Database.EnsureCreated();

            userManager = new  MockUserManager();
            signInManager = new MockSignInManager();

            controller = new AccountController(signInManager, userManager);
            loginViewModel = new LoginViewModel()
            {
                UserName = "username",
                Email = "test@email.com"
            };
        }

        [Test]
        public void AccountController_LoginReturnsIActionResult()
        {
            // Act
            var result = controller.Login() as ViewResult;
            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void AccountController_LoginViewModelLoginRedirects()
        {
            // Act
            var result = controller.Login(loginViewModel);
            // Assert
            Assert.IsInstanceOf<Task<IActionResult>>(result);
        }
    }
}