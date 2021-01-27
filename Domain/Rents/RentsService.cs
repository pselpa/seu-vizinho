using System.Collections.Generic;

namespace Domain.Rents
{
    public class RentsService : IRentsService
    {
        private readonly IRentsRepository _rentsRepository;
        public RentsService(IRentsRepository rentsRepository)
        {
            _rentsRepository = rentsRepository;
        }

        public CreatedRentDTO Create(
            User customer,
            Product productRented,
            DateTime date,
            DateTime contractStarDate,
            DateTime contractEndDate,
            int amountOfHours,
            int amountOfDays,
            int rentalValue,
            string observation
        )
        {
            var rent = new Rent(
                customer,
                productRented,
                date,
                contractStarDate,
                contractEndDate,
                amountOfHours,
                amountOfDays,
                rentalValue,
                observation
            );
            var RentValidation = rent.Validate();

            if (RentValidation.isValid)
            {
                _rentsRepository.Add(rent);
                return new CreatedRentDTO(rent.Id);
            }

            return new CreatedRentDTO(RentValidation.errors);
        }
    }
}