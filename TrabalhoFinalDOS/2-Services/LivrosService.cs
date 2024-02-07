using System.Net;
using TrabalhoFinalDOS._2_Services.Interfaces;
using TrabalhoFinalDOS._2_Services.Mapper;
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

        public LivroDTO ObterLivro(int id)
        {
            var livro = this._basedados.Livro.Where(objecto => objecto.Id == id).FirstOrDefault();
            if (livro == null)
            {
                throw new ExcepcaoHTTP("Livro não encontrado", HttpStatusCode.NotFound);
            }
            return livro.livroParaDTO();
        }


    }
}
