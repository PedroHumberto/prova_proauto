using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegistroDePlacas.Domain.Usuarios;

namespace RegistroDePlacas.Web.Models
{
    public class AtualizarEnderecoViewModel
    {
        public string CPF { get; set; }
        public Endereco Endereco { get; set; }
    }
}