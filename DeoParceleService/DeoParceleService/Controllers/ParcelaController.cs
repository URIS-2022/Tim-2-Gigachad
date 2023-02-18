using AutoMapper;
using DeoParceleService.Data;
using DeoParceleService.DTO;
using DeoParceleService.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeoParceleService.Controllers
{
	/// <summary>
	/// Kontroler za entitet parcela.
	/// </summary>
	[Authorize]
	[ApiController]
	[Route("api/parcele")]
	[Produces("application/json", "application/xml")]
	public class ParcelaController : ControllerBase
	{
		private readonly IParcelaRepository parcelaRepository;
		private readonly LinkGenerator linkGenerator;
		private readonly IMapper mapper;

		/// <summary>
		/// Dependency injection za kontroler.
		/// </summary>
		public ParcelaController(IParcelaRepository parcelaRepository, LinkGenerator linkGenerator, IMapper mapper)
		{
			this.parcelaRepository = parcelaRepository;
			this.linkGenerator = linkGenerator;
			this.mapper = mapper;
		}

		/// <summary>
		/// Vraća listu svih parcela.
		/// </summary>
		/// <returns>Vraća potvrdu o listi postojećih parcela.</returns>
		/// <response code="200">Vraća listu parcela.</response>
		/// <response code="204">Ne postoje parcele.</response>
		//[HttpHead]
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public ActionResult<List<ParcelaDTO>> GetParcele()
		{
			List<ParcelaEntity> parcele = parcelaRepository.GetParcele();
			if (parcele == null || parcele.Count == 0)
				return NoContent();
			return Ok(mapper.Map<List<ParcelaDTO>>(parcele));
		}

		/// <summary>
		/// Vraća jednu parcelu na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="parcelaID">ID parcele.</param>
		/// <returns>Vraća potvrdu o specifiranoj parceli.</returns>
		/// <response code="200">Vraća specifiranu parcelu.</response>
		/// <response code="404">Specifirana parcela ne postoji.</response>
		[HttpGet("{parcelaID}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<ParcelaDTO> GetParcela(Guid parcelaID)
		{
			ParcelaEntity? parcela = parcelaRepository.GetParcelaByID(parcelaID);
			if (parcela == null)
				return NotFound();
			return Ok(mapper.Map<ParcelaDTO>(parcela));
		}

		/// <summary>
		/// Kreira novu parcelu.
		/// </summary>
		/// <param name="parcelaCreateDTO">DTO za kreiranje parcele.</param>
		/// <returns>Vraća potvrdu o kreiranoj parceli.</returns>
		/// <response code="201">Vraća kreiranu parcelu.</response>
		/// <response code="422">Došlo je do greške, već postoji parcela na serveru sa istom oznakom.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom kreiranja parcele.</response>
		[HttpPost]
		[Consumes("application/json")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<ParcelaCreateDTO> CreateParcela([FromBody] ParcelaCreateDTO parcelaCreateDTO)
		{
			try
			{
				List<ParcelaEntity> parcele = parcelaRepository.GetParcele();
				if (parcele.Find(e => e.Oznaka == parcelaCreateDTO.Oznaka) == null)
				{
					ParcelaDTO parcelaDTO = parcelaRepository.CreateParcela(parcelaCreateDTO);
					parcelaRepository.SaveChanges();

					string? location = linkGenerator.GetPathByAction("GetParcela", "Parcela", new { parcelaID = parcelaDTO.ID });

					if (location != null)
						return Created(location, parcelaDTO);
					else
						return Created(string.Empty, parcelaDTO);
				}
				else
					return StatusCode(StatusCodes.Status422UnprocessableEntity, "Već postoji zadata oznaka parcele.");
			}
			catch (Exception exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
			}
		}

		/// <summary>
		/// Ažurira jednu parcelu.
		/// </summary>
		/// <param name="parcelaUpdateDTO">DTO za ažuriranje parcele.</param>
		/// <returns>Vraća potvrdu o ažuriranoj parceli.</returns>
		/// <response code="200">Vraća ažuriranu parcelu.</response>
		/// <response code="404">Specifirana parcela ne postoji.</response>
		/// <response code="422">Došlo je do greške, već postoji parcela na serveru sa istom oznakom.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom ažuriranja parcele.</response>
		[HttpPut]
		[Consumes("application/json")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<ParcelaDTO> UpdateParcela(ParcelaUpdateDTO parcelaUpdateDTO)
		{
			try
			{
				ParcelaEntity? oldParcela = parcelaRepository.GetParcelaByID(Guid.Parse(parcelaUpdateDTO.ID));
				if (oldParcela == null)
					return NotFound();
				List<ParcelaEntity> parcele = parcelaRepository.GetParcele();
				ParcelaEntity? tempParcela = parcele.Find(e => e.ID == Guid.Parse(parcelaUpdateDTO.ID));
				if (tempParcela != null)
					parcele.Remove(tempParcela);
				if (parcele.Find(e => e.Oznaka == parcelaUpdateDTO.Oznaka) == null)
				{
					ParcelaEntity parcela = mapper.Map<ParcelaEntity>(parcelaUpdateDTO);
					mapper.Map(parcela, oldParcela);
					parcelaRepository.SaveChanges();
					return Ok(mapper.Map<ParcelaDTO>(oldParcela));
				}
				else
					return StatusCode(StatusCodes.Status422UnprocessableEntity, "Već postoji zadati JMBG parcele.");
			}
			catch (Exception exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
			}
		}

		/// <summary>
		/// Briše jednu parcelu na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="parcelaID">ID parcele.</param>
		/// <returns>Vraća potvrdu o brisanju parcele.</returns>
		/// <response code="204">Specifirana parcela je uspešno obrisana.</response>
		/// <response code="404">Specifirana parcela ne postoji i nije obrisana.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom brisanja specifirane parcele.</response>
		[HttpDelete("{parcelaID}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult DeleteParcela(Guid parcelaID)
		{
			try
			{
				ParcelaEntity? parcela = parcelaRepository.GetParcelaByID(parcelaID);

				if (parcela == null)
					return NotFound();

				parcelaRepository.DeleteParcela(parcelaID);
				parcelaRepository.SaveChanges();

				return NoContent();
			}
			catch (Exception exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
			}
		}

		/// <summary>
		/// Vraća opcije za rad sa entitetom parcela.
		/// </summary>
		/// <returns>Vraća prazan 200 HTTP kod.</returns>
		/// <response code="200">Vraća prazan 200 HTTP kod.</response>
		[HttpOptions]
		[AllowAnonymous]
		public IActionResult GetParceleOptions()
		{
			Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
			return Ok();
		}
	}
}
