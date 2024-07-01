using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RegistroDePlacas.Domain.Usuarios;

namespace RegistroDePlacas.Infrastructure.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(usuario => usuario.Id);

            builder.OwnsOne(usuario => usuario.Endereco);

            builder.HasIndex(usuario => usuario.CPF).IsUnique();
            builder.HasIndex(usuario => usuario.PlacaDoVeiculo).IsUnique();
        }
    }
}