using Microsoft.AspNetCore.Identity;

namespace Dziennik_Zadan.Models
{
    public class LogowanieUser : IdentityUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
