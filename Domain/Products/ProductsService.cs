using System;
using System.Collections.Generic;

namespace Domain.Products
{
    public class ProductsService
    {
        private readonly ProductsRepository _productsRepository;

        public CreatedProductDTO Create(
            string name,
            string description,
            string accessories,
            string brand,
            string model,
            string voltage,
            string frequency,
            double pricePerHour,
            double pricePerDay,
            double pricePerDayByWeek,
            double pricePerDayByWeekly,
            double pricePerDayByMonth,
            int rentingPeriodLimit
        )
        {
            var product = new Product(
                name,
                description,
                accessories,
                brand,
                model,
                voltage,
                frequency,
                pricePerHour,
                pricePerDay,
                pricePerDayByWeek,
                pricePerDayByWeekly,
                pricePerDayByMonth,
                rentingPeriodLimit
            );
            var ProductValidation = product.Validate();

            if (ProductValidation.isValid)
            {
                _productsRepository.Add(product);
                return new CreatedProductDTO(product.Id);
            }
            return new CreatedProductDTO(ProductValidation.errors);
        }

        public Guid? Remove(Guid id)
        {
            return _productsRepository.Remove(id);
        }
    }
}