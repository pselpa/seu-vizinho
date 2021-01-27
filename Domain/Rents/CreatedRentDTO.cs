using System;
using System.Collections.Generic;

namespace Domain.Rents
{
    public class CreatedRentDTO
    {
        public Guid Id { get; private set; }
        public IList<string> Errors { get; set; }
        public bool IsValid { get; set; }
    
        public CreatedRentDTO(Guid id)
        {
            Id = id;
            IsValid = true;
        }

        public CreatedRentDTO(IList<string> errors)
        {
            Errors = errors;
            IsValid = false;
        }
    }
}