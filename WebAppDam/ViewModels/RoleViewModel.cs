using System.ComponentModel.DataAnnotations;

namespace WebAppDam.ViewModels
{
    public class RoleViewModel
    {
        [Display(Name ="Name")]
        public string RoleName { get; set; }
    }
}
