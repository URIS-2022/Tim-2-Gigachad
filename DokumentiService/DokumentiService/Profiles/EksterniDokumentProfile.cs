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
            CreateMap<EksterniDokumentEntity, EksterniDokumentCreateDTO>();
            CreateMap<EksterniDokumentCreateDTO, EksterniDokumentEntity>();
                //.ForMember(
                 //   dest => dest.IDPutanja,
                  //  opt => opt.MapFrom(src => $"{src.EksterniDokumentID} {src.PutanjaDokumenta}"));
            
        }
    }
}