using Microsoft.AspNetCore.Identity;

namespace WebAppDam.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? Address { get; set; }
    }
}
