using TrabalhoFinalDOS._2_Services.Interfaces;
using TrabalhoFinalDOS.DTO;
using TrabalhoFinalDOS.Models;

namespace TrabalhoFinalDOS._2_Services
{
    public class LivrosService : ILivrosService
    {
        private readonly BaseDados _basedados;
        public LivrosService(BaseDados basedados)
        {
            _basedados = basedados;
        }
        public List<LivroDTO> ObterLivros()
        {
            //acedo a base de dados, utiliza tabela de livros, seleciona todos e por cada registo passa pelo metodo de converter em dto
            return this._basedados.Livro.Select(x => x.livroParaDTO()).ToList();
        }

        public LivroDTO CriarLivro(LivroDTO novoLivro)
        {
            Livro livro = novoLivro.DTOParaLivro();
            this._basedados.Livro.Add(livro);
            this._basedados.SaveChanges();
            return livro.livroParaDTO();
        }


    }
}
