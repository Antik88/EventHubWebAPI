using EventHubWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using EventHubWebApi.Data;
using Microsoft.EntityFrameworkCore;
using EventHubWebApi.Services.UserServices;
using Microsoft.AspNetCore.Authorization;

namespace EventHubWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userServiec)
        {
            _userService = userServiec;
        }

        [HttpGet("all"), Authorize(Roles = "User")]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            return await _userService.GetAllUsers();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetSingleUser(int id)
        {
            var result = await _userService.GetSigneUser(id);

            if (result is null)
                return NotFound("User not found.");

            return Ok(result);
        }

        [HttpPut("upd/{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, User user)
        {
            var result = await _userService.UpdateUser(id, user);
            if (result is null)
                return NotFound("User not found.");
            return Ok(result);
        }

        [HttpDelete("del/{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<User>> DelteUser(int id)
        {
            var rest = await _userService.DeleteUser(id);
            if (rest is null)
                return NotFound("User not found");

            return Ok(rest);
        }

    }
}
