using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dziennik_Zadan.Models
{
    public class DziennikZadanContext : IdentityDbContext<LogowanieUser>
    {
        public DziennikZadanContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<ZadaniaModel> Zadania { get; set; }
        
    }
}
