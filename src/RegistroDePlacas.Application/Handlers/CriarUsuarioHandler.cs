using System.Text.Json;
using RegistroDePlacas.Application.Abstractions;
using RegistroDePlacas.Application.Commands;
using RegistroDePlacas.Application.Dto;
using RegistroDePlacas.Domain.Usuarios;

namespace RegistroDePlacas.Application.Handlers
{
    public class CriarUsuarioHandler : IHandler<CriarUsuarioCommand>
    {
        private readonly IUsuarioRepository _repository;

        public CriarUsuarioHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(CriarUsuarioCommand command)
        {
            command.Execute();
            if(command.EhValido() is false)
            {
                return new GenericCommandResult(false, "Erro na validação do cadastro", command);
            }

            try
            {
                var usuario = Usuario.CriarUsuario
                (
                    command.Nome,
                    new CPF(command.Cpf),
                    command.Endereco,
                    command.Telefone,
                    command.PlacaDoVeiculo
                );

                var usuarioExistente = await _repository.GetUsuarioPorCPF(usuario.CPF);

                if(usuarioExistente is not null)
                {
                    return new GenericCommandResult(false, "CPF já cadastrado", command);
                }

                await _repository.CriarUsuario(usuario);

                var usuarioDto = new CriaUsuarioDto
                (
                    usuario.Nome,
                    usuario.CPF,
                    usuario.Endereco,
                    usuario.Telefone,
                    usuario.PlacaDoVeiculo
                );

                return new GenericCommandResult(true, "Usuario criado com sucesso", usuarioDto);
            }
            catch (Exception ex)
            {

                return new GenericCommandResult(false, ex.Message, ex);
            }
        }
    }
}