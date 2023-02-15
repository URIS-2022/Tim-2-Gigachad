using AutoMapper;
using KorisnikService.Entities;
using KorisnikService.DTO;

namespace KorisnikService.Profiles
{
	/// <summary>
	/// Profil mapera za model entiteta korisnika.
	/// </summary>
	public class KorisnikProfile : Profile
	{
		/// <summary>
		/// Profil mapera za model entiteta korisnika.
		/// </summary>
		public KorisnikProfile()
		{
			CreateMap<KorisnikEntity, KorisnikDTO>()
				.ForMember(
					dest => dest.PunoIme,
					opt => opt.MapFrom(src => $"{src.Ime} {src.Prezime}"));
			CreateMap<KorisnikCreateDTO, KorisnikEntity>();
			CreateMap<KorisnikUpdateDTO, KorisnikEntity>();
			CreateMap<KorisnikEntity, KorisnikEntity>();
		}
	}
}
