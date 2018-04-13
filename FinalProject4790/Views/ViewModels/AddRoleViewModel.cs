using System.ComponentModel.DataAnnotations;

namespace FinalProject4790.Views.ViewModels
{
    public class AddRoleViewModel
    {
        [Required]
        [Display(Name = "Role name")]
        public string RoleName { get; set; }
    }
}