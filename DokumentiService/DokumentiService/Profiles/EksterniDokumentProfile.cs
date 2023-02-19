using AutoMapper;
using DokumentiService.DTO;
using DokumentiService.Entities;

namespace DokumentiService.Profiles
{
    /// <summary>
    /// Profil mapera za model entiteta eksterni dokument
    /// </summary>
    public class EksterniDokumentProfile : Profile
    {
        /// <summary>
        /// Profil mapera za model eksterni entiteta dokument
        /// </summary>
        public EksterniDokumentProfile()
        {
            CreateMap<EksterniDokumentEntity, EksterniDokumentDTO>();
            CreateMap<EksterniDokumentEntity, EksterniDokumentEntity>();
            CreateMap<EksterniDokumentEntity, EksterniDokumentCreateDTO>();
            CreateMap<EksterniDokumentCreateDTO, EksterniDokumentEntity>();
            CreateMap<EksterniDokumentUpdateDTO, EksterniDokumentEntity>();
                
            
        }
    }
}