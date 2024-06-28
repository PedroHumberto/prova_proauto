using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroDePlacas.Domain.Usuarios
{
    public record class Endereco
    (
        string Rua,
        string Numero,
        string? Complemento,
        string Bairro,
        string CEP,
        string Cidade,
        string Estado
    );

}