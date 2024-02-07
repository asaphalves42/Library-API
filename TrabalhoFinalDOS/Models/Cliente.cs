using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security;

namespace TrabalhoFinalDOS.Models
{
    [Table("clientes")]
    public class Cliente
    {
        public Cliente(string Nome, string Endereco, string Telemovel, string Email)
        {
            this.Nome = Nome;
            this.Endereco = Endereco;
            this.Telemovel = Telemovel;
            this.Email = Email;
        }

        [Key, Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string Nome { get; private set; }

        [Column("endereco")]
        public string Endereco { get; private set; }

        [Column("telemovel")]
        public string Telemovel { get; private set; }

        [Column("email")]
        public string Email { get; private set; }

    }
}