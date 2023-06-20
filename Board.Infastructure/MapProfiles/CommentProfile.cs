using AutoMapper;
using Board.Contracts.Comment;
using Board.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Infastructure.MapProfiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<CreateCommentDto, Comment>(MemberList.None)
                .ForMember(d => d.SenderId, map => map.MapFrom(s => s.SenderId))
                .ForMember(d => d.UserId, map => map.MapFrom(s => s.UserId))
                .ForMember(d => d.Text, map => map.MapFrom(s => s.Text)).ReverseMap();

            CreateMap<Comment, CommentInfoDto>()
                .ForMember(d => d.SenderId, map => map.MapFrom(s => s.SenderId))
                .ForMember(d => d.UserId, map => map.MapFrom(s => s.UserId))
                .ForMember(d => d.Text, map => map.MapFrom(s => s.Text)).ReverseMap();

            CreateMap<Comment, CommentShortInfo>()
                .ForMember(d => d.SenderId, map => map.MapFrom(s => s.SenderId))
                .ForMember(d => d.UserId, map => map.MapFrom(s => s.UserId))
                .ForMember(d => d.Text, map => map.MapFrom(s => s.Text)).ReverseMap();
        }
    }
}
