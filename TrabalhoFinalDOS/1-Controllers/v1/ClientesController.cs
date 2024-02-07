using Microsoft.AspNetCore.Mvc;
using TrabalhoFinalDOS._2_Services.Mapper;
using TrabalhoFinalDOS.DTO;
using TrabalhoFinalDOS.Models;
using TrabalhoFinalDOS.Services;

namespace TrabalhoFinalDOS._1_Controllers.v1
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ILogger<ClientesController> _logger;
        private readonly IClientesService _servicoClientes;

        public ClientesController(ILogger<ClientesController> logger, IClientesService servicoClientes)
        {
            _logger = logger;
            _servicoClientes = servicoClientes;
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClienteDTO))]
        public IActionResult CriarCliente([FromBody] ClienteDTO body)
        {
            return Ok(this._servicoClientes.CriarCliente(body));
        }

    }
}
