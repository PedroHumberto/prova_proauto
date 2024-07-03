using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegistroDePlacas.Application.Abstractions;
using RegistroDePlacas.Domain.Usuarios;

namespace RegistroDePlacas.Application.Commands
{
    public class UpdateEnderecoCommand : Notificacao, ICommand
    {
        public UpdateEnderecoCommand(){}
        public UpdateEnderecoCommand(Endereco endereco, string cpf)
        {
            Endereco = endereco;
            Cpf = cpf;
        }

        public string Cpf { get; set; }
        public Endereco Endereco { get; set; }
        public void Execute()
        {
            AddNotificacao(Endereco.Rua, "Rua", "A Rua deve ser preenchida");
            AddNotificacao(Endereco.Numero, "Numero", "O Numero deve ser preenchida");
            AddNotificacao(Endereco.Bairro, "Bairro", "Bairro deve ser preenchido");
            AddNotificacao(Endereco.Cidade, "Cidade", "Cidade deve ser preenchida");
            AddNotificacao(Endereco.CEP, "CEP", "CEP deve ser preenchido");
            AddNotificacao(Endereco.Estado, "Estado", "O Estado deve ser preenchida");
        }
    }
}