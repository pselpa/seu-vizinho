using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Common;

namespace Infra
{
    public class RepositoryInMemory<T> : IRepository<T> where T : Entity
    {
        private List<T> _entities = new List<T>();
        public IReadOnlyCollection<T> Entities => _entities;

        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public T Get(Func<T, bool> predicate)
        {
            return _entities.FirstOrDefault(predicate);
        }

        public T Get(Guid id)
        {
            return _entities.FirstOrDefault(x => x.Id == id);
        }
    }
}
