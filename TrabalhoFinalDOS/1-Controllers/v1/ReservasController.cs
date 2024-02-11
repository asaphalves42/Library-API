using Microsoft.AspNetCore.Mvc;
using TrabalhoFinalDOS.DTO;
using TrabalhoFinalDOS.Models;
using TrabalhoFinalDOS.Services;

namespace TrabalhoFinalDOS.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ReservasController : ControllerBase
    {
        private readonly ILogger<ReservasController> _logger;
        private readonly IReservasService _servicoReservas;

        public ReservasController(ILogger<ReservasController> logger, IReservasService servicoReservas)
        {
            _logger = logger;
            _servicoReservas = servicoReservas;
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReservaDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ObterReservaPorId(int id)
        {
            return Ok(this._servicoReservas.ObterReservaPorId(id));
        }

        [HttpGet("Get/{idCliente}/Livros")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReservaDTO))]
        public IActionResult ObterReservasPorCliente(int idCliente)
        {
            return Ok(this._servicoReservas.ObterReservaPorCliente(idCliente));
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NovaReservaDTO))]
        public IActionResult CriarReserva([FromBody] NovaReservaDTO body)
        {
            var reservaCriada = _servicoReservas.CriarReserva(body);
            return Ok(reservaCriada);
        }
    }
}
