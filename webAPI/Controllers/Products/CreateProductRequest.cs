using System;

namespace WebAPI.Controllers.Products
{
    public class CreateProductRequest
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
    }

}