using AutoMapper;
using KomisijaService.Entities;
using KomisijaService.Models;

namespace KomisijaService.Profiles
{
    public class KomisijaProfile : Profile
    {
        public KomisijaProfile()
        {
            CreateMap<KomisijaEntity, KomisijaDTO>();
            CreateMap<KomisijaCreateDTO, KomisijaEntity>();
            CreateMap<KomisijaUpdateDTO, KomisijaEntity>();
            CreateMap<KomisijaDTO, KomisijaEntity>();
            CreateMap<KomisijaEntity, KomisijaEntity>();
        }
    }
}
