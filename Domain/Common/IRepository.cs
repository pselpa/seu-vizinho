using System;
using System.Collections.Generic;

namespace Domain.Common
{
    public interface IRepository<T> where T : Entity
    {
        void Add(T entity);
        
        T Get(Func<T, bool> predicate);

        IEnumerable<T> GetAll(Func<T, bool> predicate);

        T Get(Guid id);

        void Modify(T entity);

        void Remove(T entity);
    }
}
