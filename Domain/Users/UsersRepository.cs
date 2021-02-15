using System;
using System.Collections.Generic;
using Domain.Common;

namespace Domain.Users
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IRepository<User> _repository;

        public UsersRepository(IRepository<User> repository)
        {
            _repository = repository;
        }

        public void Add(User user)
        {
            _repository.Add(user);
        }

        public User Get(Func<User, bool> predicate)
        {
            return _repository.Get(predicate);
        }

        public IEnumerable<User> GetAll(Func<User, bool> predicate)
        {
            return _repository.GetAll(predicate);
        }

        public User Get(Guid id)
        {
            return _repository.Get(id);
        }

        public void Modify(User entity)
        {
            _repository.Modify(entity);
        }

        public void Remove(User entity)
        {
            _repository.Remove(entity);
        }

    }
}