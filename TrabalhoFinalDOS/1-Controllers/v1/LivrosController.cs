using Microsoft.AspNetCore.Mvc;
using TrabalhoFinalDOS._2_Services.Interfaces;
using TrabalhoFinalDOS.DTO;

namespace TrabalhoFinalDOS._1_Controllers.v1
{
    [ApiController]
    [Route("v1/[controller]")]
    public class LivrosController
    {

        private readonly ILogger<LivrosController> _logger;
        private readonly ILivrosService _servicoLivros;

        public LivrosController(ILogger<LivrosController> logger, ILivrosService servicoLivros)
        {
            _logger = logger;
            _servicoLivros = servicoLivros;
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LivroDTO))]
        public IActionResult CriarLivro([FromBody] LivroDTO body)
        {
            return Ok(this._servicoLivros.CriarLivro(body));
        }



    }
}
