using System;
using Domain.Common;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Products
{
    public class ProductsRepository: IProductsRepository
    {
        private static List<Product> _products = new List<Product>();

        public static IReadOnlyCollection<Product> Products => _products;

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public Product Get(Func<Product, bool> predicate)
        {
            return _products.FirstOrDefault(predicate);
        }

        public Product Get(Guid id)
        {
            return _products.FirstOrDefault(x => x.Id == id);
        }

        public Guid? Remove(Guid id)
        {
            var product = _products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return null;
            }
            _products.Remove(product);
            return id;
        }
    }
}