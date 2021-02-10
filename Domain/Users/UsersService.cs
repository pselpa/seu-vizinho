using System;
using Domain.Common;

namespace Domain.Users
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public CreatedUserDTO Create(
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
        )
        {
            var crypt = new Crypt();
            var cryptPassword = crypt.CreateMD5(password);
            
            var user = new User(name, cpf, email, phone, state, city, district, zipcode, houseNumber, addressComplement, profile, cryptPassword);
            var userValidation = user.Validate();

            if (userValidation.isValid)
            {
                _usersRepository.Add(user);
                return new CreatedUserDTO(user.Id);
            }
            return new CreatedUserDTO(userValidation.errors);
        }

        public User GetById(Guid id)
        {
            return _usersRepository.Get(id);
        }

        public User Remove(Guid id)
        {
            return _usersRepository.Remove(id);
        }
    }
}