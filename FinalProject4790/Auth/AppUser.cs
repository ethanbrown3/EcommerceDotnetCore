using System;
using Microsoft.AspNetCore.Identity;

namespace FinalProject4790.Auth
{
    public class AppUser : IdentityUser
    {
        public int SellerId { get; set; }
    }
}