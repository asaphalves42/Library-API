using TrabalhoFinalDOS.DTO;
using TrabalhoFinalDOS.Models;

namespace TrabalhoFinalDOS._1_Controllers.v1
{
    public class ClientesController : ControllerBase
    {
        private readonly ILogger<ClientesController> logger;
        private readonly IClientesService _servicoClientes;

        public ClientesController(ILogger<ClientesController> logger, IClientesService servicoClientes)
        {
            _logger = logger;
            _servicoClientes = servicoClientes;
        }
        public ClienteDTO CriarCliente(ClienteDTO novoCliente)
        {
            Cliente cliente = novoCliente.DTOParaCliente();
            this._basedados.Cliente.Add(cliente);
            this._basedados.SaveChanges();
            return cliente.clienteParaDTO();
        }
    }
}
