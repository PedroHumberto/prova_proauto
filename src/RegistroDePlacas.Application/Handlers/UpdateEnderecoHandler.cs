using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegistroDePlacas.Application.Abstractions;
using RegistroDePlacas.Application.Commands;
using RegistroDePlacas.Application.Dto;
using RegistroDePlacas.Domain.Usuarios;

namespace RegistroDePlacas.Application.Handlers
{
    public class UpdateEnderecoHandler : IHandler<UpdateEnderecoCommand>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UpdateEnderecoHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ICommandResult> Handle(UpdateEnderecoCommand command)
        {
            command.Execute();
            if (!command.EhValido())
            {
                return new GenericCommandResult(false, "Erro na validação do endereço", command);
            }

            try
            {
                Usuario? usuario = await _usuarioRepository.GetUsuarioPorCPF(new CPF(command.Cpf));
                if(usuario is null)
                {
                    return new GenericCommandResult(false, "Usuario não encontrado", command);
                }
                usuario.UpdateEndereco(command.Endereco);

                await _usuarioRepository.UpdateUsuario(usuario);

                var enderecoDto = new EnderecoDto
                (
                    usuario.Endereco
                );

                return new GenericCommandResult(true, "Endereço Atualizado", enderecoDto);

            }
            catch (Exception ex)
            {
                return new GenericCommandResult(false, ex.Message, command);
            }

        }
    }
}