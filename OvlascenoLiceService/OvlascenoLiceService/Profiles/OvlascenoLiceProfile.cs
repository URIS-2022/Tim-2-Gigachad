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
            CreateMap<OvlascenoLiceEntity, OvlascenoLiceDTO>()
                .ForMember(
                    dest => dest.FizickoLice,
                    opt => opt.MapFrom(src => src.FizickoLiceID))
                .ForMember(
                    dest => dest.Adresa,
                    opt => opt.MapFrom(src => src.AdresaID));
            CreateMap<OvlascenoLiceEntity, OvlascenoLiceDTO>()
                .ForMember(
                    dest => dest.ID,
                    opt => opt.MapFrom(src => src.ID))
                .ForMember(
                    dest => dest.FizickoLice,
                    opt => opt.MapFrom(src => src.FizickoLiceID))
                .ForMember(
                    dest => dest.Adresa,
                    opt => opt.MapFrom(src => src.AdresaID));
            CreateMap<OvlascenoLiceEntity, OvlascenoLiceDTO>();
        }
    }
}

