using Microsoft.AspNetCore.Mvc;
using Services;
using JwtDemo.Models;


namespace JwtDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (request.Username == "ansh" && request.Password == "password123")
            {
                var token = _tokenService.GenerateToken(request.Username);
                return Ok(new { token });
            }

            return Unauthorized();
        }
    }
}
