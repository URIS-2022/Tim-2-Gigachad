using AutoMapper;
using LiceService.Entities;
using LiceService.DTO;

namespace LiceService.Profiles
{
	/// <summary>
	/// Profil mapera za model entiteta pravno lice.
	/// </summary>
	public class PravnoLiceProfile : Profile
	{
		/// <summary>
		/// Profil mapera za model entiteta pravno lice.
		/// </summary>
		public PravnoLiceProfile()
		{
			CreateMap<PravnoLiceEntity, PravnoLiceDTO>();
			CreateMap<PravnoLiceCreateDTO, PravnoLiceEntity>();
			CreateMap<PravnoLiceUpdateDTO, PravnoLiceEntity>()
				.ForMember(
					dest => dest.ID,
					opt => opt.MapFrom(src => Guid.Parse(src.ID)));
			CreateMap<PravnoLiceEntity, PravnoLiceEntity>();
		}
	}
}
