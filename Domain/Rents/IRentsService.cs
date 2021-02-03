using Domain.Users;
using Domain.Products;
using System;

namespace Domain.Rents
{
    public interface IRentsService
    {
        CreatedRentDTO Create(
            User customer,
            Guid CustomerId,
            Product rentedProduct,
            DateTime date,
            DateTime contractStarDate,
            DateTime contractEndDate,
            int amountOfHours,
            int amountOfDays,
            double rentalValue,
            string observation
        );

        Rent GetById(Guid id);
    }
}