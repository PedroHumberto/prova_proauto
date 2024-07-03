using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroDePlacas.Domain.Usuarios
{
    public interface IUsuarioRepository
    {
        Task CriarUsuario(Usuario usuario);
        Task<Usuario> GetUsuarioPorCPF(CPF cpf);
        Task UpdateUsuario(Usuario usuario);
    }
}