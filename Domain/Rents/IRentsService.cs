using Domain.Users;
using Domain.Products;
using System;
using System.Collections.Generic;

namespace Domain.Rents
{
    public interface IRentsService
    {
        CreatedRentDTO Create(
            Guid customerId,
            Guid rentedProductId,
            DateTime date,
            DateTime contractStartDate,
            DateTime contractEndDate,
            string observation
        );

        double GetAmountOfDays(DateTime ContractStartDate, DateTime ContractEndDate);

        double CalculateRent(Guid productId, DateTime ContractStartDate, DateTime ContractEndDate);

        IEnumerable<Rent> GetAll(Func<Rent, bool> predicate);

        Rent GetById(Guid id);

        void Modify(Rent rent);
    }
}