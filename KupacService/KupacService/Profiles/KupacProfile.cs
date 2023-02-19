using AutoMapper;
using KupacService.Entities;
using KupacService.DTO;

namespace KupacService.Profiles
{
    /// <summary>
    /// Profil mapera za model entiteta kupac.
    /// </summary>
    public class KupacProfile : Profile
    {
        /// <summary>
        /// Profil mapera za model entiteta kupac.
        /// </summary>
        public KupacProfile()
        {
            CreateMap<KupacEntity, KupacDTO>();
            CreateMap<KupacCreateDTO, KupacEntity>();
            CreateMap<KupacUpdateDTO, KupacEntity>()           
                              .ForMember(
                              dest => dest.KupacID,
                              opt => opt.MapFrom(src => Guid.Parse(src.KupacID)));
            CreateMap<KupacEntity, KupacEntity>();
        }
    }
}