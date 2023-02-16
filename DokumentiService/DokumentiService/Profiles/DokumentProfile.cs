using AutoMapper;
using DokumentiService.DTO;
using DokumentiService.Entities;

namespace DokumentiService.Profiles
{
    public class DokumentProfile : Profile
    {
        public DokumentProfile()
        {
            CreateMap<DokumentEntity, DokumentDTO>();
            CreateMap<DokumentCreateDTO, DokumentEntity>();
            CreateMap<DokumentUpdateDTO, DokumentEntity>();
            CreateMap<DokumentEntity, DokumentEntity>();
            


        }
    }

}
