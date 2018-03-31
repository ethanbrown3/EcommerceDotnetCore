using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalProject4790.Models;
using FinalProject4790.ViewModels;
using FinalProject4790.Models.DomainServices;

namespace FinalProject4790.Controllers
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
                Title = "Welcome",
                Sellers = sellers.ToList()
            };
            
            return View(homeViewModel);
        }

    }
}