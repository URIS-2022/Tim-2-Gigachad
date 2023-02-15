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
            CreateMap<KupacUpdateDTO, KupacEntity>()           
                              .ForMember(
                              dest => dest.KupacID,
                              opt => opt.MapFrom(src => Guid.Parse(src.KupacID)));
            CreateMap<KupacEntity, KupacEntity>();
        }
    }
}