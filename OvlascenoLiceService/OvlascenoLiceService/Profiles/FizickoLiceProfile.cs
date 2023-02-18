using AutoMapper;
using OvlascenoLiceService.DTO;
using OvlascenoLiceService.Entities;

namespace OvlascenoLiceService.Profiles
{
    /// <summary>
    /// Profil mapera za model entiteta fizičko lice.
    /// </summary>
    public class FizickoLiceProfile : Profile
    {
        /// <summary>
        /// Profil mapera za model entiteta fizičko lice.
        /// </summary>
        public FizickoLiceProfile()
        {
            CreateMap<FizickoLiceEntity, FizickoLiceDTO>()
                .ForMember(
                    dest => dest.PunoIme,
                    opt => opt.MapFrom(src => $"{src.Ime} {src.Prezime}"));
            CreateMap<FizickoLiceCreateDTO, FizickoLiceEntity>();
            CreateMap<FizickoLiceUpdateDTO, FizickoLiceEntity>()
                .ForMember(
                    dest => dest.ID,
                    opt => opt.MapFrom(src => Guid.Parse(src.ID)));
            CreateMap<FizickoLiceEntity, FizickoLiceEntity>();
        }
    }
}