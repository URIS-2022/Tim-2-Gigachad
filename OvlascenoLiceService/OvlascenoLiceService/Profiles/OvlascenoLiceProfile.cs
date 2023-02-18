using AutoMapper;
using OvlascenoLiceService.DTO;
using OvlascenoLiceService.Entities;

namespace OvlascenoLiceService.Profiles
{
    /// <summary>
    /// Profil mapera za model entiteta ovlasceno lice.
    /// </summary>
    public class OvlascenoLiceProfile : Profile
    {
        /// <summary>
        /// Profil mapera za model entiteta ovlasceno lice.
        /// </summary>
        public OvlascenoLiceProfile()
        {
            CreateMap<OvlascenoLiceEntity, OvlascenoLiceDTO>();
            CreateMap<OvlascenoLiceCreateDTO, OvlascenoLiceEntity>()
                .ForMember(
                    dest => dest.FizickoLiceID,
                    opt => opt.MapFrom(src => Guid.Parse(src.FizickoLiceID)))
                .ForMember(
                    dest => dest.AdresaID,
                    opt => opt.MapFrom(src => Guid.Parse(src.AdresaID)));
            CreateMap<OvlascenoLiceUpdateDTO, OvlascenoLiceEntity>()
                .ForMember(
                    dest => dest.ID,
                    opt => opt.MapFrom(src => Guid.Parse(src.ID)))
                .ForMember(
                    dest => dest.FizickoLiceID,
                    opt => opt.MapFrom(src => Guid.Parse(src.FizickoLiceID)))
                .ForMember(
                    dest => dest.AdresaID,
                    opt => opt.MapFrom(src => Guid.Parse(src.AdresaID)));
            CreateMap<OvlascenoLiceEntity, OvlascenoLiceEntity>();
        }
    }
}

