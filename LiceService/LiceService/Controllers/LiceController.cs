using AutoMapper;
using LiceService.Data;
using LiceService.DTO;
using LiceService.Entities;
using LiceService.ServiceCalls;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LiceService.Controllers
{
	/// <summary>
	/// Kontroler za entitet lice.
	/// </summary>
	[Authorize]
	[ApiController]
	[Route("api/lica")]
	[Produces("application/json", "application/xml")]
	public class LiceController : ControllerBase
	{
		private readonly ILiceRepository liceRepository;
		private readonly LinkGenerator linkGenerator;
		private readonly IMapper mapper;

		private readonly IAdresaService adresaService;

		/// <summary>
		/// Dependency injection za kontroler.
		/// </summary>
		public LiceController(ILiceRepository liceRepository, LinkGenerator linkGenerator, IMapper mapper, IAdresaService adresaService)
		{
			this.liceRepository = liceRepository;
			this.linkGenerator = linkGenerator;
			this.mapper = mapper;
			this.adresaService = adresaService;
		}

		/// <summary>
		/// Vraća listu svih lica.
		/// </summary>
		/// <returns>Vraća potvrdu o listi postojećih lica.</returns>
		/// <param name="authorization">Autorizovan token.</param>
		/// <response code="200">Vraća listu lica.</response>
		/// <response code="204">Ne postoje lica.</response>
		/// <response code="500">Adresa lica nije pronađena.</response>
		//[HttpHead]
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public ActionResult<List<LiceDTO>> GetLica([FromHeader] string authorization)
		{
			List<LiceEntity> lica = liceRepository.GetLica();
			if (lica == null || lica.Count == 0)
				return NoContent();
			List<LiceDTO> licaDTO = new();
			foreach (LiceEntity lice in lica)
			{
				Guid tempID = lice.ID;
				LiceDTO liceDTO = mapper.Map<LiceDTO>(lice);
				AdresaLicaDTO? adresaLica = adresaService.GetAdresaByIDAsync(lice.AdresaLicaID, authorization).Result;
				if (adresaLica != null)
				{
					liceDTO.AdresaLica = adresaLica;
					licaDTO.Add(liceDTO);
				}
				else
					return StatusCode(StatusCodes.Status500InternalServerError, "Adresa lica nije pronađena.\n ID adrese lica: " + tempID.ToString() + ".");
			}
			return Ok(licaDTO);
		}

		/// <summary>
		/// Vraća jedno lice na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="liceID">ID lica.</param>
		/// <param name="authorization">Autorizovan token.</param>
		/// <returns>Vraća potvrdu o specifiranom licu.</returns>
		/// <response code="200">Vraća specifirano lice.</response>
		/// <response code="404">Specifirano lice ne postoji.</response>
		[HttpGet("{liceID}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<LiceDTO> GetLice(Guid liceID, [FromHeader] string authorization)
		{
			LiceEntity? lice = liceRepository.GetLiceByID(liceID);
			if (lice == null)
				return NotFound();

			Guid tempID = lice.ID;
			AdresaLicaDTO? adresaLica = adresaService.GetAdresaByIDAsync(lice.AdresaLicaID, authorization).Result;
			if (adresaLica != null)
			{
				LiceDTO liceDTO = mapper.Map<LiceDTO>(lice);
				liceDTO.AdresaLica = adresaLica;
				return Ok(liceDTO);
			}
			else
				return StatusCode(StatusCodes.Status500InternalServerError, "Adresa lica nije pronađena.\n ID adrese lica: " + tempID.ToString() + ".");
		}

		/// <summary>
		/// Kreira novo lice.
		/// </summary>
		/// <param name="liceCreateDTO">DTO za kreiranje lica.</param>
		/// <param name="authorization">Autorizovan token.</param>
		/// <returns>Vraća potvrdu o kreiranom licu.</returns>
		/// <response code="201">Vraća kreirano lice.</response>
		/// <response code="422">Došlo je do greške, već postoji prvi telefon ili drugi telefon ili broj računa na serveru sa istim vrednostima.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom kreiranja lica.</response>
		[HttpPost]
		[Consumes("application/json")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<LiceCreateDTO> CreateLice([FromBody] LiceCreateDTO liceCreateDTO, [FromHeader] string authorization)
		{
			try
			{
				List<LiceEntity> lica = liceRepository.GetLica();
				if (lica.Find(e => e.FizickoLiceID == Guid.Parse(liceCreateDTO.FizickoLiceID)) == null)
				{
					if (lica.Find(e => e.Telefon1 == liceCreateDTO.Telefon1) == null &&
					lica.Find(e => e.Telefon2 == liceCreateDTO.Telefon1) == null)
					{
						if (liceCreateDTO.Telefon2 == null)
						{
							if (lica.Find(e => e.BrojRacuna == liceCreateDTO.BrojRacuna) == null)
							{
								LiceDTO lice = liceRepository.CreateLice(liceCreateDTO);
								liceRepository.SaveChanges();

								string? location = linkGenerator.GetPathByAction("GetLice", "Lice", new { liceID = lice.ID });

								if (location != null)
									return Created(location, lice);
								else
									return Created(string.Empty, lice);
							}
							else
								return StatusCode(StatusCodes.Status422UnprocessableEntity, "Već postoji zadati broj računa lica.");
						}
						else if (lica.Find(e => e.Telefon1 == liceCreateDTO.Telefon2) == null &&
							lica.Find(e => e.Telefon2 == liceCreateDTO.Telefon2) == null)
						{
							if (lica.Find(e => e.BrojRacuna == liceCreateDTO.BrojRacuna) == null)
							{
								LiceDTO lice = liceRepository.CreateLice(liceCreateDTO);
								liceRepository.SaveChanges();

								string? location = linkGenerator.GetPathByAction("GetLice", "Lice", new { liceID = lice.ID });

								if (location != null)
									return Created(location, lice);
								else
									return Created(string.Empty, lice);
							}
							else
								return StatusCode(StatusCodes.Status422UnprocessableEntity, "Već postoji zadati broj računa lica.");
						}
						else
							return StatusCode(StatusCodes.Status422UnprocessableEntity, "Već postoji zadati telefon dva lica.");
					}
					else
						return StatusCode(StatusCodes.Status422UnprocessableEntity, "Već postoji zadati telefon jedan lica.");
				}
				else
					return StatusCode(StatusCodes.Status422UnprocessableEntity, "Već postoji zadato fizičko lice lica.");
			}
			catch (Exception exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
			}
		}

		/// <summary>
		/// Ažurira jedno lice.
		/// </summary>
		/// <param name="liceUpdateDTO">DTO za ažuriranje lica.</param>
		/// <param name="authorization">Autorizovan token.</param>
		/// <returns>Vraća potvrdu o ažuriranom licu.</returns>
		/// <response code="200">Vraća ažurirano lice.</response>
		/// <response code="404">Specifirano lice ne postoji.</response>
		/// <response code="422">Došlo je do greške, već postoji prvi telefon ili drugi telefon ili broj računa na serveru sa istim vrednostima.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom ažuriranja lica.</response>
		[HttpPut]
		[Consumes("application/json")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<LiceDTO> UpdateLice(LiceUpdateDTO liceUpdateDTO, [FromHeader] string authorization)
		{
			try
			{
				LiceEntity? oldLice = liceRepository.GetLiceByID(Guid.Parse(liceUpdateDTO.ID));
				if (oldLice == null)
					return NotFound();

				List<LiceEntity> lica = liceRepository.GetLica();
				LiceEntity? tempLice = lica.Find(e => e.ID == Guid.Parse(liceUpdateDTO.ID));
				if (tempLice != null)
					lica.Remove(tempLice);

				if (lica.Find(e => e.FizickoLiceID == Guid.Parse(liceUpdateDTO.FizickoLiceID)) == null)
				{
					if (lica.Find(e => e.Telefon1 == liceUpdateDTO.Telefon1) == null &&
					lica.Find(e => e.Telefon2 == liceUpdateDTO.Telefon1) == null)
					{
						if (liceUpdateDTO.Telefon2 == null)
						{
							if (lica.Find(e => e.BrojRacuna == liceUpdateDTO.BrojRacuna) == null)
							{
								LiceEntity lice = mapper.Map<LiceEntity>(liceUpdateDTO);
								mapper.Map(lice, oldLice);
								liceRepository.SaveChanges();
								return Ok(mapper.Map<LiceDTO>(oldLice));
							}
							else
								return StatusCode(StatusCodes.Status422UnprocessableEntity, "Već postoji zadati broj računa lica.");
						}
						else if (lica.Find(e => e.Telefon1 == liceUpdateDTO.Telefon2) == null &&
							lica.Find(e => e.Telefon2 == liceUpdateDTO.Telefon2) == null)
						{
							if (lica.Find(e => e.BrojRacuna == liceUpdateDTO.BrojRacuna) == null)
							{
								LiceEntity lice = mapper.Map<LiceEntity>(liceUpdateDTO);
								mapper.Map(lice, oldLice);
								liceRepository.SaveChanges();
								return Ok(mapper.Map<LiceDTO>(oldLice));
							}
							else
								return StatusCode(StatusCodes.Status422UnprocessableEntity, "Već postoji zadati broj računa lica.");
						}
						else
							return StatusCode(StatusCodes.Status422UnprocessableEntity, "Već postoji zadati telefon dva lica.");
					}
					else
						return StatusCode(StatusCodes.Status422UnprocessableEntity, "Već postoji zadati telefon jedan lica.");
				}
				else
					return StatusCode(StatusCodes.Status422UnprocessableEntity, "Već postoji zadato fizičko lice lica.");
			}
			catch (Exception exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
			}
		}

		/// <summary>
		/// Briše jedno lice na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="liceID">ID lica.</param>
		/// <param name="authorization">Autorizovan token.</param>
		/// <returns>Vraća potvrdu o brisanju lica.</returns>
		/// <response code="204">Specifirano lice je uspešno obrisano.</response>
		/// <response code="404">Specifirano lice ne postoji i nije obrisano.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom brisanja specifiranog lica.</response>
		[HttpDelete("{liceID}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult DeleteLice(Guid liceID, [FromHeader] string authorization)
		{
			try
			{
				LiceEntity? lice = liceRepository.GetLiceByID(liceID);

				if (lice == null)
					return NotFound();

				liceRepository.DeleteLice(liceID);
				liceRepository.SaveChanges();

				return NoContent();
			}
			catch (Exception exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
			}
		}

		/// <summary>
		/// Vraća opcije za rad sa licima.
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
