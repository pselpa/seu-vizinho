using System;

namespace Domain.Users
{
    public interface IUsersService
    {
        CreatedUserDTO Create(
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
        );

        User GetById(Guid id);

        User Remove(Guid id);
    }
}