using AutoMapper;
using KupacService.Entities;
using KupacService.DTO;

namespace KupacService.Profiles
{
    public class KupacProfile : Profile
    {
        public KupacProfile()
        {
            CreateMap<KupacEntity, KupacDTO>();
            //               .ForMember(
            //                   dest => dest.PrioritetZabrana,
            //                   opt => opt.MapFrom(src => $"{src.ImaZabranu} {src.Prioritet}"));

            CreateMap<KupacCreateDTO, KupacEntity>();
            CreateMap<KupacUpdateDTO, KupacEntity>();
            CreateMap<KupacEntity, KupacEntity>();
        }
    }
}