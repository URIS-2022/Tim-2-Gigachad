using AutoMapper;
using LiceService.Data;
using LiceService.DTO;
using LiceService.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiceService.Controllers
{
	/// <summary>
	/// Kontroler za entitet kontakt osobu.
	/// </summary>
	[Authorize]
	[ApiController]
	[Route("api/kontaktOsobe")]
	[Produces("application/json", "application/xml")]
	public class KontaktOsobaController : ControllerBase
	{
		private readonly IKontaktOsobaRepository kontaktOsobaRepository;
		private readonly LinkGenerator linkGenerator;
		private readonly IMapper mapper;

		/// <summary>
		/// Dependency injection za kontroler.
		/// </summary>
		public KontaktOsobaController(IKontaktOsobaRepository kontaktOsobaRepository, LinkGenerator linkGenerator, IMapper mapper)
		{
			this.kontaktOsobaRepository = kontaktOsobaRepository;
			this.linkGenerator = linkGenerator;
			this.mapper = mapper;
		}

		/// <summary>
		/// Vraća listu svih kontakt osoba.
		/// </summary>
		/// <returns>Vraća potvrdu o listi postojećih kontakt osoba.</returns>
		/// <response code="200">Vraća listu kontakt osoba.</response>
		/// <response code="204">Ne postoje kontakt osobe.</response>
		[HttpHead]
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public ActionResult<List<KontaktOsobaDTO>> GetKontaktOsobe()
		{
			List<KontaktOsobaEntity> kontaktOsobe = kontaktOsobaRepository.GetKontaktOsobe();
			if (kontaktOsobe == null || kontaktOsobe.Count == 0)
				return NoContent();
			return Ok(mapper.Map<List<KontaktOsobaDTO>>(kontaktOsobe));
		}

		/// <summary>
		/// Vraća jednu kontakt osobu na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="kontaktOsobaID">ID kontakt osobe.</param>
		/// <returns>Vraća potvrdu o specifiranoj kontakt osobi.</returns>
		/// <response code="200">Vraća specifiranu kontakt osobu.</response>
		/// <response code="404">Specifirana kontakt osoba ne postoji.</response>
		[HttpGet("{kontaktOsobaID}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<KontaktOsobaDTO> GetKontaktOsoba(Guid kontaktOsobaID)
		{
			KontaktOsobaEntity? kontaktOsoba = kontaktOsobaRepository.GetKontaktOsobaByID(kontaktOsobaID);
			if (kontaktOsoba == null)
				return NotFound();
			return Ok(mapper.Map<KontaktOsobaDTO>(kontaktOsoba));
		}

		/// <summary>
		/// Kreira novu kontakt osobu.
		/// </summary>
		/// <param name="kontaktOsobaCreateDTO">DTO za kreiranje kontakt osobe.</param>
		/// <returns>Potvrdu o kreiranoj kontakt osobi.</returns>
		/// <remarks>
		/// Primer zahteva za kreiranje nove kontakt osobe. \
		/// POST /api/kontaktOsobe \
		/// { \
		///		"ime": "Petar", \
		///		"prezime": "Rakić", \
		///		"telefon": "1234567891", \
		///		"funkcija": "programer" \
		/// }
		/// </remarks>
		/// <response code="201">Vraća kreiranu kontakt osobu.</response>
		/// <response code="422">Došlo je do greške, već postoji kontakt osoba na serveru sa istim telefonom.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom kreiranja kontakt osobe.</response>
		[HttpPost]
		[Consumes("application/json")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<KontaktOsobaCreateDTO> CreateKontaktOsoba([FromBody] KontaktOsobaCreateDTO kontaktOsobaCreateDTO)
		{
			try
			{
				List<KontaktOsobaEntity> fizickaLica = kontaktOsobaRepository.GetKontaktOsobe();
				if (fizickaLica.Find(e => e.Telefon == kontaktOsobaCreateDTO.Telefon) == null)
				{
					KontaktOsobaDTO kontaktOsobaDTO = kontaktOsobaRepository.CreateKontaktOsoba(kontaktOsobaCreateDTO);
					kontaktOsobaRepository.SaveChanges();

					string? location = linkGenerator.GetPathByAction("GetKontaktOsoba", "KontaktOsoba", new { kontaktOsobaID = kontaktOsobaDTO.ID });

					if (location != null)
						return Created(location, kontaktOsobaDTO);
					else
						return Created(string.Empty, kontaktOsobaDTO);
				}
				else
					return StatusCode(StatusCodes.Status422UnprocessableEntity, "Već postoji zadati telefon kontakt osobe.");
			}
			catch (Exception exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
			}
		}

		/// <summary>
		/// Ažurira jednu kontakt osobu.
		/// </summary>
		/// <param name="kontaktOsobaUpdateDTO">DTO za ažuriranje kontakt osobe.</param>
		/// <returns>Potvrdu o ažuriranoj kontakt osobi.</returns>
		/// <remarks>
		/// Primer zahteva za ažuriranje postojeće kontakt osobe. \
		/// PUT /api/kontaktOsobe \
		/// { \
		///		"id": "5a2f51f9-3f5d-420f-9e98-510a3a5296a1", \
		///		"ime": "Petar", \
		///		"prezime": "Rakić", \
		///		"telefon": "1234567891", \
		///		"funkcija": "programer" \
		/// }
		/// </remarks>
		/// <response code="200">Vraća ažuriranu kontakt osobu.</response>
		/// <response code="404">Specifirana kontakt osoba ne postoji.</response>
		/// <response code="422">Došlo je do greške, već postoji kontakt osoba na serveru sa istim telefonom.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom ažuriranja kontakt osobe.</response>
		[HttpPut]
		[Consumes("application/json")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<KontaktOsobaDTO> UpdateKontaktOsoba(KontaktOsobaUpdateDTO kontaktOsobaUpdateDTO)
		{
			try
			{
				KontaktOsobaEntity? oldKontaktOsoba = kontaktOsobaRepository.GetKontaktOsobaByID(Guid.Parse(kontaktOsobaUpdateDTO.ID));
				if (oldKontaktOsoba == null)
					return NotFound();
				List<KontaktOsobaEntity> fizickaLica = kontaktOsobaRepository.GetKontaktOsobe();
				KontaktOsobaEntity? tempKontaktOsoba = fizickaLica.Find(e => e.ID == Guid.Parse(kontaktOsobaUpdateDTO.ID));
				if (tempKontaktOsoba != null)
					fizickaLica.Remove(tempKontaktOsoba);
				if (fizickaLica.Find(e => e.Telefon == kontaktOsobaUpdateDTO.Telefon) == null)
				{
					KontaktOsobaEntity kontaktOsoba = mapper.Map<KontaktOsobaEntity>(kontaktOsobaUpdateDTO);
					mapper.Map(kontaktOsoba, oldKontaktOsoba);
					kontaktOsobaRepository.SaveChanges();
					return Ok(mapper.Map<KontaktOsobaDTO>(oldKontaktOsoba));
				}
				else
					return StatusCode(StatusCodes.Status422UnprocessableEntity, "Već postoji zadati telefon kontakt osobe.");
			}
			catch (Exception exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
			}
		}

		/// <summary>
		/// Briše jednu kontakt osobu na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="kontaktOsobaID">ID kontakt osobe.</param>
		/// <returns>Vraća potvrdu o brisanju kontakt osobe.</returns>
		/// <response code="204">Specifirana kontakt osoba je uspešno obrisana.</response>
		/// <response code="404">Specifirana kontakt osoba ne postoji i nije obrisana.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom brisanja specifirane kontakt osobe.</response>
		[HttpDelete("{kontaktOsobaID}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult DeleteKontaktOsoba(Guid kontaktOsobaID)
		{
			try
			{
				KontaktOsobaEntity? kontaktOsoba = kontaktOsobaRepository.GetKontaktOsobaByID(kontaktOsobaID);

				if (kontaktOsoba == null)
					return NotFound();

				kontaktOsobaRepository.DeleteKontaktOsoba(kontaktOsobaID);
				kontaktOsobaRepository.SaveChanges();

				return NoContent();
			}
			catch (Exception exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
			}
		}

		/// <summary>
		/// Vraća opcije za rad sa entitetom kontakt osoba.
		/// </summary>
		/// <returns>Vraća prazan 200 HTTP kod.</returns>
		/// <response code="200">Vraća prazan 200 HTTP kod.</response>
		[HttpOptions]
		[AllowAnonymous]
		public IActionResult GetKontaktOsobeOptions()
		{
			Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
			return Ok();
		}
	}
}
