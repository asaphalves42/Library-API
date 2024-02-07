using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrabalhoFinalDOS.Models
{
    [Table("reservas")]
    public class Reserva
    {
        public Reserva(int IdCliente, int IdLivro, DateTime Data)
        {
            this.IdCliente = IdCliente;
            this.IdLivro = IdLivro;
            this.Data = Data;
        }

        [Key, Column("id")]
        public int Id { get; private set; }

        [Column("id_cliente")]
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; } = null!;

        [Column("id_livro")]
        public int IdLivro { get; set; }
        public Livro Livro { get; private set; }

        [Column("Data")]
        public DateTime Data { get; private set; }

    }
}