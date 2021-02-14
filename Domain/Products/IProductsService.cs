using System;

namespace Domain.Products
{
    public interface IProductsService
    {
        CreatedProductDTO Create(
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
        );

        Product Get(Func<Product, bool> predicate);

        Product GetById(Guid id);

        void Remove(Guid id);
    }
    
}