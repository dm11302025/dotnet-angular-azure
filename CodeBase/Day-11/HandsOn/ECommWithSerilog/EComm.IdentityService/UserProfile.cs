using AutoMapper;
using EComm.IdentityService.DTOs;
using EComm.IdentityService.Entities;
namespace EComm.IdentityService
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            //Define mapping configurations here
            //Example: CreateMap<Source, Destination>();
            CreateMap<CreateUserDto, User>();
            CreateMap<User, ReadUserDto>();
            CreateMap<UpdateUserDto, User>();
        }
    }
}
