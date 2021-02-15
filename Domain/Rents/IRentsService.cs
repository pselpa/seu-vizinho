using Domain.Users;
using Domain.Products;
using System;
using System.Collections.Generic;

namespace Domain.Rents
{
    public interface IRentsService
    {
        CreatedRentDTO Create(
            User customer,
            Guid customerId,
            Product rentedProduct,
            Guid rentedProductId,
            DateTime date,
            DateTime contractStartDate,
            DateTime contractEndDate,
            TimeSpan amountOfDays,
            double rentalValue,
            string observation
        );

        IEnumerable<Rent> GetAll(Func<Rent, bool> predicate);

        Rent GetById(Guid id);

        void Modify(Rent rent);
    }
}