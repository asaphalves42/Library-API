using TrabalhoFinalDOS._2_Services;
using TrabalhoFinalDOS._3_Repository;
using TrabalhoFinalDOS.DTO;

namespace TrabalhoFinalDOS.Services
{
    public interface IClientesService
    {
        public ClienteDTO CriarCliente(ClienteDTO novoCliente);
    }
}
