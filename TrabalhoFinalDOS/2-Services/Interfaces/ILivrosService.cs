using TrabalhoFinalDOS.DTO;

namespace TrabalhoFinalDOS._2_Services.Interfaces
{
    public interface ILivrosService
    {
        public List<LivroDTO> ObterLivros();

        public LivroDTO ObterLivro(int Id);

        public LivroDTO CriarLivro(LivroDTO novoLivro);
    }
}
