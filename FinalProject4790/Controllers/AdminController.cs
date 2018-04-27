using System.Collections.Generic;
using System.Threading.Tasks;
using FinalProject4790.Auth;
using FinalProject4790.Models.Domain;
using FinalProject4790.Models.DomainServices;
using FinalProject4790.Views.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject4790.Controllers
{
    [Authorize(Roles="Admins")]
    public class AdminController : Controller
    {
        private UserManager<AppUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private ISellerRepository _sellerRepository;
        public AdminController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, ISellerRepository sellerRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _sellerRepository = sellerRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// UserManagment Screen
        /// </summary>
        /// <returns>UserManagment View</returns>
        public IActionResult UserManagement()
        {
            var users = _userManager.Users;

            return View(users);
        }

        /// <summary>
        /// Add user screen
        /// </summary>
        /// <returns>AddUser View</returns>
        public IActionResult AddUser()
        {
            return View();
        }

        /// <summary>
        /// Add User to Identity
        /// </summary>
        /// <param name="addUserViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserViewModel addUserViewModel)
        {
            if (!ModelState.IsValid) return View(addUserViewModel);

            var user = new AppUser()
            {
                UserName = addUserViewModel.UserName,
                Email = addUserViewModel.Email,
                SellerId = addUserViewModel.SellerId
            };

            IdentityResult result = await _userManager.CreateAsync(user, addUserViewModel.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("UserManagement", _userManager.Users);
            }

            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(addUserViewModel);
        }

        /// <summary>
        /// Edit User Form
        /// </summary>
        /// <param name="id"></param>
        /// <returns>EditUser View</returns>
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return RedirectToAction("UserManagement", _userManager.Users);

            return View(user);
        }

        /// <summary>
        /// Update User by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="UserName"></param>
        /// <param name="Email"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EditUser(string id, string UserName, string Email)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                user.Email = Email;
                user.UserName = UserName;

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                    return RedirectToAction("UserManagement", _userManager.Users);

                ModelState.AddModelError("", "User not updated, something went wrong.");

                return View(user);
            }

            return RedirectToAction("UserManagement", _userManager.Users);
        }

        /// <summary>
        /// Delete user by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>UserManagement View</returns>
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            AppUser user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("UserManagement");
                else
                    ModelState.AddModelError("", "Something went wrong while deleting this user.");
            }
            else
            {
                ModelState.AddModelError("", "This user can't be found");
            }
            return View("UserManagement", _userManager.Users);
        }

        /// <summary>
        /// RoleManagement Screen
        /// </summary>
        /// <returns></returns>
        public IActionResult RoleManagement()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        public IActionResult AddNewRole() => View();

        /// <summary>
        /// Add new role to identity
        /// </summary>
        /// <param name="addRoleViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddNewRole(AddRoleViewModel addRoleViewModel)
        {
            if (!ModelState.IsValid) 
                return View(addRoleViewModel);

            var role = new IdentityRole
            {
                Name = addRoleViewModel.RoleName
            };

            IdentityResult result = await _roleManager.CreateAsync(role);

            if (!result.Succeeded)
            {
                foreach(IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(addRoleViewModel);   
            }
            return RedirectToAction("RoleManagement", _roleManager.Roles);
        }

        /// <summary>
        /// Edit role screen 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
                return RedirectToAction("RoleManagement", _roleManager.Roles);

            var editRoleViewModel = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name,
                Users = new List<string>()
            };


            foreach (var user in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                    editRoleViewModel.Users.Add(user.UserName);
            }

            return View(editRoleViewModel);
        }

        /// <summary>
        /// Edit role in identity
        /// </summary>
        /// <param name="editRoleViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel editRoleViewModel)
        {
            var role = await _roleManager.FindByIdAsync(editRoleViewModel.Id);

            if (role == null)
            {
                return RedirectToAction("RoleManagement", _roleManager.Roles);
            }

            role.Name = editRoleViewModel.RoleName;

            var result = await _roleManager.UpdateAsync(role);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Role not updated, something went wrong.");
                return View(editRoleViewModel);
            }

            return RedirectToAction("RoleManagement", _roleManager.Roles);

        }

        /// <summary>
        /// Delete role
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                ModelState.AddModelError("", "This role can't be found.");
                return View("RoleManagement", _roleManager.Roles);
            }
            else
            {
                var result = await _roleManager.DeleteAsync(role);
                if (!result.Succeeded)
                    ModelState.AddModelError("", "Something went wrong while deleting this role.");
            }
            return View("RoleManagement", _roleManager.Roles);
        }

        /// <summary>
        /// Add a user to a role by role Id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public async Task<IActionResult> AddUserToRole(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role == null)
                return RedirectToAction("RoleManagement", _roleManager.Roles);

            var addUserToRoleViewModel = new UserRoleViewModel { RoleId = role.Id };

            foreach (var user in _userManager.Users)
            {
                if (!await _userManager.IsInRoleAsync(user, role.Name))
                {
                    addUserToRoleViewModel.Users.Add(user);
                }
            }

            return View(addUserToRoleViewModel);
        }

        /// <summary>
        /// Add user to role in identity given a UserRoleViewModel
        /// </summary>
        /// <param name="userRoleViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddUserToRole(UserRoleViewModel userRoleViewModel)
        {
            var user = await _userManager.FindByIdAsync(userRoleViewModel.UserId);
            var role = await _roleManager.FindByIdAsync(userRoleViewModel.RoleId);

            var result = await _userManager.AddToRoleAsync(user, role.Name);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(userRoleViewModel);
            }

            return RedirectToAction("RoleManagement", _roleManager.Roles);
        }

        /// <summary>
        /// Delete user from role view
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public async Task<IActionResult> DeleteUserFromRole(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role == null)
                return RedirectToAction("RoleManagement", _roleManager.Roles);

            var addUserToRoleViewModel = new UserRoleViewModel { RoleId = role.Id };

            foreach (var user in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    addUserToRoleViewModel.Users.Add(user);
                }
            }

            return View(addUserToRoleViewModel);
        }

        /// <summary>
        /// Delete user from role using UserRoleViewModel
        /// </summary>
        /// <param name="userRoleViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteUserFromRole(UserRoleViewModel userRoleViewModel)
        {
            var user = await _userManager.FindByIdAsync(userRoleViewModel.UserId);
            var role = await _roleManager.FindByIdAsync(userRoleViewModel.RoleId);

            var result = await _userManager.RemoveFromRoleAsync(user, role.Name);

            if (result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(userRoleViewModel);
            }
            return RedirectToAction("RoleManagement", _roleManager.Roles);
        }
    }
}