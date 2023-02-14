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
    [Route("api/eksterniDokumenti")]
    [Produces("application/json", "application/xml")]
    public class EksterniDokumentController : ControllerBase
    {
        private readonly IEksterniDokumentRepository eksterniDokumentRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        /// <summary>
        /// Dependency injection za kontroler preko konstruktora.
        /// </summary>
        public EksterniDokumentController(IEksterniDokumentRepository eksterniDokumentRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.eksterniDokumentRepository = eksterniDokumentRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<EksterniDokumentEntity>> GetEksterniDokumenti()
        {
            var eksdok = eksterniDokumentRepository.GetEksterniDokument();
            if (eksdok == null || eksdok.Count == 0)
                return NoContent();
            return Ok(mapper.Map<List<EksterniDokumentEntity>>(eksdok));
        }
    }
}