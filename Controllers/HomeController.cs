using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using final_project_ethanbrown3.Models;
using final_project_ethanbrown3.ViewModels;

namespace final_project_ethanbrown3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISellerRepository _sellerRepository;

        public HomeController(ISellerRepository sellerRepository)  // Constructor Injection
        {
            _sellerRepository = sellerRepository; 
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var sellers = _sellerRepository.GetAllSellers().OrderBy(s => s.SellerName);

            var homeViewModel = new HomeViewModel()
            {
                Title = "Welcome to Bethany's Pie Shop",
                Sellers = sellers.ToList()
            };
            
            return View(homeViewModel);
        }
    }
}