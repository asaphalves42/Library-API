using System.Collections.Generic;

namespace TrabalhoFinalDOS._3_Repository
{
    public class BaseDados : DbContext
    {
        public BaseDados(DbContextOptions<BaseDados> options) : base(options) { }

        public DbSet<Cliente> Cliente => Set<Cliente>();
    }
}
