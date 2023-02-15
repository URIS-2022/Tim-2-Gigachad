using AutoMapper;
using DokumentiService.DTO;
using DokumentiService.Entities;

namespace DokumentiService.Profiles
{
    public class DokumentProfile : Profile
    {
        public DokumentProfile()
        {
        CreateMap<DokumentEntity, DokumentDTO>()
                .ForMember(
                    dest => dest.SablonStatus,
                    opt => opt.MapFrom(src => $"{src.Sablon} {src.StatusDokumenta}"));
        }
    }

}
