using System;
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

        public User Get(Guid id)
        {
            return _repository.Get(id);
        }

        public User Remove(Guid id)
        {
            var user = _repository.Get(id);
            if (user == null) 
            {
                return null;
            }
            _repository.Remove(id);
            return user;
        }

    }
}