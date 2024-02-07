using TrabalhoFinalDOS._2_Services;
using TrabalhoFinalDOS._3_Repository;
using TrabalhoFinalDOS.DTO;

namespace TrabalhoFinalDOS.Services
{
    public class ClientesService : IClientesService
    {

        private readonly BaseDados _basedados;
        public ClientesService(BaseDados basedados)
        {
            _basedados = basedados;
        }
        public ClienteDTO CriarCliente(ClienteDTO novoCliente);
    }
}
