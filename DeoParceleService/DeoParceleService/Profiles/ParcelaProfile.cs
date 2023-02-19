using AutoMapper;
using DeoParceleService.Entities;
using DeoParceleService.DTO;

namespace DeoParceleService.Profiles
{
	/// <summary>
	/// Profil mapera za model entiteta parcela.
	/// </summary>
	public class ParcelaProfile : Profile
	{
		/// <summary>
		/// Profil mapera za model entiteta parcela.
		/// </summary>
		public ParcelaProfile()
		{
			CreateMap<ParcelaEntity, ParcelaDTO>();
			CreateMap<ParcelaCreateDTO, ParcelaEntity>();
			CreateMap<ParcelaUpdateDTO, ParcelaEntity>()
				.ForMember(
					dest => dest.ID,
					opt => opt.MapFrom(src => Guid.Parse(src.ID)));
			CreateMap<ParcelaEntity, ParcelaEntity>();
		}
	}
}
