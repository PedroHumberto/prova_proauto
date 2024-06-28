using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegistroDePlacas.Domain.Usuarios;

namespace RegistroDePlacas.Application.Dto
{
    public record CriaUsuarioDto
    (
        string Nome,
        CPF cpf,
        Endereco endereco,
        string telefone,
        string placaDoVeiculo
    );

}