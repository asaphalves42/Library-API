using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using TrabalhoFinalDOS.Models;

namespace TrabalhoFinalDOS.Repository
{
    public class BaseDados : DbContext
    {
        public BaseDados(DbContextOptions<BaseDados> options) : base(options) { }

        public DbSet<Cliente> Cliente => Set<Cliente>();

        public DbSet<Livro> Livro => Set<Livro>();
        public DbSet<Reserva> Reserva => Set<Reserva>();

    }

}
