using KorisnikService.Helpers;
using KorisnikService.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KorisnikService.Controllers
{
	/// <summary>
	/// Kontroler za autentifikaciju korisnika.
	/// </summary>
	[ApiController]
	[Route("api/korisnici")]
	[Produces("application/json", "application/xml")]
	public class AutentifikacijaController : ControllerBase
	{
		private readonly IAutentifikacijaHelper autentifikacijaHelper;

		/// <summary>
		/// Dependency injection za kontroler.
		/// </summary>
		public AutentifikacijaController(IAutentifikacijaHelper autentifikacijaHelper)
		{
			this.autentifikacijaHelper = autentifikacijaHelper;
		}

		/// <summary>
		/// Vrši autentifikaciju korisnika.
		/// </summary>
		/// <param name="korisnik">Model sa podacima na osnovu kojih se vrši autentifikacija.</param>
		/// <returns>Vraća potvrdu o autentifikaciji korisnika.</returns>
		/// <remarks>
		/// Primer zahteva za autentifikaciju korisnika. \
		/// POST api/korisnici/autentifikacija \
		/// { \
		///		"naziv": "korisnik", \
		///		"lozinka": "lozinka" \
		/// }
		/// </remarks>
		/// <response code="200">Vraća token korisnika.</response>
		/// <response code="401">Korisnik nije auterizovan.</response>
		[AllowAnonymous]
		[HttpPost("autentifikacija")]
		[Consumes("application/json")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public IActionResult Authenticate([FromBody] KorisnikAuthenticateDTO korisnik)
		{
			if (autentifikacijaHelper.AuthenticateKorisnik(korisnik))
			{
				var tokenString = autentifikacijaHelper.GenerateJWT(korisnik);
				return Ok(new { token = tokenString });
			}
			return Unauthorized();
		}
	}
}
