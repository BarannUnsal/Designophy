using Designophy.Infrastructure.Users;
using Designophy.WebModels.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Designophy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var res = await _userService.CreateUserAsync(request);
            if (!res.Succeeded) return BadRequest(res.Errors);

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest req)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var token = await _userService.LoginAsync(req);
            if (token == null) return Unauthorized();

            return Ok(new { token });
        }
    }
}
