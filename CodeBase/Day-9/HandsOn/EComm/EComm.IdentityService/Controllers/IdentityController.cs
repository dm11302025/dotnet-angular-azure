using EComm.IdentityService.DTOs;
using EComm.IdentityService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EComm.IdentityService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IUserService _userService;
        public IdentityController(IUserService userService)
        {
            _userService = userService;
        }
        //define endpoints for user registration and validation
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserDto createUserDto)
        {
            await _userService.Register(createUserDto);
            return Ok("User registered successfully");
        }
        [HttpPost("validate")]
        public async Task<IActionResult> Validate([FromBody] LoginDto loginDto)
        {
            var user = await _userService.Validate(loginDto);
            if (user == null)
            {
                return Unauthorized("Invalid email or password");
            }
            return Ok(user);
        }
    }
}
