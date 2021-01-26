using System;
using System.Collections.Generic;

namespace Domain.Products
{
    public class CreateProductDTO
    {
        public Guid Id { get; private set; }
        public IList<string> Errors { get; set; }
        public bool IsValid { get; set; }
    
        public CreateProductDTO(Guid id)
        {
            Id = id;
            IsValid = true;
        }

        public CreatedProductDTO(IList<string> errors)
        {
            Errors = errors;
            IsValid = false;
        }
    }
}