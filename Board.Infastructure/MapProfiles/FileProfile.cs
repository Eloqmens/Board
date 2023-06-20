using AutoMapper;
using Board.Contracts.File;

namespace Board.Infastructure.MapProfiles
{
    /// <summary>
    /// Профиль для работы с файловами.
    /// </summary>
    public class FileProfile : Profile
    {
        public FileProfile()
        {
            CreateMap<FileDto, Domain.File>(MemberList.None)
                .ForMember(d => d.Length, map => map.MapFrom(s => s.Content.Length))
                .ForMember(d => d.Created, map => map.MapFrom(s => DateTime.UtcNow));

            CreateMap<Domain.File, FileDto>(MemberList.None);

            CreateMap<Domain.File, FileInfoDto>(MemberList.None);
        }
    }
}
