using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinalDOS.Controllers;
using TrabalhoFinalDOS.DTO;
using TrabalhoFinalDOS.Services;

namespace TrabalhoFinalDOS.Tests
{
    public class ReservaTeste
    {
        [Fact]
        public void CriarReserva_DeveRetornarOKQuandoReservaCriadaComSucesso()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<ReservasController>>();
            var mockReservasService = new Mock<IReservasService>();
            var reservaDTO = new NovaReservaDTO
            {
              Data = DateTime.Now,
              IdCliente = 1,
              IdLivro = 1
            };
            var reservaCriada = new ReservaDTO
            {
                Cliente = "teste",
               Data = DateTime.Now,
               Id = 1,
               Titulo = "teste"
            };
            mockReservasService.Setup(service => service.CriarReserva(It.IsAny<NovaReservaDTO>()))
                               .Returns(reservaCriada);
            var controller = new ReservasController(mockLogger.Object, mockReservasService.Object);

            // Act
            var result = controller.CriarReserva(reservaDTO) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);

            var reservaRetornada = result.Value as ReservaDTO;
            Assert.NotNull(reservaRetornada);
           
        }

    }
}
