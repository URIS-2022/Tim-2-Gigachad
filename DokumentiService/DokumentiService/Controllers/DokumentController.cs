using AutoMapper;
using DokumentiService.Data;
using DokumentiService.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DokumentiService.Controllers
{
    /// <summary>
    /// Kontroler za entitete eksternih dokumenata.
    /// </summary>
    //[Authorize]
    [ApiController]
    [Route("api/Dokumenti")]
    [Produces("application/json", "application/xml")]
    public class DokumentController : ControllerBase
    {
        private readonly IDokumentRepository DokumentRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        /// <summary>
        /// Dependency injection za kontroler preko konstruktora.
        /// </summary>
        public DokumentController(IDokumentRepository DokumentRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.DokumentRepository = DokumentRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<DokumentEntity>> GetDokumenti()
        {
            var dok = DokumentRepository.GetDokument();
            if (dok == null || dok.Count == 0)
                return NoContent();
            return Ok(mapper.Map<List<DokumentEntity>>(dok));
        }
    }
}