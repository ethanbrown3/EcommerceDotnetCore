using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject4790.Views.Components
{
    public class AdminMenu : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var menuItems = new List<AdminMenuItem> { 
                new AdminMenuItem()
                {
                    DisplayValue = "User management",
                    ActionValue = "UserManagement"

                },
                new AdminMenuItem()
                {
                    DisplayValue = "Role management",
                    ActionValue = "RoleManagement"
                },
                new AdminMenuItem()
                {
                    DisplayValue = "Sellers management",
                    ActionValue = "SellerManagement"
                }
            };

            return View(menuItems);
        }
    }

    public class AdminMenuItem
    {
        public string DisplayValue { get; set; }
        public string ActionValue { get; set; }
    }
}