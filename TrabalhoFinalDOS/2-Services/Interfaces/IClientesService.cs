﻿using TrabalhoFinalDOS._2_Services;
using TrabalhoFinalDOS.DTO;

namespace TrabalhoFinalDOS.Services
{
    public interface IClientesService
    {
        public ClienteDTO CriarCliente(ClienteDTO novoCliente);

        public List<ClienteDTO> ObterClientes();

        public ClienteDTO ObterCliente(int Id);
    }
}
