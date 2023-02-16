using AutoMapper;
using DokumentiService.DTO;
using DokumentiService.Entities;

namespace DokumentiService.Profiles
{
    public class InterniDokumentProfile : Profile
    {
        public InterniDokumentProfile()
        {
            CreateMap<InterniDokumentEntity, InterniDokumentDTO>();
            //CreateMap<InterniDokumentEntity, InterniDokumentCreateDTO>();
            CreateMap<InterniDokumentCreateDTO, InterniDokumentEntity>();
            CreateMap<InterniDokumentUpdateDTO, InterniDokumentEntity>();
            CreateMap<InterniDokumentEntity, InterniDokumentEntity>();
        }
    }

}
