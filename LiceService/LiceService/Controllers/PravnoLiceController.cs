using AutoMapper;
using LiceService.Data;
using LiceService.DTO;
using LiceService.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiceService.Controllers
{
	/// <summary>
	/// Kontroler za entitet pravno lice.
	/// </summary>
	[Authorize]
	[ApiController]
	[Route("api/pravnaLica")]
	[Produces("application/json", "application/xml")]
	public class PravnoLiceController : ControllerBase
	{
		private readonly IPravnoLiceRepository pravnoLiceRepository;
		private readonly IKontaktOsobaRepository kontaktOsobaRepository;
		private readonly LinkGenerator linkGenerator;
		private readonly IMapper mapper;

		/// <summary>
		/// Dependency injection za kontroler.
		/// </summary>
		public PravnoLiceController(IPravnoLiceRepository pravnoLiceRepository, IKontaktOsobaRepository kontaktOsobaRepository, LinkGenerator linkGenerator, IMapper mapper)
		{
			this.pravnoLiceRepository = pravnoLiceRepository;
			this.kontaktOsobaRepository = kontaktOsobaRepository;
			this.linkGenerator = linkGenerator;
			this.mapper = mapper;
		}

		/// <summary>
		/// Vraća listu svih pravnih lica.
		/// </summary>
		/// <returns>Vraća potvrdu o listi postojećih pravnih lica.</returns>
		/// <response code="200">Vraća listu pravnih lica.</response>
		/// <response code="204">Ne postoje pravna lica.</response>
		[HttpHead]
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public ActionResult<List<PravnoLiceDTO>> GetPravnaLica()
		{
			List<PravnoLiceEntity> pravnaLica = pravnoLiceRepository.GetPravnaLica();
			if (pravnaLica == null || pravnaLica.Count == 0)
				return NoContent();

			List<PravnoLiceDTO> pravnaLicaDTO = new();
			foreach (PravnoLiceEntity pravnoLice in pravnaLica)
			{
				PravnoLiceDTO pravnoLiceDTO = mapper.Map<PravnoLiceDTO>(pravnoLice);
				pravnoLiceDTO.KontaktOsoba = mapper.Map<KontaktOsobaDTO>(kontaktOsobaRepository.GetKontaktOsobaByID(pravnoLice.KontaktOsobaID));
				pravnaLicaDTO.Add(pravnoLiceDTO);
			}

			return Ok(pravnaLicaDTO);
		}

		/// <summary>
		/// Vraća jedno pravno lice na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="pravnoLiceID">ID pravnog lica.</param>
		/// <returns>Vraća potvrdu o specifiranom fizičkom licu.</returns>
		/// <response code="200">Vraća specifirano pravno lice.</response>
		/// <response code="404">Specifirano pravno lice ne postoji.</response>
		[HttpGet("{pravnoLiceID}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<PravnoLiceDTO> GetPravnoLice(Guid pravnoLiceID)
		{
			PravnoLiceEntity? pravnoLice = pravnoLiceRepository.GetPravnoLiceByID(pravnoLiceID);
			if (pravnoLice == null)
				return NotFound();

			PravnoLiceDTO pravnoLiceDTO = mapper.Map<PravnoLiceDTO>(pravnoLice);
			pravnoLiceDTO.KontaktOsoba = mapper.Map<KontaktOsobaDTO>(kontaktOsobaRepository.GetKontaktOsobaByID(pravnoLice.KontaktOsobaID));

			return Ok(pravnoLiceDTO);
		}

		/// <summary>
		/// Kreira novo pravno lice.
		/// </summary>
		/// <param name="pravnoLiceCreateDTO">DTO za kreiranje pravnog lica.</param>
		/// <returns>Vraća potvrdu o kreiranom fizičkom licu.</returns>
		/// <remarks>
		/// Primer zahteva za kreiranje novog pravnog lica. \
		/// POST /api/pravnaLica \
		/// { \
		///		"kontaktOsobaID": "5a2f51f9-3f5d-420f-9e98-510a3a5296a1", \
		///		"naziv": "KOMPANIJA DOO", \
		///		"maticniBroj": "12345678" \
		/// }
		/// </remarks>
		/// <response code="201">Vraća kreirano pravno lice.</response>
		/// <response code="422">Došlo je do greške, već postoji pravno lice na serveru sa istim matičnim brojem.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom kreiranja pravnog lica.</response>
		[HttpPost]
		[Consumes("application/json")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<PravnoLiceCreateDTO> CreatePravnoLice([FromBody] PravnoLiceCreateDTO pravnoLiceCreateDTO)
		{
			try
			{
				List<PravnoLiceEntity> pravnaLica = pravnoLiceRepository.GetPravnaLica();
				if (pravnaLica.Find(e => e.MaticniBroj == pravnoLiceCreateDTO.MaticniBroj) == null)
				{
					PravnoLiceDTO pravnoLiceDTO = pravnoLiceRepository.CreatePravnoLice(pravnoLiceCreateDTO);
					pravnoLiceRepository.SaveChanges();
					pravnoLiceDTO.KontaktOsoba = mapper.Map<KontaktOsobaDTO>(kontaktOsobaRepository.GetKontaktOsobaByID(Guid.Parse(pravnoLiceCreateDTO.KontaktOsobaID)));
					
					string? location = linkGenerator.GetPathByAction("GetPravnoLice", "PravnoLice", new { pravnoLiceID = pravnoLiceDTO.ID });

					if (location != null)
						return Created(location, pravnoLiceDTO);
					else
						return Created(string.Empty, pravnoLiceDTO);
				}
				else
					return StatusCode(StatusCodes.Status422UnprocessableEntity, "Već postoji zadati matični broj pravnog lica.");
			}
			catch (Exception exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
			}
		}

		/// <summary>
		/// Ažurira jedno pravno lice.
		/// </summary>
		/// <param name="pravnoLiceUpdateDTO">DTO za ažuriranje pravnog lica.</param>
		/// <returns>Vraća potvrdu o ažuriranom fizičkom licu.</returns>
		/// <remarks>
		/// Primer zahteva za ažuriranje postojećeg pravnog lica. \
		/// PUT /api/pravnaLica \
		/// { \
		///		"id": "006d992e-2109-4334-beff-3f5229129d14", \
		///		"kontaktOsobaID": "5a2f51f9-3f5d-420f-9e98-510a3a5296a1", \
		///		"naziv": "KOMPANIJA DOO", \
		///		"maticniBroj": "12345678" \
		/// }
		/// </remarks>
		/// <response code="200">Vraća ažurirano pravno lice.</response>
		/// <response code="404">Specifirano pravno lice ne postoji.</response>
		/// <response code="422">Došlo je do greške, već postoji pravno lice na serveru sa istim matičnim brojem.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom ažuriranja pravnog lica.</response>
		[HttpPut]
		[Consumes("application/json")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<PravnoLiceDTO> UpdatePravnoLice(PravnoLiceUpdateDTO pravnoLiceUpdateDTO)
		{
			try
			{
				PravnoLiceEntity? oldPravnoLice = pravnoLiceRepository.GetPravnoLiceByID(Guid.Parse(pravnoLiceUpdateDTO.ID));
				if (oldPravnoLice == null)
					return NotFound();

				List<PravnoLiceEntity> pravnaLica = pravnoLiceRepository.GetPravnaLica();
				PravnoLiceEntity? tempPravnoLice = pravnaLica.Find(e => e.ID == Guid.Parse(pravnoLiceUpdateDTO.ID));
				if (tempPravnoLice != null)
					pravnaLica.Remove(tempPravnoLice);
				if (pravnaLica.Find(e => e.MaticniBroj == pravnoLiceUpdateDTO.MaticniBroj) == null)
				{
					PravnoLiceEntity pravnoLice = mapper.Map<PravnoLiceEntity>(pravnoLiceUpdateDTO);
					mapper.Map(pravnoLice, oldPravnoLice);
					pravnoLiceRepository.SaveChanges();

					PravnoLiceDTO pravnoLiceDTO = mapper.Map<PravnoLiceDTO>(oldPravnoLice);
					pravnoLiceDTO.KontaktOsoba = mapper.Map<KontaktOsobaDTO>(kontaktOsobaRepository.GetKontaktOsobaByID(oldPravnoLice.KontaktOsobaID));

					return Ok(pravnoLiceDTO);
				}
				else
					return StatusCode(StatusCodes.Status422UnprocessableEntity, "Već postoji zadati matični broj pravnog lica.");
			}
			catch (Exception exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
			}
		}

		/// <summary>
		/// Briše jedno pravno lice na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="pravnoLiceID">ID pravnog lica.</param>
		/// <returns>Vraća potvrdu o brisanju pravnog lica.</returns>
		/// <response code="204">Specifirano pravno lice je uspešno obrisano.</response>
		/// <response code="404">Specifirano pravno lice ne postoji i nije obrisano.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom brisanja specifiranog pravnog lica.</response>
		[HttpDelete("{pravnoLiceID}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult DeletePravnoLice(Guid pravnoLiceID)
		{
			try
			{
				PravnoLiceEntity? pravnoLice = pravnoLiceRepository.GetPravnoLiceByID(pravnoLiceID);

				if (pravnoLice == null)
					return NotFound();

				pravnoLiceRepository.DeletePravnoLice(pravnoLiceID);
				pravnoLiceRepository.SaveChanges();

				return NoContent();
			}
			catch (Exception exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
			}
		}

		/// <summary>
		/// Vraća opcije za rad sa entitetom pravno lice.
		/// </summary>
		/// <returns>Vraća prazan 200 HTTP kod.</returns>
		/// <response code="200">Vraća prazan 200 HTTP kod.</response>
		[HttpOptions]
		[AllowAnonymous]
		public IActionResult GetPravnaLicaOptions()
		{
			Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
			return Ok();
		}
	}
}
