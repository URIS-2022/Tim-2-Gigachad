using LiceService.Models;

namespace LiceService.Helpers
{
	public interface IAutentifikacijaHelper
	{
		public bool AuthenticateKorisnik(KorisnikDTO korisnikDTO);

		public string GenerateJWT(KorisnikDTO korisnikDTO);
	}
}
