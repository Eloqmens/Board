using AutoMapper;
using Board.Contracts.Message;
using Board.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board.Infastructure.MapProfiles
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<CreateMessageDto, Message>(MemberList.None)
                .ForMember(d => d.SenderId, map => map.MapFrom(s => s.RecieverId))
                .ForMember(d => d.RecieverId, map => map.MapFrom(s => s.RecieverId))
                .ForMember(d => d.Containment, map => map.MapFrom(s => s.Containment)).ReverseMap();

            CreateMap<Message, MessageInfoDto>()
                .ForMember(d => d.SenderId, map => map.MapFrom(s => s.SenderId))
                .ForMember(d => d.RecieverId, map => map.MapFrom(s => s.RecieverId))
                .ForMember(d => d.Containment, map => map.MapFrom(s => s.Containment)).ReverseMap();

            CreateMap<Message, MessageShortInfoDto>()
                .ForMember(d => d.SenderId, map => map.MapFrom(s => s.SenderId))
                .ForMember(d => d.RecieverId, map => map.MapFrom(s => s.RecieverId))
                .ForMember(d => d.Containment, map => map.MapFrom(s => s.Containment)).ReverseMap();
        }
    }
}
