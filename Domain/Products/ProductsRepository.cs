using System;
using Domain.Common;

namespace Domain.Products
{
    public class ProductsRepository: IProductsRepository
    {
        private readonly IRepository<Product> _repository;

        public ProductsRepository(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public void Add(Product product)
        {
            _repository.Add(product);
        }

        public Product Get(Func<Product, bool> predicate)
        {
            return _repository.Get(predicate);
        }

        public Product Get(Guid id)
        {
            return _repository.Get(x => x.Id == id);
        }
    }
}