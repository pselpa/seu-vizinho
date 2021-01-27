using System.Collections.Generic;

namespace Domain.Rents
{
    public interface IRentsService
    {
        CreateRentDTO Create(
            User customer,
            Product productRented,
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