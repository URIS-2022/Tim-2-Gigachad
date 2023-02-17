using AutoMapper;
using LiceService.Entities;
using LiceService.DTO;

namespace LiceService.Profiles
{
	/// <summary>
	/// Profil mapera za model entiteta lice.
	/// </summary>
	public class LiceProfile : Profile
	{
		/// <summary>
		/// Profil mapera za model entiteta lice.
		/// </summary>
		public LiceProfile()
		{
			CreateMap<LiceEntity, LiceDTO>();
			CreateMap<LiceCreateDTO, LiceEntity>()
				.ForMember(
					dest => dest.FizickoLiceID,
					opt => opt.MapFrom(src => Guid.Parse(src.FizickoLiceID)))
				.ForMember(
					dest => dest.AdresaID,
					opt => opt.MapFrom(src => Guid.Parse(src.AdresaID)));
			CreateMap<LiceUpdateDTO, LiceEntity>()
				.ForMember(
					dest => dest.ID,
					opt => opt.MapFrom(src => Guid.Parse(src.ID)))
				.ForMember(
					dest => dest.FizickoLiceID,
					opt => opt.MapFrom(src => Guid.Parse(src.FizickoLiceID)))
				.ForMember(
					dest => dest.AdresaID,
					opt => opt.MapFrom(src => Guid.Parse(src.AdresaID)));
			CreateMap<LiceEntity, LiceEntity>();
		}
	}
}
