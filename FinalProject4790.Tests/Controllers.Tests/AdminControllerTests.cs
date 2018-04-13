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
    public class AdminControllerTests
    {
        AppDbContext appDbContext;
        private MockRoleManager roleManager;
        private MockUserManager userManager;
        private AdminController controller;
        private LoginViewModel validLoginViewModel;
        private LoginViewModel invalidLoginViewModel;
        
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "testDb")
                .Options;
            appDbContext = new AppDbContext(options);
            appDbContext.Database.EnsureCreated();

            userManager = new  MockUserManager();
            roleManager = new MockRoleManager();

            controller = new AdminController(userManager, roleManager);
            validLoginViewModel = new LoginViewModel()
            {
                UserName = "username",
                Email = "test@email.com"
            };
            invalidLoginViewModel = null;
        }

        [Test]
        public void AdminController_IndexReturnsIActionResult()
        {
            // Act
            var result = controller.Index() as IActionResult;
            // Assert
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void AdminController_UserManagementReturnsIActionResul()
        {
            // Act
            var result = controller.UserManagement() as IActionResult;
            // Assert
            Assert.IsInstanceOf<IActionResult>(result);
        }

        [Test]
        public void AdminController_AddUserReturnsIActionResul()
        {
            // Act
            var result = controller.AddUser() as IActionResult;
            // Assert
            Assert.IsInstanceOf<IActionResult>(result);
        }

    }
}