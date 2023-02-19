using AutoMapper;
using DeoParceleService.Entities;
using DeoParceleService.DTO;

namespace DeoParceleService.Profiles
{
	/// <summary>
	/// Profil mapera za model entiteta deo parcele.
	/// </summary>
	public class DeoParceleProfile : Profile
	{
		/// <summary>
		/// Profil mapera za model entiteta deo parcele.
		/// </summary>
		public DeoParceleProfile()
		{
			CreateMap<DeoParceleEntity, DeoParceleDTO>();
			CreateMap<DeoParceleCreateDTO, DeoParceleEntity>();
			CreateMap<DeoParceleUpdateDTO, DeoParceleEntity>()
				.ForMember(
					dest => dest.ID,
					opt => opt.MapFrom(src => Guid.Parse(src.ID)));
			CreateMap<DeoParceleEntity, DeoParceleEntity>();
		}
	}
}
