using System.Net;
using TrabalhoFinalDOS._2___Services.Excepcoes;
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
        public List<ClienteDTO> ObterClientes()
        {
            //acedo a base de dados, utiliza tabela de clientes, seleciona todos e por cada registo passa pelo metodo de converter em dto
            return this._basedados.Cliente.Select(x => x.clienteParaDTO()).ToList();
        }

        public ClienteDTO ObterCliente(int Id)
        {
            var cliente = this._basedados.Cliente.Where(objecto => objecto.Id == Id).FirstOrDefault();
            if (cliente == null)
            {
                throw new ExcepcaoHTTP("Cliente não encontrado", HttpStatusCode.NotFound);
            }
            return cliente.clienteParaDTO();
        }
    }
}