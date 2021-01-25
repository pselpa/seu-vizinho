using System;

namespace Domain.Authentication
{
    public class AuthResponse
    {
        public Guid UserId { get; set; }
        public bool IsValid { get; set; }

        public AuthResponse(Guid id)
        {
            UserId = id;
            IsValid = true;
        }

        public AuthResponse()
        {
            IsValid = false;
        }
    }
}