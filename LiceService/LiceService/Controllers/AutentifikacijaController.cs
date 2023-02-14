using LiceService.Helpers;
using LiceService.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiceService.Controllers
{
	[ApiController]
	[Route("api/fizickaLica")]
	[Produces("application/json", "application/xml")]
	public class AutentifikacijaController : ControllerBase
	{
		private readonly IAutentifikacijaHelper autentifikacijaHelper;

		public AutentifikacijaController(IAutentifikacijaHelper autentifikacijaHelper)
		{
			this.autentifikacijaHelper = autentifikacijaHelper;
		}

		/// <summary>
		/// Vrši autentifikaciju korisnika.
		/// </summary>
		/// <param name="korisnik">Model sa podacima na osnovu kojih se vrši autentifikacija.</param>
		/// <returns>Vraća HTTP odgovore.</returns>
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
