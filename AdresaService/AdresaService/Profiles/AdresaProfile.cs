using AdresaService.DTO;
using AdresaService.Entities;
using AutoMapper;

namespace AdresaService.Profiles
{
    public class AdresaProfile : Profile
    {
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
