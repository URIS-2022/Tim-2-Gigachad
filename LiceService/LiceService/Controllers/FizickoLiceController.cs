using AutoMapper;
using LiceService.Data;
using LiceService.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiceService.Controllers
{
	/// <summary>
	/// Kontroler za entitet fizičko lice.
	/// </summary>
	//[Authorize]
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
		/// Vraća sva fizička lica.
		/// </summary>
		/// <returns>Vraća potvrdu o listi postojećih fizičkih lica.</returns>
		/// <response code="200">Vraća listu fizičkih lica.</response>
		/// <response code="204">Ne postoje fizička lica.</response>
		[HttpGet]
		[HttpHead]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public ActionResult<List<FizickoLiceDTO>> GetFizickaLica()
		{
			var fizickaLica = fizickoLiceRepository.GetFizickaLica();
			if (fizickaLica == null || fizickaLica.Count == 0)
				return NoContent();
			return Ok(mapper.Map<List<FizickoLiceDTO>>(fizickaLica));
		}

		/// <summary>
		/// Vraća jedno fizičko lice na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="fizickoLiceID">ID fizičkog lica.</param>
		/// <returns>Vraća potvrdu o traženom fizičkom licu.</returns>
		/// <response code="200">Vraća specifirano fizičko lice.</response>
		/// <response code="404">Specifirano fizičko lice ne postoji.</response>
		[HttpGet("{fizickoLiceID}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<FizickoLiceDTO> GetFizickoLice(Guid fizickoLiceID)
		{
			var fizickoLice = fizickoLiceRepository.GetFizickoLiceByID(fizickoLiceID);
			if (fizickoLice == null)
				return NotFound();
			return Ok(mapper.Map<FizickoLiceDTO>(fizickoLice));
		}

		/// <summary>
		/// Kreira novo fizičko lice.
		/// </summary>
		/// <param name="fizickoLiceCreateDTO">Model fizičkog lica.</param>
		/// <returns>Potvrdu o kreiranom fizičkom licu.</returns>
		/// <response code="200">Vraća kreirano fizičko lice.</response>
		/// <response code="404">Došlo je do greške na serveru prilikom kreiranja fizičkog lica.</response>
		[HttpPost]
		[Consumes("application/json")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<FizickoLiceCreateDTO> CreateFizickoLice([FromBody] FizickoLiceCreateDTO fizickoLiceCreateDTO)
		{
			try
			{
				FizickoLiceDTO fizickoLice = fizickoLiceRepository.CreateFizickoLice(fizickoLiceCreateDTO);
				fizickoLiceRepository.SaveChanges();
				
				string? location = linkGenerator.GetPathByAction("GetFizickoLice", "FizickoLice", new { fizickoLiceID = fizickoLice.ID });

				if (location != null)
					return Created(location, fizickoLice);
				else
					return Created("", fizickoLice);
			}
			catch (Exception exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
			}
		}
	}
}
