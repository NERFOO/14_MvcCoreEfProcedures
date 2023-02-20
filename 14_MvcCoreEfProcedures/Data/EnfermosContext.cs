using _14_MvcCoreEfProcedures.Models;
using Microsoft.EntityFrameworkCore;

namespace _14_MvcCoreEfProcedures.Data
{
    public class EnfermosContext : DbContext
    {
        public EnfermosContext(DbContextOptions<EnfermosContext> options) : base(options) { }

        public DbSet<Enfermo> Enfermos { get; set; }
    }
}
