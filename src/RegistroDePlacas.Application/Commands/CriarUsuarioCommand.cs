using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegistroDePlacas.Application.Abstractions;
using RegistroDePlacas.Domain.Usuarios;

namespace RegistroDePlacas.Application.Commands
{
    public class CriarUsuarioCommand : Notificacao, ICommand
    {
        public CriarUsuarioCommand(){}
        public CriarUsuarioCommand(string nome, string cpf, Endereco endereco, string telefone, string placaDoVeiculo)
        {
            Nome = nome;
            Cpf = cpf;
            Endereco = endereco;
            Telefone = telefone;
            PlacaDoVeiculo = placaDoVeiculo;
        }

        public string Nome { get; set; }
        public string Cpf { get; set; }
        public Endereco Endereco { get; set; }
        public string Telefone { get; set; }
        public string PlacaDoVeiculo { get; set; }

        public void Execute()
        {
            LimparNotificacoes();

            AddNotificacao(Nome, "Nome", "O nome deve ser preenchido");
            AddNotificacao(Cpf, "CPF", "O CPF deve ser preenchido");
            AddNotificacao(PlacaDoVeiculo, "Placa Do Veiculo", "A placa do veiculo deve ser preenchido");
        }
    }
}