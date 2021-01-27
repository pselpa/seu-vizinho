using System.Collections.Generic;

namespace Domain.Products
{
    public interface IProductService
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
    }
}