using AdresaService.Data;
using AdresaService.DTO;
using AdresaService.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdresaService.Controllers
{
    /// <summary>
	/// Kontroler za entitet adresa.
	/// </summary>
    [Authorize]
    [ApiController]
    [Route("api/adrese")]
    [Produces("application/json", "application/xml")]
    public class AdresaController : ControllerBase
    {
        private readonly IAdresaRepository adresaRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        /// <summary>
		/// Dependency injection za Adresa kontroler.
		/// </summary>
        public AdresaController(IAdresaRepository adresaRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.adresaRepository = adresaRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        /// <summary>
		/// Vraća listu svih adresa.
		/// </summary>
		/// <returns>Vraća potvrdu o listi postojećih adresa.</returns>
		/// <response code="200">Vraća listu adresa.</response>
		/// <response code="204">Ne postoje adresa.</response>
        [HttpHead]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<AdresaEntity>> GetAdrese()
        {
            List<AdresaEntity> adrese = adresaRepository.GetAdrese();
            if (adrese == null || adrese.Count == 0)
                return NoContent();
            return Ok(mapper.Map<List<AdresaDTO>>(adrese));
        }

        /// <summary>
		/// Vraća adresu na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="adresaID">ID adrese.</param>
		/// <returns>Vraća potvrdu o specifiranoj adresi.</returns>
		/// <response code="200">Vraća specifiranu adresu.</response>
		/// <response code="404">Specifirana adresa ne postoji.</response>
        [HttpGet("{adresaID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AdresaDTO> GetAdresa(Guid adresaID)
        {
            var adresa = adresaRepository.GetAdresaByID(adresaID);
            if (adresa == null)
                return NotFound();
            return Ok(mapper.Map<AdresaDTO>(adresa));
        }

        /// <summary>
        /// Kreira novu adresu.
        /// </summary>
        /// <param name="adresaCreateDTO">DTO za kreiranje adrese.</param>
        /// <returns>Potvrdu o kreiranoj adresi.</returns>
        /// <remarks>
		/// Primer zahteva za kreiranje nove adrese. \
		/// POST /api/adrese \
		/// { \
		///		"id": "abcd6g99-36a6-4688-af14-6b2bba85dcf1", \
		///		"ulica": "Test Ulica", \
        ///		"broj": 12, \
		///		"mesto": "Malo Crnice", \
        ///		"postanskiBroj": 707 \
        ///		"drzava": "Srbija"  \
		/// }
		/// </remarks>
        /// <response code="201">Vraća kreiranu adresu.</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja adrese.</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<AdresaCreateDTO> CreateAdresa([FromBody] AdresaCreateDTO adresaCreateDTO)
        {
            try
            {
                AdresaDTO adresa = adresaRepository.CreateAdresa(adresaCreateDTO);
                adresaRepository.SaveChanges();

                string? location = linkGenerator.GetPathByAction("GetAdresa", "Adresa", new { adresaID = adresa.ID });

                if (location != null)
                    return Created(location, adresa);
                else
                    return Created("", adresa);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Azurira jednu adresu.
        /// </summary>
        /// <param name="AdresaUpdateDTO">DTO za azuriranje adrese.</param>
        /// <returns>Vraca potvrdu o azuriranoj adresi.</returns>
        /// <remarks>
		/// Primer zahteva za azuriranje postojece licitacije. \
        /// PUT /api/adrese \
		/// { \
		///		"id": "abcd6g99-36a6-4688-af14-6b2bba85dcf1",
        ///		"ulica": "Test Ulica Izmenjena", \
        ///		"broj": 12, \
		///		"mesto": "Malo Crnice", \
        ///		"postanskiBroj": 707 \
        ///		"drzava": "Srbija"  \
		/// }
        /// </remarks>
        /// <response code="200">Vraca azuriranu adresu.</response>
        /// <response code="404">Specifirana adresa ne postoji.</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja adrese.</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<AdresaDTO> UpdateAdresa(AdresaUpdateDTO AdresaUpdateDTO)
        {
            try
            {
                AdresaEntity? oldAdresa = adresaRepository.GetAdresaByID(AdresaUpdateDTO.ID);
                if (oldAdresa == null)
                    return NotFound();
                AdresaEntity adresa = mapper.Map<AdresaEntity>(AdresaUpdateDTO);
                mapper.Map(adresa, oldAdresa);
                adresaRepository.SaveChanges();
                return Ok(mapper.Map<AdresaDTO>(oldAdresa));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Briše jednu adresu na osnovu zadatog ID-ja.
        /// </summary>
        /// <param name="adresaID">ID adrese.</param>
        /// <returns>Potvrdu o brisanju adrese.</returns>
        /// <response code="204">Specifirana adresa je uspešno obrisana.</response>
        /// <response code="404">Specifirana adresa ne postoji.</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja specifiranoe adrese.</response>
        [HttpDelete("{adresaID}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteAdresa(Guid adresaID)
        {
            try
            {
                AdresaEntity? adresa = adresaRepository.GetAdresaByID(adresaID);

                if (adresa == null)
                    return NotFound();

                adresaRepository.DeleteAdresa(adresaID);
                adresaRepository.SaveChanges();

                return NoContent();
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Vraća opcije za rad sa adresama.
        /// </summary>
        /// <returns>Vraća prazan 200 HTTP kod.</returns>
        /// <response code="200">Vraća prazan 200 HTTP kod.</response>
        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetAdreseOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }
    }
}
