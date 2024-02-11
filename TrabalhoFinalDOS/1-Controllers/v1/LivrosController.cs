using Microsoft.AspNetCore.Mvc;
using TrabalhoFinalDOS._2_Services.Interfaces;
using TrabalhoFinalDOS.DTO;

namespace TrabalhoFinalDOS._1_Controllers.v1
{
    [ApiController]
    [Route("v1/[controller]")]
    public class LivrosController : ControllerBase
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CriarLivro([FromBody] LivroDTO body)
        {
            return Ok(this._servicoLivros.CriarLivro(body));
        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<LivroDTO>))]
        public IActionResult ObterTodos()
        {
            return Ok(this._servicoLivros.ObterLivros());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LivroDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ObterPorId(int id)
        {
            return Ok(this._servicoLivros.ObterLivro(id));
        }




    }
}
