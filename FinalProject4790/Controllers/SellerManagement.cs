using FinalProject4790.Models.DomainServices;
using FinalProject4790.Views.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject4790.Controllers
{
    [Authorize(Roles="Admins")]
    public class SellerManagement : Controller
    {

        private ISellerRepository _sellerRepository;
        public SellerManagement(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }
        /// <summary>
        /// SellerManagment Screen
        /// </summary>
        /// <returns>SellerManagment View</returns>
        public IActionResult Index()
        {
            var sellers = _sellerRepository.GetAllSellers();

            return View(sellers);
        }

        /// <summary>
        /// Add seller screen
        /// </summary>
        /// <returns>AddSeller View</returns>
        public IActionResult AddSeller()
        {
            return View();
        }

        /// <summary>
        /// Add Seller to DB
        /// </summary>
        /// <param name="addUserViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddSeller(SellerEditViewModel sellerEditViewModel)
        {
            if (!ModelState.IsValid) 
                return View(sellerEditViewModel);

            _sellerRepository.AddSeller(sellerEditViewModel.Seller);
        
            return RedirectToAction("Index", _sellerRepository.GetAllSellers());
        }

        /// <summary>
        /// Disable Seller to DB
        /// </summary>
        /// <param name="addUserViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DisableSeller(int id)
        {
            _sellerRepository.DisableSeller(id);
        
            return RedirectToAction("Index", _sellerRepository.GetAllSellers());
        }

        /// <summary>
        /// Enable Seller to DB
        /// </summary>
        /// <param name="addUserViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult EnableSeller(int id)
        {
            _sellerRepository.EnableSeller(id);
        
            return RedirectToAction("Index", _sellerRepository.GetAllSellers());
        }
        
        /// <summary>
        /// Edit Seller Form
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Edit Seller View</returns>
        public IActionResult EditSeller(int id)
        {
            var seller = _sellerRepository.GetSellerById(id);

            var sellerEditViewModel = new SellerEditViewModel
            {
                Seller = seller
            };

            return View(sellerEditViewModel);
        }

        [HttpPost]
        //public IActionResult EditPie([Bind("Pie")] PieEditViewModel pieEditViewModel)
        public IActionResult EditSeller(SellerEditViewModel sellerEditViewModel)
        {

            if (ModelState.IsValid)
            {
                _sellerRepository.UpdateSeller(sellerEditViewModel.Seller);
                return RedirectToAction("Index");
            }
            return View(sellerEditViewModel);
        }

    }
}