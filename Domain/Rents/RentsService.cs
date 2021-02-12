using System;
using System.Collections.Generic;
using Domain.Products;
using Domain.Users;

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
            Guid customerId,
            Product rentedProduct,
            DateTime date,
            DateTime contractStartDate,
            DateTime contractEndDate,
            int amountOfHours,
            int amountOfDays,
            double rentalValue,
            string observation
        )
        {
            var rent = new Rent(
                customer,
                customerId,
                rentedProduct,
                date,
                contractStartDate,
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

        public Rent GetById(Guid id)
        {
            return _rentsRepository.Get(id);
        }
    }
}