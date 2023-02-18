using AutoMapper;
using DeoParceleService.Data;
using DeoParceleService.DTO;
using DeoParceleService.Entities;
using DeoParceleService.ServiceCalls;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace DeoParceleService.Controllers
{
	/// <summary>
	/// Kontroler za entitet deo parcele.
	/// </summary>
	[Authorize]
	[ApiController]
	[Route("api/deoParcele")]
	[Produces("application/json", "application/xml")]
	public class DeoParceleController : ControllerBase
	{
		private readonly IParcelaRepository parcelaRepository;
		private readonly IDeoParceleRepository deoParceleRepository;
		private readonly LinkGenerator linkGenerator;
		private readonly IMapper mapper;
		private readonly IKupacService kupacService;

		/// <summary>
		/// Dependency injection za kontroler.
		/// </summary>
		public DeoParceleController(IParcelaRepository parcelaRepository, IDeoParceleRepository deoParceleRepository, LinkGenerator linkGenerator, IMapper mapper, IKupacService kupacService)
		{
			this.parcelaRepository = parcelaRepository;
			this.deoParceleRepository = deoParceleRepository;
			this.linkGenerator = linkGenerator;
			this.mapper = mapper;
			this.kupacService = kupacService;
		}

		/// <summary>
		/// Vraća listu svih delova parcela.
		/// </summary>
		/// <returns>Vraća potvrdu o listi postojećih delova parcela.</returns>
		/// <param name="authorization">Autorizovan token.</param>
		/// <response code="200">Vraća listu delova parcela.</response>
		/// <response code="204">Ne postoje delovi parcela.</response>
		//[HttpHead]
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		public ActionResult<List<DeoParceleDTO>> GetDeloviParcela([FromHeader] string authorization)
		{
			List<DeoParceleEntity> deloviParcela = deoParceleRepository.GetDeloviParcela();
			if (deloviParcela == null || deloviParcela.Count == 0)
				return NoContent();

			List<DeoParceleDTO> deloviParcelaDTO = new();
			foreach (DeoParceleEntity deoParcele in deloviParcela)
			{
				DeoParceleDTO deoParceleDTO = mapper.Map<DeoParceleDTO>(deoParcele);
				KupacDTO? kupacDTO = kupacService.GetKupacByIDAsync(deoParcele.KupacID, authorization).Result;
				if (kupacDTO != null)
				{
					ParcelaEntity? parcela = parcelaRepository.GetParcelaByID(deoParcele.ParcelaID);
					if (parcela != null)
					{
						KupacDTO? kupacParceleDTO = kupacService.GetKupacByIDAsync(parcela.KupacID, authorization).Result;
						if (kupacParceleDTO != null)
						{
							deoParceleDTO.Parcela = mapper.Map<ParcelaDTO>(parcela);
							deoParceleDTO.Parcela.Kupac = kupacParceleDTO;
							deoParceleDTO.Kupac = kupacDTO;
							deloviParcelaDTO.Add(deoParceleDTO);
						}
					}
				}
			}
			return Ok(deloviParcelaDTO);
		}

		/// <summary>
		/// Vraća jedan deo parcele na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="deoParceleID">ID dela parcele.</param>
		/// <param name="authorization">Autorizovan token.</param>
		/// <returns>Vraća potvrdu o specifiranom delu parcele.</returns>
		/// <response code="200">Vraća specifirani deo parcele.</response>
		/// <response code="404">Specifirani deo parcele ne postoji.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom pronalaženja specifiranog dela parcele.</response>
		[HttpGet("{deoParceleID}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<DeoParceleDTO> GetDeoParcele(Guid deoParceleID, [FromHeader] string authorization)
		{
			DeoParceleEntity? deoParcele = deoParceleRepository.GetDeoParceleByID(deoParceleID);
			if (deoParcele == null)
				return NotFound();

			Guid kupacID = deoParcele.KupacID;
			KupacDTO? kupacDTO = kupacService.GetKupacByIDAsync(kupacID, authorization).Result;
			if (kupacDTO != null)
			{
				DeoParceleDTO deoParceleDTO = mapper.Map<DeoParceleDTO>(deoParcele);
				ParcelaEntity? parcela = parcelaRepository.GetParcelaByID(deoParcele.ParcelaID);
				if (parcela != null)
				{
					Guid kupacParceleID = parcela.KupacID;
					KupacDTO? kupacParceleDTO = kupacService.GetKupacByIDAsync(kupacParceleID, authorization).Result;
					if (kupacParceleDTO != null)
					{
						deoParceleDTO.Parcela = mapper.Map<ParcelaDTO>(parcela);
						deoParceleDTO.Parcela.Kupac = kupacParceleDTO;
						deoParceleDTO.Kupac = kupacDTO;
						return Ok(deoParceleDTO);
					}
					else
						return StatusCode(StatusCodes.Status500InternalServerError, "Kupac parcele nije pronađen. ID kupca parcele: " + kupacParceleID.ToString() + ".");
				}
				else
					return StatusCode(StatusCodes.Status500InternalServerError, "Došlo je do greške na serveru prilikom pronalaženja dela parcele.");
			}
			else
				return StatusCode(StatusCodes.Status500InternalServerError, "Kupac nije pronađen. ID kupca: " + kupacID.ToString() + ".");
		}

		/// <summary>
		/// Kreira novi deo parcele.
		/// </summary>
		/// <param name="deoParceleCreateDTO">DTO za dela parcele.</param>
		/// <param name="authorization">Autorizovan token.</param>
		/// <returns>Vraća potvrdu o kreiranom delu parcele.</returns>
		/// <response code="201">Vraća kreirani deo parcele.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom kreiranja dela parcele.</response>
		[HttpPost]
		[Consumes("application/json")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<DeoParceleDTO> CreateDeoParcele([FromBody] DeoParceleCreateDTO deoParceleCreateDTO, [FromHeader] string authorization)
		{
			try
			{
				Guid kupacID = Guid.Parse(deoParceleCreateDTO.KupacID);
				KupacDTO? kupacDTO = kupacService.GetKupacByIDAsync(kupacID, authorization).Result;
				if (kupacDTO != null)
				{
					ParcelaEntity? parcela = parcelaRepository.GetParcelaByID(Guid.Parse(deoParceleCreateDTO.ParcelaID));
					if (parcela != null)
					{
						Guid kupacParceleID = parcela.KupacID;
						KupacDTO? kupacParceleDTO = kupacService.GetKupacByIDAsync(kupacParceleID, authorization).Result;
						if (kupacParceleDTO != null)
						{
							DeoParceleDTO deoParceleDTO = deoParceleRepository.CreateDeoParcele(deoParceleCreateDTO);
							deoParceleRepository.SaveChanges();

							deoParceleDTO.Parcela = mapper.Map<ParcelaDTO>(parcela);
							deoParceleDTO.Parcela.Kupac = kupacParceleDTO;
							deoParceleDTO.Kupac = kupacDTO;

							string? location = linkGenerator.GetPathByAction("GetDeoParcele", "DeoParcele", new { deoParceleID = deoParceleDTO.ID });

							if (location != null)
								return Created(location, deoParceleDTO);
							else
								return Created(string.Empty, deoParceleDTO);
						}
						else
							return StatusCode(StatusCodes.Status500InternalServerError, "Kupac parcele nije pronađen. ID kupca parcele: " + kupacParceleID.ToString() + ".");
					}
					else
						return StatusCode(StatusCodes.Status500InternalServerError, "Došlo je do greške na serveru prilikom kreiranja dela parcele.");
				}
				else
					return StatusCode(StatusCodes.Status500InternalServerError, "Kupac nije pronađen. ID kupca: " + kupacID.ToString() + ".");
			}
			catch (Exception exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
			}
		}

		/// <summary>
		/// Ažurira jedan deo parcele.
		/// </summary>
		/// <param name="deoParceleUpdateDTO">DTO za ažuriranje dela parcele.</param>
		/// <param name="authorization">Autorizovan token.</param>
		/// <returns>Vraća potvrdu o ažuriranom delu parcele.</returns>
		/// <response code="200">Vraća ažurirani deo parcele.</response>
		/// <response code="404">Specifirani deo parcele ne postoji.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom ažuriranja dela parcele.</response>
		[HttpPut]
		[Consumes("application/json")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<DeoParceleDTO> UpdateDeoParcele(DeoParceleUpdateDTO deoParceleUpdateDTO, [FromHeader] string authorization)
		{
			try
			{
				DeoParceleEntity? oldDeoParcele = deoParceleRepository.GetDeoParceleByID(Guid.Parse(deoParceleUpdateDTO.ID));
				if (oldDeoParcele == null)
					return NotFound();

				Guid kupacID = Guid.Parse(deoParceleUpdateDTO.KupacID);
				KupacDTO? kupacDTO = kupacService.GetKupacByIDAsync(kupacID, authorization).Result;
				if (kupacDTO != null)
				{
					ParcelaEntity? parcela = parcelaRepository.GetParcelaByID(Guid.Parse(deoParceleUpdateDTO.ParcelaID));
					if (parcela != null)
					{
						Guid kupacParceleID = parcela.KupacID;
						KupacDTO? kupacParceleDTO = kupacService.GetKupacByIDAsync(kupacParceleID, authorization).Result;
						if (kupacParceleDTO != null)
						{
							DeoParceleEntity deoParcele = mapper.Map<DeoParceleEntity>(deoParceleUpdateDTO);
							mapper.Map(deoParcele, oldDeoParcele);
							deoParceleRepository.SaveChanges();
							DeoParceleDTO deoParceleDTO = mapper.Map<DeoParceleDTO>(oldDeoParcele);

							deoParceleDTO.Parcela = mapper.Map<ParcelaDTO>(parcela);
							deoParceleDTO.Parcela.Kupac = kupacParceleDTO;
							deoParceleDTO.Kupac = kupacDTO;

							return Ok(deoParceleDTO);
						}
						else
							return StatusCode(StatusCodes.Status500InternalServerError, "Kupac parcele nije pronađen. ID kupca parcele: " + kupacParceleID.ToString() + ".");
					}
					else
						return StatusCode(StatusCodes.Status500InternalServerError, "Došlo je do greške na serveru prilikom kreiranja dela parcele.");
				}
				else
					return StatusCode(StatusCodes.Status500InternalServerError, "Kupac nije pronađen. ID kupca: " + kupacID.ToString() + ".");
			}
			catch (Exception exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
			}
		}

		/// <summary>
		/// Briše jedan deo parcele na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="deoParceleID">ID dela parcele.</param>
		/// <returns>Vraća potvrdu o brisanju dela parcele.</returns>
		/// <response code="204">Specifirani deo parcele je uspešno obrisan.</response>
		/// <response code="404">Specifirani deo parcele ne postoji i nije obrisan.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom brisanja specifiranog dela parcele.</response>
		[HttpDelete("{parcelaID}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public IActionResult DeleteParcela(Guid deoParceleID)
		{
			try
			{
				DeoParceleEntity? deoParcele = deoParceleRepository.GetDeoParceleByID(deoParceleID);

				if (deoParcele == null)
					return NotFound();

				parcelaRepository.DeleteParcela(deoParceleID);
				parcelaRepository.SaveChanges();

				return NoContent();
			}
			catch (Exception exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
			}
		}

		/// <summary>
		/// Vraća opcije za rad sa entitetom deo parcele.
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
