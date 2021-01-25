namespace Domain.Authentication
{
    public interface IAuthService
    {
        AuthResponse Login(string email, string password);
    }
}
