using Business.Abstract;
using Business.Requests.Auth;
using Business.Responses.Auths;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        IAuthService _authService;

        public AuthsController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public AccessResponse Register([FromBody] RegisterUserRequest request)
        {
            AccessResponse  result = _authService.Register(request);
            return result;
        }

        [HttpPost("login")]
        public AccessResponse Login([FromBody] LoginUserRequest request)
        {
            AccessResponse result = _authService.Login(request);
            return result;
        }
    }
}
