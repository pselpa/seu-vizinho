using Domain.Users;

namespace WebAPI.Controllers.Users
{
    public class CreateUserRequest
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string ZipCode { get; set; }
        public string HouseNumber { get; set; }
        public string AddressComplement { get; set; }
        public UserProfile Profile { get; set; }
        public string Password { get; set; }
    }
}