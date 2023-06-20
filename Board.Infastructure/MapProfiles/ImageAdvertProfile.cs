using AutoMapper;
using Board.Contracts.ImageAdvert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Infastructure.MapProfiles
{
    public class ImageAdvertProfile : Profile
    {
        public ImageAdvertProfile()
        {
            CreateMap<ImageAdvertDto, Domain.ImageAdvert>(MemberList.None)
                .ForMember(d => d.Length, map => map.MapFrom(s => s.Content.Length))
                .ForMember(d => d.AdvertId, map => map.MapFrom(s => s.AdvertId))
                .ForMember(d => d.Created, map => map.MapFrom(s => DateTime.UtcNow)).ReverseMap();

            CreateMap<Domain.ImageAdvert, ImageAdvertDto>(MemberList.None);

            CreateMap<Domain.ImageAdvert, ImageAdvertInfoDto>(MemberList.None);
        }
    }
}
