using AutoMapper;
using JavnoNadmetanjeService.DTO;
using JavnoNadmetanjeService.Entities;
using LicitacijaService.Data;
using Microsoft.AspNetCore.Mvc;

namespace JavnoNadmetanjeService.Controllers
{
    /// <summary>
	/// Kontroler za entitet licitacija.
	/// </summary>
    /// [Authorize]
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
		/// <returns>Vraća potvrdu o listi postojećih licitacija.</returns>
		/// <response code="200">Vraća listu licitacija.</response>
		/// <response code="204">Ne postoje licitacija.</response>
        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<LicitacijaEntity>> GetLicitacije()
        {
            List<LicitacijaEntity> licitacije = licitacijaRepository.GetLicitacije();
            if (licitacije == null || licitacije.Count == 0)
                return NoContent();
            return Ok(mapper.Map<List<LicitacijaDTO>>(licitacije));
        }
    }
}
