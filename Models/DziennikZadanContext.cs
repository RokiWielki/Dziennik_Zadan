using Microsoft.EntityFrameworkCore;

namespace Dziennik_Zadan.Models
{
    public class DziennikZadanContext : DbContext
    {
        public DziennikZadanContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<ZadaniaModel> Zadania { get; set; }
    }
}
