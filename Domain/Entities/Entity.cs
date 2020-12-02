using System;

namespace Domain.Entities
{
    // Abstract, pois não devemos instanciar a classe Entity. Ela é apenas um modelo.
    public abstract class Entity
    {
        public Guid Id { get; protected set; } = Guid.NewGuid();
    }
}