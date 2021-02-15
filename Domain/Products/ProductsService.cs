using System;
using System.Collections.Generic;

namespace Domain.Products
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public CreatedProductDTO Create(
            string name,
            string description,
            string accessories,
            string brand,
            string model,
            string voltage,
            string frequency,
            double pricePerDay,
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
                pricePerDay,
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

        public Product Get(Func<Product, bool> predicate)
        {
            return _productsRepository.Get(predicate);
        }

        public IEnumerable<Product> GetAll(Func<Product, bool> predicate)
        {
            return _productsRepository.GetAll(predicate);
        }

        public Product GetById(Guid id)
        {
            return _productsRepository.Get(id);
        }

        public void Modify(Product product)
        {
            _productsRepository.Modify(product);
        }

        public void Remove(Guid id)
        {
            var product = new Product(id);
            _productsRepository.Remove(product);
        }
    }
}