using AutoMapper;
using EComm.IdentityService.DTOs;
using EComm.IdentityService.Repositories;
using EComm.IdentityService.Entities;
namespace EComm.IdentityService.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        //initialize the repository through constructor injection(DI)
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
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
        public async Task<ReadUserDto> Validate(LoginDto loginDto)
        {
            var user =  await _userRepository.Validate(loginDto.Email, loginDto.Password);
            //convert User entity to ReadUserDto using AutoMapper
            return _mapper.Map<ReadUserDto>(user);

        }
    }
}
