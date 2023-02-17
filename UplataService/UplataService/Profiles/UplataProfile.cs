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
            //    .ForMember(
            //        dest => dest.KupacID,
            //       opt => opt.MapFrom(src => Guid.Parse(src.KupacID)));
            CreateMap<UplataUpdateDTO, UplataEntity>();
            CreateMap<UplataEntity, UplataEntity>();
        }
    }
}
