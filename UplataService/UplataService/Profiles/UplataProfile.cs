using AutoMapper;
using UplataService.Entities;
using UplataService.Models;

namespace UplataService.Profiles
{
    /// <summary>
	/// Profil mapera za model entiteta uplata.
	/// </summary>
    public class UplataProfile : Profile
    {
        /// <summary>
		/// Profil mapera za model entiteta uplata.
		/// </summary>
        public UplataProfile()
        {
            CreateMap<UplataEntity, UplataDTO>();
            CreateMap<UplataCreateDTO, UplataEntity>();
            CreateMap<UplataUpdateDTO, UplataEntity>();
            CreateMap<UplataEntity, UplataEntity>();
        }
    }
}
