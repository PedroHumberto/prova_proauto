using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            await _context.SaveChangesAsync();
        }
        public async Task<Usuario> GetUsuarioPorCPF(CPF cpf)
        {
            Usuario? usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.CPF == cpf);

            return usuario;
        }

        public async Task UpdateUsuario(Usuario usuario)
        {

            _context.Update(usuario);

            await _context.SaveChangesAsync();

        }
    }
}