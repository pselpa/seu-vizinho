using System;

namespace Domain.Common
{
    public interface IRepository<T> where T : Entity
    {
        void Add(T entity);
        T Get(Func<T, bool> predicate);
    }
}
