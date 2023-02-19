using System.ComponentModel.DataAnnotations;
namespace Dziennik_Zadan.Models
{
    public class Rejestracja
    {
        [Required]
        public string UserName { get; set; }
        [EmailAddress] 
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
