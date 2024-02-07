using TrabalhoFinalDOS.DTO;
using TrabalhoFinalDOS.Models;

namespace TrabalhoFinalDOS._2_Services.Mapper
{
    public static class Mappers
    {
        public static LivroDTO livroParaDTO(this Livro livro)
        {
            if (livro == null)
            {
                return null;
            }

            return new LivroDTO()
            {
                Id = livro.Id,
                Titulo = livro.Titulo,
                Autor = livro.Autor,
                Ano = livro.Ano
            };
        }

        public static Livro DTOParaLivro(this LivroDTO livro)
        {
            return new Livro(livro.Titulo, livro.Autor, livro.Ano);
        }

    }
}
