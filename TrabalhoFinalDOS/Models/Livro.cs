using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrabalhoFinalDOS.Models
{
    [Table("livros")]
    public class Livro
    {
        public Livro(string Titulo, string Autor, int Ano)
        {
            this.Titulo = Titulo;
            this.Autor = Autor;
            this.Ano = Ano;
        }

        [Key, Column("id")]
        public int Id { get; private set; }

        [Column("titulo")]
        public string Titulo { get; private set; }

        [Column("autor")]
        public string Autor { get; private set; }

        [Column("ano")]
        public int Ano { get; private set; }

        //public ICollection<Reserva> Reservas { get; } = new List<Reserva>();

    }
}
