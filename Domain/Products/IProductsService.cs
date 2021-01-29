using System;
using System.Collections.Generic;

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


        public Guid? Remove(Guid id);
    }
    
}