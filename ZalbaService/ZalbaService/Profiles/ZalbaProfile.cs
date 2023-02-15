using AutoMapper;
using ZalbaService.Entities;
using ZalbaService.Models;

namespace ZalbaService.Profiles
{
    public class ZalbaProfile : Profile
    {
        public ZalbaProfile()
        {
            CreateMap<ZalbaEntity, ZalbaDTO>()
                .ForMember(
                    dest => dest.Objasnjenje,
                    opt => opt.MapFrom(src => $"{src.Razlog} - {src.Obrazlozenje}"));

            CreateMap<ZalbaCreateDTO, ZalbaEntity>();
            CreateMap<ZalbaUpdateDTO, ZalbaEntity>();
            CreateMap<ZalbaDTO, ZalbaEntity>();
        }
    }
}
