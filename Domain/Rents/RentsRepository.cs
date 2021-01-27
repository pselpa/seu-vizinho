using System;
using Domain.Common;
using System.Linq;

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

        public Rent Get(Guid id)
        {
            return _repository.Get(x => x.Id == id);
        }
    }
}