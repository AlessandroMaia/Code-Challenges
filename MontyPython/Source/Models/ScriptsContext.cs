using Microsoft.EntityFrameworkCore;

namespace Source.Models
{
    public class ScriptsContext : DbContext
    {
        public virtual DbSet<Quote> Quotes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=scripts.db");
        }
    }
}
