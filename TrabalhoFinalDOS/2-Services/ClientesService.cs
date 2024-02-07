using TrabalhoFinalDOS._2_Services.Mapper;
using TrabalhoFinalDOS.DTO;
using TrabalhoFinalDOS.Models;
using TrabalhoFinalDOS.Repository;
using TrabalhoFinalDOS.Services;

namespace TrabalhoFinalDOS._2_Services
{
    public class ClientesService : IClientesService
    {

        private readonly BaseDados _basedados;
        public ClientesService(BaseDados basedados)
        {
            _basedados = basedados;
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