using static System.Runtime.InteropServices.JavaScript.JSType;
using TrabalhoFinalDOS._2___Services.Excepcoes;

namespace TrabalhoFinalDOS.DTO
{
    public class ClienteDTO
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telemovel { get; set; }
        public string Email { get; set; }

        public void Validar()
        {
            string erros = "";
            if (Nome.Length == 0)
            {
                erros += "Nome obrigatório; ";
            }

            if (Endereco.Length == 0)
            {
                erros += "Endereco obrigatório; ";
            }

            if (Telemovel.Length != 0)
            {
                erros += "Telemovel inválido; ";
            }

            if (Telemovel.Length != 0)
            {
                erros += "Telemovel inválido; ";
            }

            if (Email.Length != 0)
            {
                erros += "Email inválido; ";
            }

            if (erros != "")
            {
                throw new ExcepcaoHTTP(erros, System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}