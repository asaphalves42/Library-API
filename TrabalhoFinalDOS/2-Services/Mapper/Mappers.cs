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

        public static ClienteDTO clienteParaDTO(this Cliente cliente)
        {
            if (cliente == null)
            {
                return null;
            }

            return new ClienteDTO()
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Endereco = cliente.Endereco,
                Email = cliente.Email,
                Telemovel = cliente.Telemovel,
            };
        }

        public static ReservaDTO ReservaParaDTO(this Reserva reserva)
        {
            return new ReservaDTO()
            {
                Id = reserva.Id,
                Cliente = reserva.Cliente.Nome,
                Titulo = reserva.Livro.Titulo,
                Data = reserva.Data
            };

        }

        public static ReservaClienteDTO ReservaParaDTOClienteReserva(this Reserva reserva)
        {
            return new ReservaClienteDTO()
            {
                Id = reserva.Id,
                Titulo = reserva.Livro.Titulo,
                Autor = reserva.Livro.Autor,
                Data = reserva.Data
            };
        }
        public static Reserva DTOParaReserva(this NovaReservaDTO reserva)
        {

            return new Reserva(reserva.IdCliente, reserva.IdLivro, reserva.Data);
        }
        public static Cliente DTOParaCliente(this ClienteDTO cliente)
        {
            return new Cliente(cliente.Nome, cliente.Endereco, cliente.Telemovel, cliente.Email);
        }

    }
}
