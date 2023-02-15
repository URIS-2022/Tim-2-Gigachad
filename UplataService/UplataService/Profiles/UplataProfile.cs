using AutoMapper;
using UplataService.Entities;
using UplataService.Models;

namespace UplataService.Profiles
{
    public class UplataProfile : Profile
    {
        public UplataProfile()
        {
            CreateMap<UplataEntity, UplataDTO>();
                //.ForMember(
                 //       dest => dest.PunoIme,
                  //      opt => opt.MapFrom(src => $"{src.BrojRacuna} {src.PozivNaBroj}"));
            CreateMap<UplataCreateDTO, UplataEntity>();
            CreateMap<UplataUpdateDTO, UplataEntity>();
            CreateMap<UplataEntity, UplataEntity>();
        }
    }
}
