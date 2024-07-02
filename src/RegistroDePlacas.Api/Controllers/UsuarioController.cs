using Microsoft.AspNetCore.Mvc;
using RegistroDePlacas.Application.Abstractions;
using RegistroDePlacas.Application.Commands;

namespace RegistroDePlacas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly  IHandler<CriarUsuarioCommand> _handler;

        public UsuarioController(IHandler<CriarUsuarioCommand> handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> CriarUsuario([FromBody]CriarUsuarioCommand command)
        {
            GenericCommandResult? result = (GenericCommandResult)await _handler.Handle(command);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}