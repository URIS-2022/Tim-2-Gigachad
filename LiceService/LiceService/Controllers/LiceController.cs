using AutoMapper;
using LiceService.Data;
using LiceService.DTO;
using LiceService.Entities;
using LiceService.ServiceCalls;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
		private readonly IFizickoLiceRepository fizickoLiceRepository;
		private readonly IKontaktOsobaRepository kontaktOsobaRepository;
		private readonly IPravnoLiceRepository pravnoLiceRepository;
		private readonly LinkGenerator linkGenerator;
		private readonly IMapper mapper;
		private readonly IAdresaService adresaService;

		/// <summary>
		/// Dependency injection za kontroler.
		/// </summary>
		public LiceController(ILiceRepository liceRepository, IFizickoLiceRepository fizickoLiceRepository, IPravnoLiceRepository pravnoLiceRepository, IKontaktOsobaRepository kontaktOsobaRepository, LinkGenerator linkGenerator, IMapper mapper, IAdresaService adresaService)
		{
			this.liceRepository = liceRepository;
			this.fizickoLiceRepository = fizickoLiceRepository;
			this.pravnoLiceRepository = pravnoLiceRepository;
			this.kontaktOsobaRepository = kontaktOsobaRepository;
			this.linkGenerator = linkGenerator;
			this.mapper = mapper;
			this.adresaService = adresaService;
		}

		/// <summary>
		/// Vraća listu svih lica.
		/// </summary>
		/// <param name="authorization">Autorizovan token.</param>
		/// <returns>Vraća potvrdu o listi postojećih lica.</returns>
		/// <response code="200">Vraća listu lica.</response>
		/// <response code="204">Ne postoje lica.</response>
		[HttpHead]
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
				LiceDTO liceDTO = mapper.Map<LiceDTO>(lice);
				AdresaDTO? adresaDTO = adresaService.GetAdresaByIDAsync(lice.AdresaID, authorization).Result;
				if (adresaDTO != null)
				{
					liceDTO.FizickoLice = mapper.Map<FizickoLiceDTO>(fizickoLiceRepository.GetFizickoLiceByID(lice.FizickoLiceID));
					if (lice.PravnoLiceID != null && lice.PravnoLiceID != Guid.Empty)
					{
						PravnoLiceEntity? pravnoLice = pravnoLiceRepository.GetPravnoLiceByID((Guid)lice.PravnoLiceID);
						if (pravnoLice != null)
						{
							liceDTO.PravnoLice = mapper.Map<PravnoLiceDTO>(pravnoLice);
							KontaktOsobaDTO kontaktOsobaDTO = mapper.Map<KontaktOsobaDTO>(kontaktOsobaRepository.GetKontaktOsobaByID(pravnoLice.KontaktOsobaID));
							liceDTO.PravnoLice.KontaktOsoba = kontaktOsobaDTO;
						}
					}
					liceDTO.Adresa = adresaDTO;
					licaDTO.Add(liceDTO);
				}
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
		/// <response code="500">Došlo je do greške na serveru prilikom pronalaženja specifiranog lica.</response>
		[HttpGet("{liceID}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<LiceDTO> GetLice(Guid liceID, [FromHeader] string authorization)
		{
			LiceEntity? lice = liceRepository.GetLiceByID(liceID);
			if (lice == null)
				return NotFound();

			Guid adresaID = lice.AdresaID;
			AdresaDTO? adresaDTO = adresaService.GetAdresaByIDAsync(adresaID, authorization).Result;
			if (adresaDTO != null)
			{
				LiceDTO liceDTO = mapper.Map<LiceDTO>(lice);
				liceDTO.FizickoLice = mapper.Map<FizickoLiceDTO>(fizickoLiceRepository.GetFizickoLiceByID(lice.FizickoLiceID));
				if (lice.PravnoLiceID != null && lice.PravnoLiceID != Guid.Empty)
				{
					PravnoLiceEntity? pravnoLice = pravnoLiceRepository.GetPravnoLiceByID((Guid)lice.PravnoLiceID);
					if (pravnoLice != null)
					{
						liceDTO.PravnoLice = mapper.Map<PravnoLiceDTO>(pravnoLice);
						KontaktOsobaDTO kontaktOsobaDTO = mapper.Map<KontaktOsobaDTO>(kontaktOsobaRepository.GetKontaktOsobaByID(pravnoLice.KontaktOsobaID));
						liceDTO.PravnoLice.KontaktOsoba = kontaktOsobaDTO;
					}
				}
				liceDTO.Adresa = adresaDTO;
				return Ok(liceDTO);
			}
			else
				return StatusCode(StatusCodes.Status500InternalServerError, "Adresa nije pronađena. ID adrese: " + adresaID.ToString() + ".");
		}

		/// <summary>
		/// Kreira novo lice.
		/// </summary>
		/// <param name="liceCreateDTO">DTO za kreiranje lica.</param>
		/// <param name="authorization">Autorizovan token.</param>
		/// <returns>Vraća potvrdu o kreiranom licu.</returns>
		/// <remarks>
		/// Primer zahteva za kreiranje novog lica. \
		/// POST /api/lica \
		/// { \
		///		"fizickoLiceID": "ef4cf6d4-48f9-4508-a91f-330261325403", \
		///		"pravnoLiceID": "006d992e-2109-4334-beff-3f5229129d14", \
		///		"adresaID": "ACCAD5A2-E5BC-4FF5-A5B7-FC38AB8A47FE", \
		///		"telefon1": "1234567891", \
		///		"telefon2": "1234567891", \
		///		"email": "rakic.it19.2019@uns.ac.rs", \
		///		"brojRacuna": "12345678911234567891" \
		/// }
		/// </remarks>
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
								Guid adresaID = Guid.Parse(liceCreateDTO.AdresaID);
								AdresaDTO? adresaDTO = adresaService.GetAdresaByIDAsync(adresaID, authorization).Result;
								if (adresaDTO != null)
								{
									LiceDTO liceDTO = liceRepository.CreateLice(liceCreateDTO);
									liceRepository.SaveChanges();

									liceDTO.FizickoLice = mapper.Map<FizickoLiceDTO>(fizickoLiceRepository.GetFizickoLiceByID(Guid.Parse(liceCreateDTO.FizickoLiceID)));
									if (Guid.TryParse(liceCreateDTO.PravnoLiceID, out Guid pravnoLiceID))
									{
										PravnoLiceEntity? pravnoLice = pravnoLiceRepository.GetPravnoLiceByID(pravnoLiceID);
										if (pravnoLice != null)
										{
											liceDTO.PravnoLice = mapper.Map<PravnoLiceDTO>(pravnoLice);
											KontaktOsobaDTO kontaktOsobaDTO = mapper.Map<KontaktOsobaDTO>(kontaktOsobaRepository.GetKontaktOsobaByID(pravnoLice.KontaktOsobaID));
											liceDTO.PravnoLice.KontaktOsoba = kontaktOsobaDTO;
										}
										else
											return StatusCode(StatusCodes.Status422UnprocessableEntity, "Već postoji zadati broj računa lica.");
									}
									liceDTO.Adresa = adresaDTO;

									string? location = linkGenerator.GetPathByAction("GetLice", "Lice", new { liceID = liceDTO.ID });

									if (location != null)
										return Created(location, liceDTO);
									else
										return Created(string.Empty, liceDTO);
								}
								else
									return StatusCode(StatusCodes.Status500InternalServerError, "Adresa nije pronađena. ID adrese: " + adresaID.ToString() + ".");
							}
							else
								return StatusCode(StatusCodes.Status422UnprocessableEntity, "Već postoji zadati broj računa lica.");
						}
						else if (lica.Find(e => e.Telefon1 == liceCreateDTO.Telefon2) == null &&
							lica.Find(e => e.Telefon2 == liceCreateDTO.Telefon2) == null)
						{
							if (lica.Find(e => e.BrojRacuna == liceCreateDTO.BrojRacuna) == null)
							{
								Guid adresaID = Guid.Parse(liceCreateDTO.AdresaID);
								AdresaDTO? adresaDTO = adresaService.GetAdresaByIDAsync(adresaID, authorization).Result;
								if (adresaDTO != null)
								{
									LiceDTO liceDTO = liceRepository.CreateLice(liceCreateDTO);
									liceRepository.SaveChanges();

									liceDTO.FizickoLice = mapper.Map<FizickoLiceDTO>(fizickoLiceRepository.GetFizickoLiceByID(Guid.Parse(liceCreateDTO.FizickoLiceID)));
									if (Guid.TryParse(liceCreateDTO.PravnoLiceID, out Guid pravnoLiceID))
									{
										PravnoLiceEntity? pravnoLice = pravnoLiceRepository.GetPravnoLiceByID(pravnoLiceID);
										if (pravnoLice != null)
										{
											liceDTO.PravnoLice = mapper.Map<PravnoLiceDTO>(pravnoLice);
											KontaktOsobaDTO kontaktOsobaDTO = mapper.Map<KontaktOsobaDTO>(kontaktOsobaRepository.GetKontaktOsobaByID(pravnoLice.KontaktOsobaID));
											liceDTO.PravnoLice.KontaktOsoba = kontaktOsobaDTO;
										}
									}
									liceDTO.Adresa = adresaDTO;

									string? location = linkGenerator.GetPathByAction("GetLice", "Lice", new { liceID = liceDTO.ID });

									if (location != null)
										return Created(location, liceDTO);
									else
										return Created(string.Empty, liceDTO);
								}
								else
									return StatusCode(StatusCodes.Status500InternalServerError, "Adresa nije pronađena. ID adrese: " + adresaID.ToString() + ".");
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
		/// <remarks>
		/// Primer zahteva za ažuriranje postojećeg lica. \
		/// PUT /api/lica \
		/// { \
		///		"id": "f127642e-4d73-42f1-979d-6a506aea9bdc", \
		///		"fizickoLiceID": "ef4cf6d4-48f9-4508-a91f-330261325403", \
		///		"pravnoLiceID": "006d992e-2109-4334-beff-3f5229129d14", \
		///		"adresaID": "ACCAD5A2-E5BC-4FF5-A5B7-FC38AB8A47FE", \
		///		"telefon1": "1234567891", \
		///		"telefon2": "1234567891", \
		///		"email": "rakic.it19.2019@uns.ac.rs", \
		///		"brojRacuna": "12345678911234567891" \
		/// }
		/// </remarks>
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
								Guid adresaID = Guid.Parse(liceUpdateDTO.AdresaID);
								AdresaDTO? adresaDTO = adresaService.GetAdresaByIDAsync(adresaID, authorization).Result;
								if (adresaDTO != null)
								{
									LiceEntity lice = mapper.Map<LiceEntity>(liceUpdateDTO);
									mapper.Map(lice, oldLice);
									liceRepository.SaveChanges();
									LiceDTO liceDTO = mapper.Map<LiceDTO>(oldLice);

									liceDTO.FizickoLice = mapper.Map<FizickoLiceDTO>(fizickoLiceRepository.GetFizickoLiceByID(Guid.Parse(liceUpdateDTO.FizickoLiceID)));
									if (Guid.TryParse(liceUpdateDTO.PravnoLiceID, out Guid pravnoLiceID))
									{
										PravnoLiceEntity? pravnoLice = pravnoLiceRepository.GetPravnoLiceByID(pravnoLiceID);
										if (pravnoLice != null)
										{
											liceDTO.PravnoLice = mapper.Map<PravnoLiceDTO>(pravnoLice);
											KontaktOsobaDTO kontaktOsobaDTO = mapper.Map<KontaktOsobaDTO>(kontaktOsobaRepository.GetKontaktOsobaByID(pravnoLice.KontaktOsobaID));
											liceDTO.PravnoLice.KontaktOsoba = kontaktOsobaDTO;
										}
									}

									liceDTO.Adresa = adresaDTO;
									return Ok(liceDTO);
								}
								else
									return StatusCode(StatusCodes.Status500InternalServerError, "Adresa nije pronađena. ID adrese: " + adresaID.ToString() + ".");
							}
							else
								return StatusCode(StatusCodes.Status422UnprocessableEntity, "Već postoji zadati broj računa lica.");
						}
						else if (lica.Find(e => e.Telefon1 == liceUpdateDTO.Telefon2) == null &&
							lica.Find(e => e.Telefon2 == liceUpdateDTO.Telefon2) == null)
						{
							if (lica.Find(e => e.BrojRacuna == liceUpdateDTO.BrojRacuna) == null)
							{
								Guid adresaID = Guid.Parse(liceUpdateDTO.AdresaID);
								AdresaDTO? adresaDTO = adresaService.GetAdresaByIDAsync(adresaID, authorization).Result;
								if (adresaDTO != null)
								{
									LiceEntity lice = mapper.Map<LiceEntity>(liceUpdateDTO);
									mapper.Map(lice, oldLice);
									liceRepository.SaveChanges();
									LiceDTO liceDTO = mapper.Map<LiceDTO>(oldLice);

									liceDTO.FizickoLice = mapper.Map<FizickoLiceDTO>(fizickoLiceRepository.GetFizickoLiceByID(Guid.Parse(liceUpdateDTO.FizickoLiceID)));
									if (Guid.TryParse(liceUpdateDTO.PravnoLiceID, out Guid pravnoLiceID))
									{
										PravnoLiceEntity? pravnoLice = pravnoLiceRepository.GetPravnoLiceByID(pravnoLiceID);
										if (pravnoLice != null)
										{
											liceDTO.PravnoLice = mapper.Map<PravnoLiceDTO>(pravnoLice);
											KontaktOsobaDTO kontaktOsobaDTO = mapper.Map<KontaktOsobaDTO>(kontaktOsobaRepository.GetKontaktOsobaByID(pravnoLice.KontaktOsobaID));
											liceDTO.PravnoLice.KontaktOsoba = kontaktOsobaDTO;
										}
									}

									liceDTO.Adresa = adresaDTO;
									return Ok(liceDTO);
								}
								else
									return StatusCode(StatusCodes.Status500InternalServerError, "Adresa nije pronađena. ID adrese: " + adresaID.ToString() + ".");
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
		/// <returns>Vraća potvrdu o brisanju lica.</returns>
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
		/// Vraća opcije za rad sa entitetom lica.
		/// </summary>
		/// <returns>Vraća prazan 200 HTTP kod.</returns>
		/// <response code="200">Vraća prazan 200 HTTP kod.</response>
		[HttpOptions]
		[AllowAnonymous]
		public IActionResult GetLicaOptions()
		{
			Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
			return Ok();
		}
	}
}
