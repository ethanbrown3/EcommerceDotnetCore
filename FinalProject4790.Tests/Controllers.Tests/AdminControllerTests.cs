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
        private ISellerRepository sellerRepository;
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
            sellerRepository = new MockSellerRepository();
            
            controller = new AdminController(userManager, roleManager, sellerRepository);
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
            var result = controller.Index() as ViewResult;
            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void AdminController_UserManagementReturnsIActionResult()
        {
            // Act
            var result = controller.UserManagement() as ViewResult;
            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void AdminController_AddUserReturnsIActionResult()
        {
            // Act
            var result = controller.AddUser() as ViewResult;
            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }


    }
}