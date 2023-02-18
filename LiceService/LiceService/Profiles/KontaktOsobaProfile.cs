using AutoMapper;
using LiceService.Entities;
using LiceService.DTO;

namespace LiceService.Profiles
{
	/// <summary>
	/// Profil mapera za model entiteta kontakt osoba.
	/// </summary>
	public class KontaktOsobaProfile : Profile
	{
		/// <summary>
		/// Profil mapera za model entiteta kontakt osoba.
		/// </summary>
		public KontaktOsobaProfile()
		{
			CreateMap<KontaktOsobaEntity, KontaktOsobaDTO>()
				.ForMember(
					dest => dest.PunoIme,
					opt => opt.MapFrom(src => $"{src.Ime} {src.Prezime}"));
			CreateMap<KontaktOsobaCreateDTO, KontaktOsobaEntity>();
			CreateMap<KontaktOsobaUpdateDTO, KontaktOsobaEntity>()
				.ForMember(
					dest => dest.ID,
					opt => opt.MapFrom(src => Guid.Parse(src.ID)));
			CreateMap<KontaktOsobaEntity, KontaktOsobaEntity>();
		}
	}
}
