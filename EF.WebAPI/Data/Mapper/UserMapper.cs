using AutoMapper;
using EF.WebAPI.Data.Dtos.User;
using EF.WebAPI.Models;

namespace EF.WebAPI.Data.Mapper
{
    public class UserMapper: Profile
    {
        public UserMapper()
        {
            CreateMap<GetUserDto, User>();
        }
    }
}
