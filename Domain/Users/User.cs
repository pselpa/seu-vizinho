using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Domain.People;

namespace Domain.Users
{
    
    public class User : Person
    {
        public UserProfile Profile { get; set; }

        public User(
            string name,
            string cpf,
            string email,
            string phone,
            string state,
            string city,
            string district,
            string zipcode,
            string houseNumber,
            string addressComplement,
            UserProfile profile,
            string password
        ) : base(name, cpf, email, phone, state, city, district, zipcode, houseNumber, addressComplement, password)
        {
            Profile = profile;
        }

        // Colocar o VALIDATE no usersService dentro de Create e o BadRequest no webapi
        public (IList<string> errors, bool isValid) Validate()
        {
            var errors = new List<string>();
            if (!ValidateCPF())
            {
                errors.Add("CPF inválido.");
            }
            if (!ValidateName())
            {
                errors.Add("Nome inválido.");
            }
            if (!ValidateEmail())
            {
                errors.Add("E-mail inválido.");
            }
            return (errors, errors.Count == 0);
        }
    }
}