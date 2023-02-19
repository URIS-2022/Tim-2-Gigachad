using AutoMapper;
using KorisnikService.Entities;
using KorisnikService.DTO;

namespace KorisnikService.Profiles
{
	/// <summary>
	/// Profil mapera za model entiteta korisnik.
	/// </summary>
	public class KorisnikProfile : Profile
	{
		/// <summary>
		/// Profil mapera za model entiteta korisnik.
		/// </summary>
		public KorisnikProfile()
		{
			CreateMap<KorisnikEntity, KorisnikDTO>()
				.ForMember(
					dest => dest.PunoIme,
					opt => opt.MapFrom(src => $"{src.Ime} {src.Prezime}"));
			CreateMap<KorisnikCreateDTO, KorisnikEntity>();
			CreateMap<KorisnikUpdateDTO, KorisnikEntity>()
				.ForMember(
					dest => dest.ID,
					opt => opt.MapFrom(src => Guid.Parse(src.ID)));
			CreateMap<KorisnikEntity, KorisnikEntity>();
		}
	}
}
