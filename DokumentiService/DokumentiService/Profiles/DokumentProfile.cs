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
            CreateMap<DokumentCreateDTO, DokumentEntity>()
            .ForMember(
                    dest => dest.EksterniDokumentID,
                    opt => opt.MapFrom(src => Guid.Parse(src.EksterniDokumentID)))
            .ForMember(
                    dest => dest.InterniDokumentID,
                    opt => opt.MapFrom(src => Guid.Parse(src.InterniDokumentID)));
            CreateMap<DokumentUpdateDTO, DokumentEntity>();
            CreateMap<DokumentEntity, DokumentEntity>();
            CreateMap<DokumentDTO, DokumentEntity>();



        }
    }

}
