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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //informo o sistema sobre a relação de tabelas livro <> reserva e cliente <> reserva
            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Reservas)
                .WithOne(e => e.Cliente)
                .HasForeignKey(e => e.IdCliente)
                .IsRequired();


            modelBuilder.Entity<Livro>()
               .HasMany(e => e.Reservas)
               .WithOne(e => e.Livro)
               .HasForeignKey(e => e.IdLivro)
               .IsRequired();

            //sempre que selecionar alguma reserva, ele carrega da base de dados os objetos cliente e livro
            modelBuilder.Entity<Reserva>().Navigation(e => e.Cliente).AutoInclude();
            modelBuilder.Entity<Reserva>().Navigation(e => e.Livro).AutoInclude();

            base.OnModelCreating(modelBuilder);
        }


    }

}
