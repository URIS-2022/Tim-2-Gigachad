using AutoMapper;
using KorisnikService.Data;
using KorisnikService.DTO;
using KorisnikService.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

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
		private readonly IKorisnikRepository korisnikRepository;
		private readonly LinkGenerator linkGenerator;
		private readonly IMapper mapper;

		/// <summary>
		/// Dependency injection za kontroler.
		/// </summary>
		public KorisnikController(IKorisnikRepository korisnikRepository, LinkGenerator linkGenerator, IMapper mapper)
		{
			this.korisnikRepository = korisnikRepository;
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
			List<KorisnikEntity> korisnici = korisnikRepository.GetKorisnici();
			if (korisnici == null || korisnici.Count == 0)
				return NoContent();
			return Ok(mapper.Map<List<KorisnikDTO>>(korisnici));
		}

		/// <summary>
		/// Vraća jednog korisnika na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="korisnikID">ID korisnika.</param>
		/// <returns>Vraća potvrdu o specifiranom korisniku.</returns>
		/// <response code="200">Vraća specifiranog korisnika.</response>
		/// <response code="404">Specifirani korisnik ne postoji.</response>
		[HttpGet("{korisnikID}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<KorisnikDTO> GetKorisnik(Guid korisnikID)
		{
			var korisnik = korisnikRepository.GetKorisnikByID(korisnikID);
			if (korisnik == null)
				return NotFound();
			return Ok(mapper.Map<KorisnikDTO>(korisnik));
		}

		/// <summary>
		/// Kreira novog korisnika.
		/// </summary>
		/// <param name="korisnikCreateDTO">DTO za kreiranje korisnika.</param>
		/// <returns>Potvrdu o kreiranom korisniku.</returns>
		/// <remarks>
		/// Primer zahteva za kreiranje novog korisnika. \
		/// POST /api/korisnici \
		/// { \
		///		"naziv": "korisnik", \
		///		"lozinka": "lozinka", \
		///		"ime": "Aleksandar", \
		///		"prezime": "Perić", \
		///		"email": "peric.it30.2019@uns.ac.rs", \
		///		"tip": "ADMIN" \
		/// }
		/// </remarks>
		/// <response code="201">Vraća kreiranog korisnika.</response>
		/// <response code="422">Došlo je do greške, već postoji korisnik na serveru sa istim nazivom.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom kreiranja novog korisnika.</response>
		[HttpPost]
		[Consumes("application/json")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<KorisnikCreateDTO> CreateKorisnik([FromBody] KorisnikCreateDTO korisnikCreateDTO)
		{
			try
			{
				List<KorisnikEntity> korisnici = korisnikRepository.GetKorisnici();
				if (korisnici.Find(e => e.Naziv == korisnikCreateDTO.Naziv) == null &&
					korisnici.Find(e => e.Email == korisnikCreateDTO.Email) == null)
				{
					KorisnikDTO korisnikDTO = korisnikRepository.CreateKorisnik(korisnikCreateDTO);
					korisnikRepository.SaveChanges();

					string? location = linkGenerator.GetPathByAction("GetKorisnik", "Korisnik", new { korisnikID = korisnikDTO.ID });

					if (location != null)
						return Created(location, korisnikDTO);
					else
						return Created(string.Empty, korisnikDTO);
				}
				else
					return StatusCode(StatusCodes.Status422UnprocessableEntity, "Već postoji zadati naziv ili email korisnika.");
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
		/// <remarks>
		/// Primer zahteva za kreiranje novog korisnika. \
		/// PUT /api/korisnici \
		/// { \
		///		"id": "a0f34818-02ca-45fd-ad61-7978aebadd20", \
		///		"naziv": "korisnik", \
		///		"lozinka": "lozinka", \
		///		"ime": "Aleksandar", \
		///		"prezime": "Perić", \
		///		"email": "peric.it30.2019@uns.ac.rs", \
		///		"tip": "ADMIN" \
		/// }
		/// </remarks>
		/// <response code="200">Vraća ažuriranog korisnika.</response>
		/// <response code="404">Specifirani korisnik ne postoji.</response>
		/// <response code="422">Došlo je do greške, već postoji korisnik na serveru sa istim nazivom.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom ažuriranja specifiranog korisnika.</response>
		[HttpPut]
		[Consumes("application/json")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<KorisnikDTO> UpdateKorisnik(KorisnikUpdateDTO korisnikUpdateDTO)
		{
			try
			{
				if (korisnikRepository.GetKorisnikByID(Guid.Parse(korisnikUpdateDTO.ID)) == null)
					return NotFound();
				
				List<KorisnikEntity> korisnici = korisnikRepository.GetKorisnici();
				KorisnikEntity? tempKorisnik = korisnici.Find(e => e.ID == Guid.Parse(korisnikUpdateDTO.ID));
				if (tempKorisnik != null)
					korisnici.Remove(tempKorisnik);
				if (korisnici.Find(e => e.Naziv == korisnikUpdateDTO.Naziv) == null &&
					korisnici.Find(e => e.Email == korisnikUpdateDTO.Email) == null)
				{
					KorisnikDTO korisnikDTO = korisnikRepository.UpdateKorisnik(korisnikUpdateDTO);
					korisnikRepository.SaveChanges();

					return Ok(korisnikDTO);
				}
				else
					return StatusCode(StatusCodes.Status422UnprocessableEntity, "Već postoji zadati naziv ili email korisnika.");
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
		[HttpDelete("{korisnikID}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult DeleteKorisnik(Guid korisnikID)
		{
			try
			{
				KorisnikEntity? korisnik = korisnikRepository.GetKorisnikByID(korisnikID);

				if (korisnik == null)
					return NotFound();

				korisnikRepository.DeleteKorisnik(korisnikID);
				korisnikRepository.SaveChanges();

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
