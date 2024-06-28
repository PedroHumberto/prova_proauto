using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroDePlacas.Application.Abstractions
{
    public interface IHandler<T> where T : ICommand
    {
        Task<ICommandResult> Handle(T command);

    }
}