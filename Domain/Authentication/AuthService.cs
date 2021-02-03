using System;
using Domain.Common;
using Domain.Users;

namespace Domain.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly IUsersRepository _usersRepository;

        public AuthService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public AuthResponse Login(string email, string password)
        {
            var user = _usersRepository.Get(x => x.Email == email);
            if (user == null)
            {
                return new AuthResponse();
            }

            var crypt = new Crypt();
            var cryptPassword = crypt.CreateMD5(password);

            return user.Password == cryptPassword
                ? new AuthResponse(user.Id)
                : new AuthResponse();
        }
    }
}