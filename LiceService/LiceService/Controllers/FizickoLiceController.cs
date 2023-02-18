using AutoMapper;
using LiceService.Data;
using LiceService.DTO;
using LiceService.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiceService.Controllers
{
	/// <summary>
	/// Kontroler za entitet fizičko lice.
	/// </summary>
	[Authorize]
	[ApiController]
	[Route("api/fizickaLica")]
	[Produces("application/json", "application/xml")]
	public class FizickoLiceController : ControllerBase
	{
		private readonly IFizickoLiceRepository fizickoLiceRepository;
		private readonly LinkGenerator linkGenerator;
		private readonly IMapper mapper;

		/// <summary>
		/// Dependency injection za kontroler.
		/// </summary>
		public FizickoLiceController(IFizickoLiceRepository fizickoLiceRepository, LinkGenerator linkGenerator, IMapper mapper)
		{
			this.fizickoLiceRepository = fizickoLiceRepository;
			this.linkGenerator = linkGenerator;
			this.mapper = mapper;
		}

		/// <summary>
		/// Vraća listu svih fizičkih lica.
		/// </summary>
		/// <returns>Vraća potvrdu o listi postojećih fizičkih lica.</returns>
		/// <response code="200">Vraća listu fizičkih lica.</response>
		/// <response code="204">Ne postoje fizička lica.</response>
		[HttpHead]
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public ActionResult<List<FizickoLiceDTO>> GetFizickaLica()
		{
			List<FizickoLiceEntity> fizickaLica = fizickoLiceRepository.GetFizickaLica();
			if (fizickaLica == null || fizickaLica.Count == 0)
				return NoContent();
			return Ok(mapper.Map<List<FizickoLiceDTO>>(fizickaLica));
		}

		/// <summary>
		/// Vraća jedno fizičko lice na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="fizickoLiceID">ID fizičkog lica.</param>
		/// <returns>Vraća potvrdu o specifiranom fizičkom licu.</returns>
		/// <response code="200">Vraća specifirano fizičko lice.</response>
		/// <response code="404">Specifirano fizičko lice ne postoji.</response>
		[HttpGet("{fizickoLiceID}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<FizickoLiceDTO> GetFizickoLice(Guid fizickoLiceID)
		{
			FizickoLiceEntity? fizickoLice = fizickoLiceRepository.GetFizickoLiceByID(fizickoLiceID);
			if (fizickoLice == null)
				return NotFound();
			return Ok(mapper.Map<FizickoLiceDTO>(fizickoLice));
		}

		/// <summary>
		/// Kreira novo fizičko lice.
		/// </summary>
		/// <param name="fizickoLiceCreateDTO">DTO za kreiranje fizičkog lica.</param>
		/// <returns>Vraća potvrdu o kreiranom fizičkom licu.</returns>
		/// <remarks>
		/// Primer zahteva za kreiranje novog fizičkog lica. \
		/// POST /api/fizickaLica \
		/// { \
		///		"jmbg": "1234567891234", \
		///		"ime": "Petar", \
		///		"prezime": "Rakić" \
		/// }
		/// </remarks>
		/// <response code="201">Vraća kreirano fizičko lice.</response>
		/// <response code="422">Došlo je do greške, već postoji fizičko lice na serveru sa istim JMBG-om.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom kreiranja fizičkog lica.</response>
		[HttpPost]
		[Consumes("application/json")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<FizickoLiceCreateDTO> CreateFizickoLice([FromBody] FizickoLiceCreateDTO fizickoLiceCreateDTO)
		{
			try
			{
				List<FizickoLiceEntity> fizickaLica = fizickoLiceRepository.GetFizickaLica();
				if (fizickaLica.Find(e => e.JMBG == fizickoLiceCreateDTO.JMBG) == null)
				{
					FizickoLiceDTO fizickoLiceDTO = fizickoLiceRepository.CreateFizickoLice(fizickoLiceCreateDTO);
					fizickoLiceRepository.SaveChanges();

					string? location = linkGenerator.GetPathByAction("GetFizickoLice", "FizickoLice", new { fizickoLiceID = fizickoLiceDTO.ID });

					if (location != null)
						return Created(location, fizickoLiceDTO);
					else
						return Created(string.Empty, fizickoLiceDTO);
				}
				else
					return StatusCode(StatusCodes.Status422UnprocessableEntity, "Već postoji zadati JMBG fizičkog lica.");
			}
			catch (Exception exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
			}
		}

		/// <summary>
		/// Ažurira jedno fizičko lice.
		/// </summary>
		/// <param name="fizickoLiceUpdateDTO">DTO za ažuriranje fizičkog lica.</param>
		/// <returns>Vraća potvrdu o ažuriranom fizičkom licu.</returns>
		/// <remarks>
		/// Primer zahteva za ažuriranje postojećeg fizičkog lica. \
		/// PUT /api/fizickaLica \
		/// { \
		///		"id": "ef4cf6d4-48f9-4508-a91f-330261325403", \
		///		"jmbg": "1234567891234", \
		///		"ime": "Petar", \
		///		"prezime": "Rakić" \
		///}
		/// </remarks>
		/// <response code="200">Vraća ažurirano fizičko lice.</response>
		/// <response code="404">Specifirano fizičko lice ne postoji.</response>
		/// <response code="422">Došlo je do greške, već postoji fizičko lice na serveru sa istim JMBG-om.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom ažuriranja fizičkog lica.</response>
		[HttpPut]
		[Consumes("application/json")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<FizickoLiceDTO> UpdateFizickoLice(FizickoLiceUpdateDTO fizickoLiceUpdateDTO)
		{
			try
			{
				FizickoLiceEntity? oldFizickoLice = fizickoLiceRepository.GetFizickoLiceByID(Guid.Parse(fizickoLiceUpdateDTO.ID));
				if (oldFizickoLice == null)
					return NotFound();
				List<FizickoLiceEntity> fizickaLica = fizickoLiceRepository.GetFizickaLica();
				FizickoLiceEntity? tempFizickoLice = fizickaLica.Find(e => e.ID == Guid.Parse(fizickoLiceUpdateDTO.ID));
				if (tempFizickoLice != null)
					fizickaLica.Remove(tempFizickoLice);
				if (fizickaLica.Find(e => e.JMBG == fizickoLiceUpdateDTO.JMBG) == null)
				{
					FizickoLiceEntity fizickoLice = mapper.Map<FizickoLiceEntity>(fizickoLiceUpdateDTO);
					mapper.Map(fizickoLice, oldFizickoLice);
					fizickoLiceRepository.SaveChanges();
					return Ok(mapper.Map<FizickoLiceDTO>(oldFizickoLice));
				}
				else
					return StatusCode(StatusCodes.Status422UnprocessableEntity, "Već postoji zadati JMBG fizičkog lica.");
			}
			catch (Exception exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
			}
		}

		/// <summary>
		/// Briše jedno fizičko lice na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="fizickoLiceID">ID fizičkog lica.</param>
		/// <returns>Vraća potvrdu o brisanju fizičkog lica.</returns>
		/// <response code="204">Specifirano fizičko lice je uspešno obrisano.</response>
		/// <response code="404">Specifirano fizičko lice ne postoji i nije obrisano.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom brisanja specifiranog fizičkog lica.</response>
		[HttpDelete("{fizickoLiceID}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult DeleteFizickoLice(Guid fizickoLiceID)
		{
			try
			{
				FizickoLiceEntity? fizickoLice = fizickoLiceRepository.GetFizickoLiceByID(fizickoLiceID);

				if (fizickoLice == null)
					return NotFound();

				fizickoLiceRepository.DeleteFizickoLice(fizickoLiceID);
				fizickoLiceRepository.SaveChanges();

				return NoContent();
			}
			catch (Exception exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
			}
		}

		/// <summary>
		/// Vraća opcije za rad sa entitetom fizičko lice.
		/// </summary>
		/// <returns>Vraća prazan 200 HTTP kod.</returns>
		/// <response code="200">Vraća prazan 200 HTTP kod.</response>
		[HttpOptions]
		[AllowAnonymous]
		public IActionResult GetFizickaLicaOptions()
		{
			Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
			return Ok();
		}
	}
}
