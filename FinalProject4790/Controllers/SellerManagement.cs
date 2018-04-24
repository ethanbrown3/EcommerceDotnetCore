using FinalProject4790.Models.DomainServices;
using FinalProject4790.Views.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject4790.Controllers
{
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
            var sellers = _sellerRepository.GetAllEnabledSellers();

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
        
            return RedirectToAction("SellerManagement", _sellerRepository.GetAllSellers());
        }
                // /// <summary>
        // /// Edit User Form
        // /// </summary>
        // /// <param name="id"></param>
        // /// <returns>EditUser View</returns>
        // public async Task<IActionResult> EditUser(string id)
        // {
        //     var user = await _userManager.FindByIdAsync(id);

        //     if (user == null)
        //         return RedirectToAction("UserManagement", _userManager.Users);

        //     return View(user);
        // }

        // /// <summary>
        // /// Update User by id
        // /// </summary>
        // /// <param name="id"></param>
        // /// <param name="UserName"></param>
        // /// <param name="Email"></param>
        // /// <returns></returns>
        // [HttpPost]
        // public async Task<IActionResult> EditUser(string id, string UserName, string Email)
        // {
        //     var user = await _userManager.FindByIdAsync(id);

        //     if (user != null)
        //     {
        //         user.Email = Email;
        //         user.UserName = UserName;

        //         var result = await _userManager.UpdateAsync(user);

        //         if (result.Succeeded)
        //             return RedirectToAction("UserManagement", _userManager.Users);

        //         ModelState.AddModelError("", "User not updated, something went wrong.");

        //         return View(user);
        //     }

        //     return RedirectToAction("UserManagement", _userManager.Users);
        // }

        // /// <summary>
        // /// Delete user by user id
        // /// </summary>
        // /// <param name="userId"></param>
        // /// <returns>UserManagement View</returns>
        // [HttpPost]
        // public async Task<IActionResult> DeleteUser(string userId)
        // {
        //     IdentityUser user = await _userManager.FindByIdAsync(userId);

        //     if (user != null)
        //     {
        //         IdentityResult result = await _userManager.DeleteAsync(user);
        //         if (result.Succeeded)
        //             return RedirectToAction("UserManagement");
        //         else
        //             ModelState.AddModelError("", "Something went wrong while deleting this user.");
        //     }
        //     else
        //     {
        //         ModelState.AddModelError("", "This user can't be found");
        //     }
        //     return View("UserManagement", _userManager.Users);
        // }

    }
}