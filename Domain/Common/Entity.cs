using System;

namespace Domain.Common
{
    // Abstract, pois não devemos instanciar a classe Entity. Ela é apenas um modelo.
    public abstract class Entity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}