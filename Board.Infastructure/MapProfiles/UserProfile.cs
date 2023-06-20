using AutoMapper;
using Board.Contracts.User;
using Board.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Infastructure.MapProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, LoginResultDto>().ReverseMap();
            CreateMap<User, LoginUserDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
