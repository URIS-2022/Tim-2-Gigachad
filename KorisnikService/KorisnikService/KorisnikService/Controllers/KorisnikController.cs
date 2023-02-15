using AutoMapper;
using KorisnikService.Data;
using KorisnikService.DTO;
using KorisnikService.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KorisnikService.Controllers
{
	/// <summary>
	/// Kontroler za entitet fizičko lice.
	/// </summary>
	[Authorize]
	[ApiController]
	[Route("api/korisnici")]
	[Produces("application/json", "application/xml")]
	public class KorisnikController : ControllerBase
	{
		private readonly IKorisnikRepository korisnikLiceRepository;
		private readonly LinkGenerator linkGenerator;
		private readonly IMapper mapper;

		/// <summary>
		/// Dependency injection za kontroler.
		/// </summary>
		public KorisnikController(IKorisnikRepository korisnikLiceRepository, LinkGenerator linkGenerator, IMapper mapper)
		{
			this.korisnikLiceRepository = korisnikLiceRepository;
			this.linkGenerator = linkGenerator;
			this.mapper = mapper;
		}

		/// <summary>
		/// Vraća listu svih korisnika.
		/// </summary>
		/// <returns>Vraća potvrdu o listi postojećih korisnika.</returns>
		/// <response code="200">Vraća listu korisnika.</response>
		/// <response code="204">Ne postoje korisnici.</response>
		[HttpHead]
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public ActionResult<List<KorisnikDTO>> GetKorisnici()
		{
			List<KorisnikEntity> korisnik = korisnikLiceRepository.GetKorisnici();
			if (korisnik == null || korisnik.Count == 0)
				return NoContent();
			return Ok(mapper.Map<List<KorisnikDTO>>(korisnik));
		}

		/// <summary>
		/// Vraća jednog korisnika na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="korisnikID">ID korisnika.</param>
		/// <returns>Vraća potvrdu o specifiranom korisniku.</returns>
		/// <response code="200">Vraća specifiranog korisnika.</response>
		/// <response code="404">Specifirani korisnik ne postoji.</response>
		[HttpHead]
		[HttpGet("{korisnikID}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<KorisnikDTO> GetKorisnik(Guid korisnikID)
		{
			var korisnik = korisnikLiceRepository.GetKorisnikByID(korisnikID);
			if (korisnik == null)
				return NotFound();
			return Ok(mapper.Map<KorisnikDTO>(korisnik));
		}

		/// <summary>
		/// Kreira novog korisnika.
		/// </summary>
		/// <param name="korisnikCreateDTO">DTO za kreiranje korisnika.</param>
		/// <returns>Potvrdu o kreiranom korisniku.</returns>
		/// <response code="201">Vraća kreiranog korisnika.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom kreiranja novog korisnika.</response>
		[HttpHead]
		[HttpPost]
		[Consumes("application/json")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<KorisnikCreateDTO> CreateKorisnik([FromBody] KorisnikCreateDTO korisnikCreateDTO)
		{
			try
			{
				KorisnikDTO korisnik = korisnikLiceRepository.CreateKorisnik(korisnikCreateDTO);
				korisnikLiceRepository.SaveChanges();

				string? location = linkGenerator.GetPathByAction("GetKorisnik", "Korisnik", new { korisnikID = korisnik.ID });

				if (location != null)
					return Created(location, korisnik);
				else
					return Created("", korisnik);
			}
			catch (Exception exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
			}
		}

		/// <summary>
		/// Ažurira jednog korisnika.
		/// </summary>
		/// <param name="korisnikUpdateDTO">DTO za ažuriranje korisnika.</param>
		/// <returns>Potvrdu o ažuriranom korisniku.</returns>
		/// <response code="200">Vraća ažuriranog korisnika.</response>
		/// <response code="404">Specifirani korisnik ne postoji.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom ažuriranja specifiranog korisnika.</response>
		[HttpHead]
		[HttpPut]
		[Consumes("application/json")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<KorisnikDTO> UpdateKorisnik(KorisnikUpdateDTO korisnikUpdateDTO)
		{
			try
			{
				KorisnikEntity? oldKorisnik = korisnikLiceRepository.GetKorisnikByID(korisnikUpdateDTO.ID);
				if (oldKorisnik == null)
					return NotFound();
				KorisnikEntity korisnik = mapper.Map<KorisnikEntity>(korisnikUpdateDTO);
				mapper.Map(korisnik, oldKorisnik);
				korisnikLiceRepository.SaveChanges();
				return Ok(mapper.Map<KorisnikDTO>(oldKorisnik));
			}
			catch (Exception exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
			}
		}

		/// <summary>
		/// Briše jednog korisnika na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="korisnikID">ID korisnika.</param>
		/// <returns>Potvrdu o brisanju korisnika.</returns>
		/// <response code="204">Specifirani korisnik je uspešno obrisano.</response>
		/// <response code="404">Specifirani korisnik ne postoji i nije obrisan.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom brisanja specifiranog korisnika.</response>
		[HttpHead]
		[HttpDelete("{korisnikID}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult DeleteKorisnik(Guid korisnikID)
		{
			try
			{
				KorisnikEntity? korisnik = korisnikLiceRepository.GetKorisnikByID(korisnikID);

				if (korisnik == null)
					return NotFound();

				korisnikLiceRepository.DeleteKorisnik(korisnikID);
				korisnikLiceRepository.SaveChanges();

				return NoContent();
			}
			catch (Exception exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
			}
		}

		/// <summary>
		/// Vraća opcije za rad sa korisnicima.
		/// </summary>
		/// <returns>Vraća prazan 200 HTTP kod.</returns>
		/// <response code="200">Vraća prazan 200 HTTP kod.</response>
		[HttpOptions]
		[AllowAnonymous]
		public IActionResult GetKorisniciOptions()
		{
			Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
			return Ok();
		}
	}
}
