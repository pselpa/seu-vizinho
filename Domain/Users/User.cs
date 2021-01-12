using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Domain.People;

namespace Domain.Users
{
    
    public class User : Person
    {
        public UserProfile Profile { get; set; }

        public User(string name, string cpf, string email, UserProfile profile, string password) : base(name, cpf, email, password)
        {
            Id = Guid.NewGuid();
            Profile = profile;
        }

        private bool ValidateEmail()
        {
            return Regex.IsMatch(
                Email,
                @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                RegexOptions.IgnoreCase
            );
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
            return (errors, errors.Count == 0);
        }
    }
}