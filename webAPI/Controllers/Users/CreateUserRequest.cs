using Domain.Users;

namespace WebAPI.Controllers.Users
{
    public class CreateUserRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public UserProfile Profile { get; set; }
        public string Password { get; set; }
    }
}