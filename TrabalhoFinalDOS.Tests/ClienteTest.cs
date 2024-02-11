using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using TrabalhoFinalDOS._1_Controllers.v1;
using TrabalhoFinalDOS.DTO;
using TrabalhoFinalDOS.Services;
using Xunit;

namespace TrabalhoFinalDOS.Tests
{
    public class CriarClienteTeste
    {
        [Fact]
        public void CriarCliente_DeveRetornarOKQuandoClienteCriadoComSucesso()
        {
      
            var clienteDto = new ClienteDTO
            {
                Nome = "Cliente Teste",
                Endereco = "Endereço de Teste",
                Telemovel = "123456789",
                Email = "teste@teste.com"
            };

            var mockLogger = new Mock<ILogger<ClientesController>>();
            var mockClientesService = new Mock<IClientesService>();
            mockClientesService.Setup(service => service.CriarCliente(It.IsAny<ClienteDTO>()))
                               .Returns(clienteDto);

            var controller = new ClientesController(mockLogger.Object, mockClientesService.Object);

            // Act
            var result = controller.CriarCliente(clienteDto) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);

            var clienteCriado = result.Value as ClienteDTO;
            Assert.NotNull(clienteCriado);
            Assert.Equal(clienteDto.Nome, clienteCriado.Nome);
            Assert.Equal(clienteDto.Endereco, clienteCriado.Endereco);
            Assert.Equal(clienteDto.Telemovel, clienteCriado.Telemovel);
            Assert.Equal(clienteDto.Email, clienteCriado.Email);
        }
    }
}
