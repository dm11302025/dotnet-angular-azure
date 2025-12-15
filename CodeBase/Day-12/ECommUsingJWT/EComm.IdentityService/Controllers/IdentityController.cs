using EComm.IdentityService.DTOs;
using EComm.IdentityService.Entities;
using EComm.IdentityService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EComm.IdentityService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration configuration;
        public IdentityController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            this.configuration = configuration;
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
            var response = await _userService.Validate(loginDto);

            return Ok(response);

        }

    }
}
