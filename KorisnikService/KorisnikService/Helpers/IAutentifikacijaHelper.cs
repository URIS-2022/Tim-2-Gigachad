using KorisnikService.DTO;

namespace KorisnikService.Helpers
{
	/// <summary>
	/// Interfejs od helpera za autentifikaciju korisnika.
	/// </summary>
	public interface IAutentifikacijaHelper
	{
		/// <summary>
		/// Vrši autentifikaciju korisnika.
		/// </summary>
		/// <param name="korisnikDTO">Model sa podacima na osnovu kojih se vrši autentifikacija.</param>
		/// <returns>Vraća boolean o potvrdi autentifikacije korisnika.</returns>
		public bool AuthenticateKorisnik(KorisnikAuthenticateDTO korisnikDTO);

		/// <summary>
		/// Generiše novi token za autentifikovanog korisnika.
		/// </summary>
		/// <param name="korisnikDTO">Model sa podacima na osnovu kojih se vrši autentifikacija.</param>
		/// <returns>Vraća generisani token u obliku stringa.</returns>
		public string GenerateJWT(KorisnikAuthenticateDTO korisnikDTO);
	}
}
