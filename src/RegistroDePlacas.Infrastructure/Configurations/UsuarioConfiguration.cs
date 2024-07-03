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

            builder.OwnsOne(u => u.Endereco, endereco =>
                {
                    endereco.Property(e => e.Rua).HasColumnName("Rua");
                    endereco.Property(e => e.Numero).HasColumnName("Numero");
                    endereco.Property(e => e.Complemento).HasColumnName("Complemento");
                    endereco.Property(e => e.Bairro).HasColumnName("Bairro");
                    endereco.Property(e => e.CEP).HasColumnName("CEP");
                    endereco.Property(e => e.Cidade).HasColumnName("Cidade");
                    endereco.Property(e => e.Estado).HasColumnName("Estado");
                });
            
            builder.Property(user => user.CPF)
                .HasMaxLength(11)
                .HasConversion(CPF => CPF.Numero, value => new CPF(value));

            builder.HasIndex(usuario => usuario.CPF).IsUnique();
            builder.HasIndex(usuario => usuario.PlacaDoVeiculo);
        }
    }
}