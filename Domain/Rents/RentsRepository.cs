using System;
using System.Collections.Generic;
using Domain.Common;
using Domain.Products;

namespace Domain.Rents
{
    public class RentsRepository: IRentsRepository
    {
        private readonly IRepository<Rent> _repository;

        public RentsRepository(IRepository<Rent> repository)
        {
            _repository = repository;
        }

        public void Add(Rent rent)
        {
            _repository.Add(rent);
        }

        public Rent Get(Func<Rent, bool> predicate)
        {
            return _repository.Get(predicate);
        }

        public IEnumerable<Rent> GetAll(Func<Rent, bool> predicate)
        {
            return _repository.GetAll(predicate);
        }

        public Rent Get(Guid id)
        {
            return _repository.Get(id);
        }

        public void Modify(Rent entity)
        {
            _repository.Modify(entity);
        }

        public void Remove(Rent entity)
        {
            _repository.Remove(entity);
        }
    }
}