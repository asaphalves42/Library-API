using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinalDOS._1_Controllers.v1;
using TrabalhoFinalDOS._2_Services.Interfaces;
using TrabalhoFinalDOS.DTO;
using TrabalhoFinalDOS.Services;

namespace TrabalhoFinalDOS.Tests
{
    public class CriarLivroTeste
    {
        [Fact]
        public void CriarLivro_DeveRetornarOKQuandoLivroCriadoComSucesso()
        {

            var livrodTO = new LivroDTO
            {
                Id = 1, 
                Titulo = "Livro Teste",
                Autor = "Autor de teste",
                Ano = 1234,
            
            };

            var mockLogger = new Mock<ILogger<LivrosController>>();
            var mockLivrosService = new Mock<ILivrosService>();
            mockLivrosService.Setup(service => service.CriarLivro(It.IsAny<LivroDTO>()))
                               .Returns(livrodTO);

            var controller = new LivrosController(mockLogger.Object, mockLivrosService.Object);

            // Act
            var result = controller.CriarLivro(livrodTO) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);

            var livroCriado = result.Value as LivroDTO;
            Assert.NotNull(livroCriado);
            Assert.Equal(livrodTO.Id, livroCriado.Id);
            Assert.Equal(livrodTO.Titulo, livroCriado.Titulo);
            Assert.Equal(livrodTO.Autor, livroCriado.Autor);
            Assert.Equal(livrodTO.Ano, livroCriado.Ano);
        }
    }
}

