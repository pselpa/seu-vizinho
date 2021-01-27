using Domain.Users;
using Domain.Products;
using System;

namespace Domain.Rents
{
    public interface IRentsService
    {
        CreatedRentDTO Create(
            User customer,
            Product rentedProduct,
            DateTime date,
            DateTime contractStarDate,
            DateTime contractEndDate,
            int amountOfHours,
            int amountOfDays,
            int rentalValue,
            string observation
        );
    }
}