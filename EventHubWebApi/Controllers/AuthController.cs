using EventHubWebApi.Services.AuthService;
using EventHubWebApi.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EventHubWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet("getName"), Authorize]
        public ActionResult<string> GetName()
        {
            return Ok(_authService.GetName());
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(User user)
        {
            var result = await _authService.Register(user);

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(UserDTO userDTO)
        {
            var token = await _authService.Login(userDTO);

            return Ok(token);
        }
    }
}
