using AutoMapper;
using DokumentiService.DTO;
using DokumentiService.Entities;

namespace DokumentiService.Profiles
{
    /// <summary>
    /// Profil mapera za model entiteta dokument
    /// </summary>
    public class DokumentProfile : Profile
    {
        /// <summary>
        /// Profil mapera za model entiteta dokument
        /// </summary>
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
