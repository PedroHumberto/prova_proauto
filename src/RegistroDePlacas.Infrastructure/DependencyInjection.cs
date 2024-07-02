using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RegistroDePlacas.Application.Abstractions;
using RegistroDePlacas.Application.Commands;
using RegistroDePlacas.Application.Handlers;
using RegistroDePlacas.Domain.Usuarios;
using RegistroDePlacas.Infrastructure.Data;
using RegistroDePlacas.Infrastructure.Repositories;

namespace RegistroDePlacas.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            var connectionString = configuration.GetConnectionString("Database") ?? 
                throw new ArgumentNullException(paramName: nameof(configuration));

            services.AddDbContext<ApplicationDbContext>(opts => {
                opts.UseSqlServer(connectionString);
            });

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IHandler<CriarUsuarioCommand>, CriarUsuarioHandler>();

            services.AddSingleton<ISqlConnectionFactory> (_ => new SqlConnectionFactory(connectionString));
            return services;
        }
    }
}