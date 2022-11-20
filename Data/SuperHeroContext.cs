using Microsoft.EntityFrameworkCore;
using Net7Demo.Models;

namespace Data
{
    public class SuperHeroContext:DbContext
    {
        public SuperHeroContext(DbContextOptions<SuperHeroContext> options):base(options) { }
        public DbSet<SuperHero> SuperHeroes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;Database=heroDB;Trusted_Connection=true;TrustServerCertificate=true;");
        }
    }
}