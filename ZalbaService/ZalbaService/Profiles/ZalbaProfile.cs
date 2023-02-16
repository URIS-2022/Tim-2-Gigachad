using AutoMapper;
using ZalbaService.Entities;
using ZalbaService.Models;

namespace ZalbaService.Profiles
{
    /// <summary>
    /// Profil mapera za model entiteta žalba.
    /// </summary>
    public class ZalbaProfile : Profile
    {
        /// <summary>
        /// Profil mapera za model entiteta žalba.
        /// </summary>
        public ZalbaProfile()
        {
            CreateMap<ZalbaEntity, ZalbaDTO>()
                .ForMember(
                    dest => dest.Objasnjenje,
                    opt => opt.MapFrom(src => $"{src.Razlog} - {src.Obrazlozenje}"));

            CreateMap<ZalbaCreateDTO, ZalbaEntity>();
            CreateMap<ZalbaUpdateDTO, ZalbaEntity>();
            CreateMap<ZalbaDTO, ZalbaEntity>();
            CreateMap<ZalbaEntity, ZalbaEntity>();
        }
    }
}
