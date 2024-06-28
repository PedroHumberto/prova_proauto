using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroDePlacas.Domain.Abstractions
{
    public abstract class Entity
    {
        protected Entity(Guid id)
        {
            Id = id;
        }

        protected Entity() { }
        public Guid Id {get; init;}

    }
}