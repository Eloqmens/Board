using AutoMapper;
using Board.Contracts.Roles;
using Board.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Infastructure.MapProfiles
{
    public class RoleMapProfile : Profile
    {
        public RoleMapProfile()
        {
            CreateMap<Role, InfoRoleDto>().ReverseMap();
        }
    }
}
