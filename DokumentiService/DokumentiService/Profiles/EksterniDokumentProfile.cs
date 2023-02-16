using AutoMapper;
using DokumentiService.DTO;
using DokumentiService.Entities;

namespace DokumentiService.Profiles
{
    public class EksterniDokumentProfile : Profile
    {
        public EksterniDokumentProfile()
        {
            CreateMap<EksterniDokumentEntity, EksterniDokumentDTO>();
            CreateMap<EksterniDokumentEntity, EksterniDokumentEntity>();
            CreateMap<EksterniDokumentEntity, EksterniDokumentCreateDTO>();
            CreateMap<EksterniDokumentCreateDTO, EksterniDokumentEntity>();
            CreateMap<EksterniDokumentUpdateDTO, EksterniDokumentEntity>();
                //.ForMember(
                 //   dest => dest.IDPutanja,
                  //  opt => opt.MapFrom(src => $"{src.EksterniDokumentID} {src.PutanjaDokumenta}"));
            
        }
    }
}