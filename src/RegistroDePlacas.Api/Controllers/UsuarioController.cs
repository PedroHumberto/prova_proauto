using Microsoft.AspNetCore.Mvc;
using RegistroDePlacas.Application.Abstractions;
using RegistroDePlacas.Application.Commands;

namespace RegistroDePlacas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly  IHandler<CriarUsuarioCommand> _criarUsuariohandler;
        private readonly  IHandler<UpdateEnderecoCommand> _updateEnderecoHandler;

        public UsuarioController(IHandler<CriarUsuarioCommand> criarUsuariohandler, IHandler<UpdateEnderecoCommand> updateEnderecoHandler)
        {
            _criarUsuariohandler = criarUsuariohandler;
            _updateEnderecoHandler = updateEnderecoHandler;
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> CriarUsuario([FromBody]CriarUsuarioCommand command)
        {
            GenericCommandResult? result = (GenericCommandResult)await _criarUsuariohandler.Handle(command);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("update_endereco")]
        public async Task<IActionResult> UpdateEndereco([FromBody]UpdateEnderecoCommand command)
        {
            GenericCommandResult? result = (GenericCommandResult)await _updateEnderecoHandler.Handle(command);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}