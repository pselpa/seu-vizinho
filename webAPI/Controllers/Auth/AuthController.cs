using Microsoft.AspNetCore.Mvc;
using Domain.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers.Auth
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {   
            var response = _authService.Login(request.Email, request.Password);

            if (!response.IsValid)
            {
                return BadRequest("Email ou senha inválido");
            }
            
            return Ok(response.UserId);
        }
    }
}