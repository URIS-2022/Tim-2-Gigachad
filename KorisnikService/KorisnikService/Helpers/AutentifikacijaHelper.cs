using KorisnikService.Data;
using KorisnikService.DTO;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace KorisnikService.Helpers
{
	/// <summary>
	/// Helper za autentifikaciju korisnika.
	/// </summary>
	public class AutentifikacijaHelper : IAutentifikacijaHelper
	{
		private readonly IAutentifikacijaRepository korisnikRepository;
		private readonly IConfiguration configuration;

		/// <summary>
		/// Dependency injection za helper.
		/// </summary>
		public AutentifikacijaHelper(IAutentifikacijaRepository korisnikRepository, IConfiguration configuration)
		{
			this.korisnikRepository = korisnikRepository;
			this.configuration = configuration;
		}

		/// <summary>
		/// Vrši autentifikaciju korisnika.
		/// </summary>
		/// <param name="korisnik">Model sa podacima na osnovu kojih se vrši autentifikacija.</param>
		/// <returns>Vraća boolean o potvrdi autentifikacije korisnika.</returns>
		public bool AuthenticateKorisnik(KorisnikAuthenticateDTO korisnik)
		{
			if (korisnik.Naziv != null && korisnik.Lozinka != null && korisnikRepository.KorisnikWithCredentialsExists(korisnik.Naziv, korisnik.Lozinka))
				return true;
			return false;
		}

		/// <summary>
		/// Generiše novi token za autentifikovanog korisnika.
		/// </summary>
		/// <param name="korisnik">Model sa podacima na osnovu kojih se vrši autentifikacija.</param>
		/// <returns>Vraća generisani token u obliku stringa.</returns>
		public string GenerateJWT(KorisnikAuthenticateDTO korisnik)
		{
			string? key = configuration["JWT:Key"];
			if (key != null)
			{
				SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(key));
				SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);

				JwtSecurityToken token = new(configuration["JWT:Issuer"],
										configuration["JWT:Audience"],
										null,
										expires: DateTime.Now.AddMinutes(120),
										signingCredentials: credentials);

				return new JwtSecurityTokenHandler().WriteToken(token);
			}
			return string.Empty;
		}
	}
}
