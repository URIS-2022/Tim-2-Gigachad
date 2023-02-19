using AutoMapper;
using UgovorOZakupuService.Entities;
using UgovorOZakupuService.DTO;


namespace UgovorOZakupuService.Profiles
{
    public class UgovorOZakupuProfile : Profile
    {
        public UgovorOZakupuProfile()
        {
            CreateMap<UgovorOZakupuEntity, UgovorOZakupuDTO>();
            CreateMap<UgovorOZakupuCreateDTO, UgovorOZakupuEntity>();
            CreateMap<UgovorOZakupuUpdateDTO, UgovorOZakupuEntity>();
            CreateMap<UgovorOZakupuEntity, UgovorOZakupuEntity>();



        }
    }
}
