using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegistroDePlacas.Domain.Usuarios;

namespace RegistroDePlacas.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CriarUsuario(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
        }
    }
}