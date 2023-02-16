using AutoMapper;
using LiceService.Data;
using LiceService.DTO;
using LiceService.Entities;
using LiceService.ServiceCalls;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Net.NetworkInformation;

namespace LiceService.Controllers
{
	/// <summary>
	/// Kontroler za entitet lice.
	/// </summary>
	//[Authorize]
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
		/// <response code="200">Vraća listu lica.</response>
		/// <response code="204">Ne postoje lica.</response>
		/// <response code="500">Adresa lica nije pronađena.</response>
		[HttpGet]
		//[HttpHead]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public ActionResult<List<LiceDTO>> GetLica([FromHeader] string authorization)
		{
			List<LiceEntity> lica = liceRepository.GetLica();
			if (lica == null || lica.Count == 0)
				return NoContent();
			List<LiceDTO> licaDTO = new List<LiceDTO>();
			foreach (LiceEntity lice in lica)
			{
				LiceDTO liceDTO = mapper.Map<LiceDTO>(lice);
				AdresaLicaDTO? adresaLica = adresaService.GetAdresaByIDAsync(lice.AdresaLicaID, authorization).Result;
				if (adresaLica != null)
				{
					liceDTO.AdresaLica = adresaLica;
					licaDTO.Add(liceDTO);
				}
				else
					return StatusCode(StatusCodes.Status500InternalServerError, "Adresa lica nije pronađena.");
			}
			return Ok(licaDTO);
		}

		/// <summary>
		/// Vraća jedno lice na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="liceID">ID lica.</param>
		/// <returns>Vraća potvrdu o specifiranom licu.</returns>
		/// <response code="200">Vraća specifirano lice.</response>
		/// <response code="404">Specifirano lice ne postoji.</response>
		[HttpGet("{liceID}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<LiceDTO> GetLice(Guid liceID)
		{
			var lice = liceRepository.GetLiceByID(liceID);
			if (lice == null)
				return NotFound();
			return Ok(mapper.Map<LiceDTO>(lice));
		}

		/// <summary>
		/// Kreira novo lice.
		/// </summary>
		/// <param name="liceCreateDTO">DTO za kreiranje lica.</param>
		/// <returns>Potvrdu o kreiranom licu.</returns>
		/// <response code="201">Vraća kreirano lice.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom kreiranja lica.</response>
		[HttpPost]
		[Consumes("application/json")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<LiceCreateDTO> CreateLice([FromBody] LiceCreateDTO liceCreateDTO)
		{
			try
			{
				LiceDTO lice = liceRepository.CreateLice(liceCreateDTO);
				liceRepository.SaveChanges();
				
				string? location = linkGenerator.GetPathByAction("GetLice", "Lice", new { liceID = lice.ID });

				if (location != null)
					return Created(location, lice);
				else
					return Created(string.Empty, lice);
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
		/// <returns>Potvrdu o ažuriranom licu.</returns>
		/// <response code="200">Vraća ažurirano lice.</response>
		/// <response code="404">Specifirano lice ne postoji.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom ažuriranja lica.</response>
		[HttpPut]
		[Consumes("application/json")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<LiceDTO> UpdateLice(LiceUpdateDTO liceUpdateDTO)
		{
			try
			{
				LiceEntity? oldLice = liceRepository.GetLiceByID(Guid.Parse(liceUpdateDTO.ID));
				if (oldLice == null)
					return NotFound();
				LiceEntity lice = mapper.Map<LiceEntity>(liceUpdateDTO);
				mapper.Map(lice, oldLice);
				liceRepository.SaveChanges();
				return Ok(mapper.Map<LiceDTO>(oldLice));
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
		/// <returns>Potvrdu o brisanju lica.</returns>
		/// <response code="204">Specifirano lice je uspešno obrisano.</response>
		/// <response code="404">Specifirano lice ne postoji i nije obrisano.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom brisanja specifiranog lica.</response>
		[HttpDelete("{liceID}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult DeleteLice(Guid liceID)
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
