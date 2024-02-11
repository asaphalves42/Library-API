using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TrabalhoFinalDOS._1_Controllers.v1;
using TrabalhoFinalDOS.Controllers;
using TrabalhoFinalDOS.DTO;
using TrabalhoFinalDOS.Models;
using TrabalhoFinalDOS.Services;
using Xunit;

namespace TrabalhoFinalDOS.Tests
{
    public class ClienteTest
    {
        private readonly IClientesService _servicoClientes;

        [Fact]
        public void InserirClientes()
        {
            // Arrange
            var clienteDto = new ClienteDTO
            {
                Nome = "Cliente Teste",
                Endereco = "Endereço de Teste",
                Telemovel = "123456789",
                Email = "teste@teste.com"
            };

            var cliente = new Cliente(clienteDto.Nome, clienteDto.Endereco, clienteDto.Telemovel, clienteDto.Email);
            var clienteController = new ClientesController(clienteDto);
            // Act
            var result = clienteController.CriarCliente(clienteDto) as OkObjectResult;
            var clienteCriado = result.Value as ClienteDTO;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(clienteCriado);
            Assert.Equal(clienteDto.Nome, clienteCriado.Nome);
            Assert.Equal(clienteDto.Endereco, clienteCriado.Endereco);
            Assert.Equal(clienteDto.Telemovel, clienteCriado.Telemovel);
            Assert.Equal(clienteDto.Email, clienteCriado.Email);
        }
    }
}
