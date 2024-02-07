using System.Net;

namespace TrabalhoFinalDOS._2___Services.Excepcoes
{
    public class ExcepcaoHTTP : Exception
    {
        public string Mensagem;
        public HttpStatusCode HTTPCode;

        public ExcepcaoHTTP(string mensagem, HttpStatusCode codigo)
        {
            Mensagem = mensagem;
            HTTPCode = codigo;
        }
    }
}
