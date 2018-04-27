using System.Collections.Generic;
using FinalProject4790.Auth;
using FinalProject4790.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FinalProject4790.Views.ViewModels
{
    public class UserRoleViewModel
    {
        public UserRoleViewModel()
        {
            Users = new List<AppUser>();
        }
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public List<AppUser> Users { get; set; }

    }
}