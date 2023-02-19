using AutoMapper;
using DokumentiService.DTO;
using DokumentiService.Entities;

namespace DokumentiService.Profiles
{
    /// <summary>
    /// Profil mapera za model entiteta interni dokument
    /// </summary>
    public class InterniDokumentProfile : Profile
    {
        /// <summary>
        /// Profil mapera za model entiteta interni dokument
        /// </summary>
        public InterniDokumentProfile()
        {
            CreateMap<InterniDokumentEntity, InterniDokumentDTO>();
            CreateMap<InterniDokumentCreateDTO, InterniDokumentEntity>();
            CreateMap<InterniDokumentUpdateDTO, InterniDokumentEntity>();
            CreateMap<InterniDokumentEntity, InterniDokumentEntity>();
            CreateMap<InterniDokumentEntity, InterniDokumentCreateDTO>();
        }
    }

}
