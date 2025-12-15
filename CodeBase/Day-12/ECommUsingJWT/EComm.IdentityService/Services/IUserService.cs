using EComm.IdentityService.DTOs;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EComm.IdentityService.Services
{
    public interface IUserService
    {
        Task Register(CreateUserDto createUserDto);
        Task<UserResponseDto> Validate(LoginDto loginDto);
    }
}
