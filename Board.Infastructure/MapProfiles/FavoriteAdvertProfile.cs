using AutoMapper;
using Board.Contracts.FavoriteAdvert;
using Board.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Infastructure.MapProfiles
{
    public class FavoriteAdvertProfile : Profile
    {
        public FavoriteAdvertProfile()
        {
            CreateMap<CreateFavoriteAdvertDto, FavoriteAdvert>(MemberList.None)
                .ForMember(d => d.AdvertId, map => map.MapFrom(s => s.AdvertId))
                .ForMember(d => d.UserId, map => map.MapFrom(s => s.UserId)).ReverseMap();

            CreateMap<FavoriteAdvert, FavoriteAdvertInfoDto>()
                .ForMember(d => d.AdvertId, map => map.MapFrom(s => s.AdvertId))
                .ForMember(d => d.UserId, map => map.MapFrom(s => s.UserId)).ReverseMap();

            CreateMap<FavoriteAdvert, FavoriteAdvertShortInfoDto>()
                .ForMember(d => d.AdvertId, map => map.MapFrom(s => s.AdvertId))
                .ForMember(d => d.UserId, map => map.MapFrom(s => s.UserId)).ReverseMap();
        }
    }
}
