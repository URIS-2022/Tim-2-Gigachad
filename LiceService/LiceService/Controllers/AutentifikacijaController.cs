using LiceService.Helpers;
using LiceService.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiceService.Controllers
{
	/// <summary>
	/// Kontroler za autentifikaciju korisnika.
	/// </summary>
	[ApiController]
	[Route("api/fizickaLica")]
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
		/// Vrši autentifikaciju korisnika i vraća token.
		/// </summary>
		/// <param name="korisnik">Model sa podacima na osnovu kojih se vrši autentifikacija.</param>
		/// <returns>Vraća potvrdu o autentifikaciji korisnika.</returns>
		/// <response code="200">Vraća token korisnika.</response>
		/// <response code="401">Korisnik nije auterizovan.</response>
		[AllowAnonymous]
		[HttpPost("authenticate")]
		[Consumes("application/json")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public IActionResult Authenticate([FromBody] KorisnikDTO korisnik)
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
