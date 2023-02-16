using AutoMapper;
using KomisijaService.Entities;
using KomisijaService.Models;

namespace KomisijaService.Profiles
{
    /// <summary>
    /// Profil mapera za model entiteta komisija.
    /// </summary>
    public class KomisijaProfile : Profile
    {
        /// <summary>
        /// Profil mapera za model entiteta komisija.
        /// </summary>
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
