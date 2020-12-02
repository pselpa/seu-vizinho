using System.Collections.Generic;
using Domain.People;

namespace Domain.Users
{
    
    public class User : Person
    {
        public UserProfile Profile { get; set; }
        public string Password { get; protected set; }

        public User(string name, string cpf, UserProfile profile) : base(name)
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
            return (errors, errors.Count == 0);
        }
    }
}