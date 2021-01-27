using System;
using Domain.Common;
using Domain.Products;

namespace Domain.Rents
{
    public interface IRentsRepository : IRepository<Rent>
    {
        Rent GetById(Guid id);
    }
}