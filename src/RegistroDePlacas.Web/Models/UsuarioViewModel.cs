using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegistroDePlacas.Domain.Usuarios;

namespace RegistroDePlacas.Web.Models
{
    public class UsuarioViewModel
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public Endereco Endereco { get; set; }
        public string Telefone { get; set; }
        public string PlacaDoVeiculo { get; set; }
    }
}