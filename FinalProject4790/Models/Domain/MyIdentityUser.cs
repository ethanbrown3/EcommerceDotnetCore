using Microsoft.AspNetCore.Identity;

namespace FinalProject4790.Models.Domain
{
    public class MyIdentityUser : IdentityUser
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}