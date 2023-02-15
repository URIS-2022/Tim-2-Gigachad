using AdresaService.DTO;
using AdresaService.Entities;
using AutoMapper;

namespace AdresaService.Profiles
{
    /// <summary>
	/// Profil mapera za model entiteta adresa.
	/// </summary>
    public class AdresaProfile : Profile
    {
        /// <summary>
		/// Profil mapera za model entiteta adresa.
		/// </summary>
        public AdresaProfile() 
        {
            CreateMap<AdresaEntity, AdresaDTO>()
                .ForMember(
                    dest => dest.UlicaBroj,
                    opt => opt.MapFrom(src => $"{src.Ulica} {src.Broj}"));
            CreateMap<AdresaCreateDTO, AdresaEntity>();
            CreateMap<AdresaUpdateDTO, AdresaEntity>();
            CreateMap<AdresaEntity, AdresaEntity>();
        }
    }
}
