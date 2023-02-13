using LiceService.Data;
using LiceService.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace LiceService.Helpers
{
	public class AutentifikacijaHelper : IAutentifikacijaHelper
	{
		private readonly IKorisnikRepository korisnikRepository;
		private readonly IConfiguration configuration;

		public AutentifikacijaHelper(IKorisnikRepository korisnikRepository, IConfiguration configuration)
		{
			this.korisnikRepository = korisnikRepository;
			this.configuration = configuration;
		}

		/// <summary>
		/// Vrši autentifikaciju korisnika.
		/// </summary>
		/// <param name="korisnik">Model sa podacima na osnovu kojih se vrši autentifikacija.</param>
		/// <returns>Boolean koji označava da li je korisnik autentifikovan ili nije.</returns>
		public bool AuthenticateKorisnik(KorisnikDTO korisnik)
		{
			if (korisnikRepository.KorisnikWithCredentialsExists(korisnik.Naziv, korisnik.Lozinka))
				return true;
			return false;
		}

		/// <summary>
		/// Generiše novi token za autentifikovanog korisnika.
		/// </summary>
		/// <param name="korisnik">Model sa podacima na osnovu kojih se vrši autentifikacija.</param>
		/// <returns>Vraća generisani token u obliku stringa.</returns>
		public string GenerateJWT(KorisnikDTO korisnik)
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(configuration["JWT:Issuer"],
									   configuration["JWT:Audience"],
									   null,
									   expires: DateTime.Now.AddMinutes(120),
									   signingCredentials: credentials);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
