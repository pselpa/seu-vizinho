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
            double pricePerDay,
            int rentingPeriodLimit
        );

        Product Get(Func<Product, bool> predicate);

        IEnumerable<Product> GetAll(Func<Product, bool> predicate);

        Product GetById(Guid id);

        void Modify(Product product);

        void Remove(Guid id);
    }
    
}