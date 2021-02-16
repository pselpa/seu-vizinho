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
            Guid customerId,
            Guid rentedProductId,
            DateTime date,
            DateTime contractStartDate,
            DateTime contractEndDate,
            string observation
        )
        {
            var rent = new Rent(
                customerId,
                rentedProductId,
                date,
                contractStartDate,
                contractEndDate,
                CalculateRent(rentedProductId, contractStartDate, contractEndDate),
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

        public double GetAmountOfDays(DateTime ContractStartDate, DateTime ContractEndDate)
        {
            TimeSpan amountOfDays = ContractEndDate - ContractStartDate;
            return amountOfDays.Days;
        }

        public double CalculateRent(Guid productId, DateTime ContractStartDate, DateTime ContractEndDate)
        {
            var product = new Product(productId);

            var amountOfDays = GetAmountOfDays(ContractEndDate, ContractStartDate);
            var result = product.PricePerDay * amountOfDays;
            return result;            
        }

        public IEnumerable<Rent> GetAll(Func<Rent, bool> predicate)
        {
            return _rentsRepository.GetAll(predicate);
        }

        public Rent GetById(Guid id)
        {
            return _rentsRepository.Get(id);
        }

        public void Modify(Rent rent)
        {
            _rentsRepository.Modify(rent);
        }
    }
}