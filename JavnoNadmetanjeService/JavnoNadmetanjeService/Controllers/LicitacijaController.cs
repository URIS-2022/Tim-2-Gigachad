using AutoMapper;
using JavnoNadmetanjeService.DTO;
using JavnoNadmetanjeService.Entities;
using LicitacijaService.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JavnoNadmetanjeService.Controllers
{
    /// <summary>
	/// Kontroler za entitet licitacija.
	/// </summary>
    [Authorize]
    [ApiController]
    [Route("api/licitacije")]
    [Produces("application/json", "application/xml")]
    public class LicitacijaController : ControllerBase
    {
        private readonly ILicitacijaRepository licitacijaRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        /// <summary>
		/// Dependency injection za Licitacija kontroler.
		/// </summary>
        public LicitacijaController(ILicitacijaRepository licitacijaRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.licitacijaRepository = licitacijaRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        /// <summary>
		/// Vraća listu svih licitacija.
		/// </summary>
		/// <returns>Vraca potvrdu o listi postojecih licitacija.</returns>
		/// <response code="200">Vraca listu licitacija.</response>
		/// <response code="204">Ne postoje licitacija.</response>
        [HttpHead]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<LicitacijaDTO>> GetLicitacije()
        {
            var licitacije = licitacijaRepository.GetLicitacije();
            if (licitacije == null || licitacije.Count == 0)
                return NoContent();
            return Ok(mapper.Map<List<LicitacijaDTO>>(licitacije));
        }

        /// <summary>
		/// Vraca jednu licitaciju na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="licitacijaID">ID licitacije.</param>
		/// <returns>Vraca potvrdu o specifiranoj licitaciji.</returns>
		/// <response code="200">Vraca specifiranu licitaciju.</response>
		/// <response code="404">Specifirana licitacija ne postoji.</response>
		[HttpGet("{licitacijaID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<LicitacijaDTO> GetLicitacija(Guid licitacijaID)
        {
            LicitacijaEntity? licitacija = licitacijaRepository.GetLicitacijaByID(licitacijaID);
            if (licitacija == null)
                return NotFound();
            return Ok(mapper.Map<LicitacijaDTO>(licitacija));
        }

        /// <summary>
		/// Kreira novo licitaciju.
		/// </summary>
		/// <param name="licitacijaCreateDTO">DTO za kreiranje licitacije.</param>
		/// <returns>Vraca potvrdu o kreiranoj licitaciji.</returns>
        /// <remarks>
		/// Primer zahteva za kreiranje nove licitacije. \
		/// POST /api/licitacije \
		/// { \
		///		"datumLicitacije": "1999-02-26T00:00:00", \
		///		"rok": "2023-02-18T00:00:00", \
		///		"ogrnMaxPovrs": "13", \
        ///		"korakCene": "15" \
		/// }
		/// </remarks>
		/// <response code="201">Vraca kreiranu licitaciju.</response>
		/// <response code="500">Doslo je do greske na serveru prilikom kreiranja licitacije.</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<LicitacijaCreateDTO> CreateLicitacija([FromBody] LicitacijaCreateDTO licitacijaCreateDTO)
        {
            try
            {
                LicitacijaDTO licitacija = licitacijaRepository.CreateLicitacija(licitacijaCreateDTO);
                licitacijaRepository.SaveChanges();

                string? location = linkGenerator.GetPathByAction("GetLicitacija", "Licitacija", new { licitacijaID = licitacija.ID });

                if (location != null)
                    return Created(location, licitacija);
                else
                    return Created("", licitacija);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Azurira jednu licitaciju.
        /// </summary>
        /// <param name="LicitacijaUpdateDTO">DTO za azuriranje licitacije.</param>
        /// <returns>Vraca potvrdu o azuriranoj licitaciji.</returns>
        /// <remarks>
		/// Primer zahteva za azuriranje postojece licitacije. \
        /// PUT /api/licitacije \
		/// { \
		///		"id": "",
        ///     "datumLicitacije": "1999-02-27T00:00:00", \
		///		"rok": "2023-02-17T00:00:00", \
		///		"ogrnMaxPovrs": "77", \
        ///		"korakCene": "25" \
		/// }
        /// </remarks>
        /// <response code="200">Vraca azuriranu licitaciju.</response>
        /// <response code="404">Specifirana licitacija ne postoji.</response>
        /// <response code="500">Doslo je do greske na serveru prilikom azuriranja licitacije.</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<LicitacijaDTO> UpdateLicitacija(LicitacijaUpdateDTO LicitacijaUpdateDTO)
        {
            try
            {
                LicitacijaEntity? oldLicitacija = licitacijaRepository.GetLicitacijaByID(LicitacijaUpdateDTO.ID);
                if (oldLicitacija == null)
                    return NotFound();
                LicitacijaEntity licitacija = mapper.Map<LicitacijaEntity>(LicitacijaUpdateDTO);
                mapper.Map(licitacija, oldLicitacija);
                licitacijaRepository.SaveChanges();
                return Ok(mapper.Map<LicitacijaDTO>(oldLicitacija));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Brise jednu licitaciju na osnovu zadatog ID-ja.
        /// </summary>
        /// <param name="licitacijaID">ID licitacije.</param>
        /// <returns>Vraca potvrdu o brisanju licitacije.</returns>
        /// <response code="204">Specifirana licitacija je uspesno obrisana.</response>
        /// <response code="404">Specifirana licitacija ne postoji.</response>
        /// <response code="500">Doslo je do greske na serveru prilikom brisanja specifiranoe licitacije.</response>
        [HttpDelete("{licitacijaID}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteLicitacija(Guid licitacijaID)
        {
            try
            {
                LicitacijaEntity? licitacija = licitacijaRepository.GetLicitacijaByID(licitacijaID);

                if (licitacija == null)
                    return NotFound();

                licitacijaRepository.DeleteLicitacija(licitacijaID);
                licitacijaRepository.SaveChanges();

                return NoContent();
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Vraca opcije za rad sa licitacijama.
        /// </summary>
        /// <returns>Vraca prazan 200 HTTP kod.</returns>
        /// <response code="200">Vraca prazan 200 HTTP kod.</response>
        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetAdreseOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }
    }
}
