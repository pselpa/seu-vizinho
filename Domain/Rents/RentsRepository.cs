using System;
using System.Collections.Generic;
using Domain.Common;
using Domain.Products;
using Domain.Users;

namespace Domain.Rents
{
    public class RentsRepository: IRentsRepository
    {
        private readonly IRepository<Rent> _rentsRepository;
        private readonly IRepository<User> _usersRepository;
        private readonly IRepository<Product> _productsRepository;

        public RentsRepository(IRepository<Rent> rentsRepository, IRepository<User> usersRepository, IRepository<Product> productsRepository)
        {
            _rentsRepository = rentsRepository;
            _usersRepository = usersRepository;
            _productsRepository = productsRepository;
        }

        public void Add(Rent rent)
        {
            _rentsRepository.Add(rent);
        }

        public Rent Get(Func<Rent, bool> predicate)
        {
            return _rentsRepository.Get(predicate);
        }

        public IEnumerable<Rent> GetAll(Func<Rent, bool> predicate)
        {
            return _rentsRepository.GetAll(predicate);
        }

        public Rent Get(Guid id)
        {
            return _rentsRepository.Get(id);
        }

        public void Modify(Rent entity)
        {
            _rentsRepository.Modify(entity);
        }

        public void Remove(Rent entity)
        {
            _rentsRepository.Remove(entity);
        }
    }
}