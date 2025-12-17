using HandsOnAPIUsingJWT.Entities;
using HandsOnAPIUsingJWT.Models;
using HandsOnAPIUsingJWT.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HandsOnAPIUsingJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IConfiguration configuration;
        public UserController(IUserRepository userRepository, IConfiguration configuration)
        {
            this.userRepository = userRepository;
            this.configuration = configuration;
        }
        // End Points
        [HttpPost("Register")]
        [AllowAnonymous] // Allow anonymous access to this endpoint
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User cannot be null");
            }
            await userRepository.Register(user);
            return Ok(user);
        }
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            if (login == null || string.IsNullOrEmpty(login.Email) || string.IsNullOrEmpty(login.Password))
            {
                return BadRequest("Email and Password are required");
            }
            var validatedUser = await userRepository.Validate(login.Email, login.Password);
            if (validatedUser == null)
            {
                return Unauthorized();
            }
            else
            {
                // Here you can generate a JWT token and return it in the response
                var response = new UserResponseDTO()
                {
                    UserId = validatedUser.UserId,
                    Role = validatedUser.Role,
                    Token = GetToken(validatedUser) // Replace with actual JWT token generation logic
                };
                return Ok(response);
            }

        }
        private string GetToken(User? user)
        {
            //Define claims
            var claims = new[]
            {
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(ClaimTypes.Role, user.Role),
        new Claim(ClaimTypes.Email, user.Email)
    };

            //Define key
            
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            //Define the signature
            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"], 
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
