using TrabalhoFinalDOS.DTO;
using TrabalhoFinalDOS.Models;

namespace TrabalhoFinalDOS.Mapper
{
    public static class Mappers
    {
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
        public static Cliente DTOParaCliente(this ClienteDTO cliente)
        {
            return new Cliente(cliente.Nome, cliente.Endereco, cliente.Telemovel, cliente.Email);
        }
    }
}