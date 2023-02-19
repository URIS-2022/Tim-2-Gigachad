using AutoMapper;
using UgovorOZakupuService.Entities;
using UgovorOZakupuService.DTO;


namespace UgovorOZakupuService.Profiles
{
    /// <summary>
    /// Profil mapera za ugovor o zakupu
    /// </summary>
    public class UgovorOZakupuProfile : Profile
    {
        /// <summary>
        /// Profil mapera za ugovor o zakupu
        /// </summary>
        public UgovorOZakupuProfile()
        {
            CreateMap<UgovorOZakupuEntity, UgovorOZakupuDTO>();
            CreateMap<UgovorOZakupuCreateDTO, UgovorOZakupuEntity>();
            CreateMap<UgovorOZakupuUpdateDTO, UgovorOZakupuEntity>();
            CreateMap<UgovorOZakupuEntity, UgovorOZakupuEntity>();



        }
    }
}
