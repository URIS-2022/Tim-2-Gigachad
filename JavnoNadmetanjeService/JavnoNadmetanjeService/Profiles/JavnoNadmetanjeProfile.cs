using AutoMapper;
using JavnoNadmetanjeService.DTO;
using JavnoNadmetanjeService.Entities;

namespace JavnoNadmetanjeService.Profiles
{
    /// <summary>
	/// Profil mapera za model entiteta javno nadmetanje.
	/// </summary>
    public class JavnoNadmetanjeProfile : Profile
    {
        /// <summary>
		/// Profil mapera za model entiteta javno nadmetanje.
		/// </summary>
		public JavnoNadmetanjeProfile()
        {
            
            CreateMap<JavnoNadmetanjeDTO, JavnoNadmetanjeEntity>();

            CreateMap<JavnoNadmetanjeEntity, JavnoNadmetanjeDTO>();
            CreateMap<JavnoNadmetanjeCreateDTO, JavnoNadmetanjeEntity>()
                .ForMember(
                    dest => dest.LicitacijaID,
                    opt => opt.MapFrom(src => Guid.Parse(src.LicitacijaID)))
                .ForMember(
                    dest => dest.AdresaID,
                    opt => opt.MapFrom(src => Guid.Parse(src.AdresaID)))
                .ForMember(
                    dest => dest.DeoParceleID,
                    opt => opt.MapFrom(src => Guid.Parse(src.DeoParceleID)))
                .ForMember(
                    dest => dest.KupacID,
                    opt => opt.MapFrom(src => Guid.Parse(src.KupacID)));
            CreateMap<JavnoNadmetanjeUpdateDTO, JavnoNadmetanjeEntity>()
                .ForMember(
                    dest => dest.LicitacijaID,
                    opt => opt.MapFrom(src => Guid.Parse(src.LicitacijaID)))
                .ForMember(
                    dest => dest.AdresaID,
                    opt => opt.MapFrom(src => Guid.Parse(src.AdresaID)))
                .ForMember(
                    dest => dest.DeoParceleID,
                    opt => opt.MapFrom(src => Guid.Parse(src.DeoParceleID)))
                .ForMember(
                    dest => dest.KupacID,
                    opt => opt.MapFrom(src => Guid.Parse(src.KupacID)));
            CreateMap<JavnoNadmetanjeEntity, JavnoNadmetanjeEntity>();

            
        }
    }
}
