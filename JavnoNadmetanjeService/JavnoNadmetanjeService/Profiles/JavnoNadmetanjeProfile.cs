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
            CreateMap<JavnoNadmetanjeEntity, JavnoNadmetanjeDTO>();
            CreateMap<JavnoNadmetanjeDTO, JavnoNadmetanjeEntity>();
            CreateMap<JavnoNadmetanjeUpdateDTO, JavnoNadmetanjeEntity>();
            CreateMap<JavnoNadmetanjeEntity, JavnoNadmetanjeEntity>();
        }
    }
}
