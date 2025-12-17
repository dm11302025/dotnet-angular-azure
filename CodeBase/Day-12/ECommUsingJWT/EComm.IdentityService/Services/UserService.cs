using AutoMapper;
using EComm.IdentityService.DTOs;
using EComm.IdentityService.Entities;
using EComm.IdentityService.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace EComm.IdentityService.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration configuration;
        //initialize the repository through constructor injection(DI)
        public UserService(IUserRepository userRepository, IMapper mapper,IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            this.configuration = configuration;
        }
        public async Task Register(CreateUserDto createUserDto)
        {
            //convert CreateUserDto to User entity using AutoMapper
            var user = _mapper.Map<User>(createUserDto);
            user.CreatedAt = DateTime.UtcNow;
            user.Role= "User"; //default role
            //generate a simple UserId
            var firstChar= user.UserName.ToUpper()[0].ToString();
            user.UserId = firstChar+new Random().Next(1000,9999);
            await _userRepository.Register(user);
        }
        public async Task<UserResponseDto> Validate(LoginDto loginDto)
        {
            var user =  await _userRepository.Validate(loginDto.Email, loginDto.Password);
            if (user == null)
            {
                return new UserResponseDto
                {
                    UserId = "",
                    Token = "",
                    Role = ""
                };
            }
            else
            {
                //generate a simple token for demonstration purposes
                //var token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
                return new UserResponseDto
                {
                    UserId = user.UserId,
                    Token = GetToken(user),
                    Role = user.Role
                };
            }
               

        }
        private string GetToken(User? user)
        {
            //Define claims
            var claims = new[]
            {
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(ClaimTypes.Role, user.Role)
    };

            //Define key

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            //Define the signature
            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
