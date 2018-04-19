using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject4790.Models.Domain;
using Microsoft.AspNetCore.Identity;

namespace FinalProject4790.Models
{
    public class DbInitializer
    {
        /// <summary>
        /// Seed the AppDbContext with mock data
        /// </summary>
        /// <param name="context"></param>
        public static void Seed(AppDbContext context)
        {
            if (!context.Sellers.Any())
            {
                context.Sellers.AddRange(Sellers.Select(s => s.Value));
            }
            
            if (!context.Products.Any())
            {
                context.AddRange
                (
                    new Product {
                        Seller = Sellers["Paintball Planet"],
                        ProductName = "Paintballs",
                        ProductShortDescription = "Green and Yellow Shell / Yellow Fill.",
                        ProductLongDescription = "Marballizer Paintballs. These are the best paintballs money can buy! All paintballs are fresh and arrive on a weekly basis. All cases of paint are opened before shipment to ensure that there are no broken paintballs. Once the package has been inspected then it will be re-taped and initialed to verify that it has been checked. All cases of paint are then wrapped in a bubble wrap and placed in a box surrounded by packing paper. Sorry but there are no returns on paintballs that are shipped out. We take every precaution to get you your paint in the best condition and in the shortest time.",
                        ProductPrice = 45.99M,
                        ProductImgUrl="https://cdn3.bigcommerce.com/s-9bkfd/products/400/images/834/Empire_Marballizer_Paintballs_1__97088.1398981336.500.659.jpg?c=2",
                        ProductCount=10,
                        IsEdible=false
                    },
                    new Product {
                        Seller = Sellers["Wayne Enterprises"],
                        ProductName = "Tumbler",
                        ProductShortDescription = "Off road vehicle. Comes in black.",
                        ProductLongDescription = "The Tumbler has a pair of machine guns mounted in the nose of the car between the front wheels. In \"Attack\" mode, the driver's seat moves to the center of the car, and the driver is repositioned to lie face-down with his head in the center section between the front wheels. This serves two main purposes: first, it provides more substantial protection with the driver shielded by multiple layers of armor plating. Second, the low-down, centralized driving position makes extreme precision maneuvers easier to perform, while lying prone reduces the risk of injury a driver faces when making these maneuvers.",
                        ProductPrice = 25000000.00M,
                        ProductImgUrl="http://media.comicbook.com/uploads1/2015/01/batmobile-tumbler-118336.jpg",
                        ProductCount=3,
                        IsEdible=false
                    },
                    new Product {
                        Seller = Sellers["Stark Industries"],
                        ProductName = "Arc Reactor",
                        ProductShortDescription = "Powers a heart for over 50 lifetimes.",
                        ProductLongDescription = "Engineered by Tony Stark himself in a cave, with scraps.",
                        ProductPrice = 100000000000.00M,
                        ProductImgUrl="https://i0.wp.com/lanteanar-automated-transfer-1.blog/wp-content/uploads/2018/01/iron-man-arc-reactor-mk1-3d-model-max-obj-fbx-mtl-1.jpg?ssl=1",
                        ProductCount=1,
                        IsEdible=false
                    },
                    new Product {
                        Seller = Sellers["Ace Chemicals"],
                        ProductName = "Skin Bleach",
                        ProductShortDescription = "Adverse side affects.",
                        ProductLongDescription = "Probably not FDA approved.",
                        ProductPrice = 10.99M,
                        ProductImgUrl="https://mixedtees.com/image/cache/catalog/data/Shirts/Suicide%20Squad/ACE%20Chemicals/AceChemicals-PLATE-750x750.jpg",
                        ProductCount=100,
                        IsEdible=false
                    }
                );
            }

            context.SaveChanges();

        }
        private static Dictionary<string, Seller> sellers;
        public static Dictionary<string, Seller> Sellers
        {
            get
            {
                if (sellers == null)
                {
                    var sellerList = new Seller[]
                    {
                        new Seller { SellerName = "Paintball Planet", SellerDescription = "Paintball Retailer"},
                        new Seller { SellerName = "Wayne Enterprises", SellerDescription = "Splunking Gear"},
                        new Seller { SellerName = "Stark Industries", SellerDescription = "Science Supply"},
                        new Seller { SellerName = "Ace Chemicals", SellerDescription = "Cleaning Products"}
                    };

                    sellers = new Dictionary<string, Seller>();

                    foreach (Seller seller in sellerList)
                    {
                        sellers.Add(seller.SellerName, seller);
                    }
                }

                return sellers;
            }
        }

        public static void SeedAdmin(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {

            if (!roleManager.RoleExistsAsync("Admins").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admins";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
            if (userManager.FindByNameAsync("Admin").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "Admin";
                user.Email = "admin@admin.com";

                IdentityResult result = userManager.CreateAsync
                (user, "Password123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,
                                        "Admins").Wait();
                }
            }
        }
    }
}