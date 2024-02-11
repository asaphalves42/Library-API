using TrabalhoFinalDOS._2___Services.Excepcoes;

namespace TrabalhoFinalDOS.DTO
{
    public class LivroDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Ano { get; set; }

        public void Validar()
        {
            string erros = "";
            if (Titulo.Length == 0)
            {
                erros += "Titulo obrigatório; ";
            }

            if (Autor.Length == 0)
            {
                erros += "Autor obrigatório; ";
            }

            if (Ano.ToString().Length != 4)
            {
                erros += "Ano inválido; ";
            }

            if (erros != "")
            {
                throw new ExcepcaoHTTP(erros, System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}
