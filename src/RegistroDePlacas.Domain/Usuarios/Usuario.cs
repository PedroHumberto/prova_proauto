using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegistroDePlacas.Domain.Abstractions;

namespace RegistroDePlacas.Domain.Usuarios
{
    public class Usuario : Entity
    {
        private Usuario(Guid id, string nome, CPF cpf, Endereco endereco, string telefone, string placaDoVeiculo) : base(id)
        {
            Nome = nome;
            CPF = cpf;
            Endereco = endereco;
            Telefone = telefone;
            PlacaDoVeiculo = placaDoVeiculo;
        }
        private Usuario() {}

        public string Nome { get; private set; }
        public CPF CPF { get; private set; }
        public Endereco Endereco { get; private set; }
        public string Telefone { get; private set; }
        public string PlacaDoVeiculo { get; private set; }

        public static Usuario CriarUsuario(string nome, CPF cpf, Endereco endereco, string telefone, string placaDoVeiculo)
        {
            Usuario ususario = new Usuario(Guid.NewGuid(), nome, cpf, endereco, telefone, placaDoVeiculo);

            return ususario;
        }

        public Endereco UpdateEndereco(Endereco endereco)
        {
            Endereco = endereco;

            return Endereco;
        }

    }
}