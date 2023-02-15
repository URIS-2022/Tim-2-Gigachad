using AutoMapper;
using DokumentiService.Data;
using DokumentiService.DTO;
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

        [HttpGet("{eksterniDokumentID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<EksterniDokumentDTO> GetEksterniDokument(Guid eksterniDokumentID)
        {
            var eksterniDokument = eksterniDokumentRepository.GetEksterniDokumentID(eksterniDokumentID);
            if (eksterniDokument == null)
                return NotFound();
            return Ok(mapper.Map<EksterniDokumentEntity>(eksterniDokument));
        }

        [HttpDelete("{eksterniDokumentID}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult DeleteEksterniDokument(Guid eksterniDokumentID)
        {
            try
            {
                EksterniDokumentEntity? eksterniDokument = eksterniDokumentRepository.GetEksterniDokumentID(eksterniDokumentID);

                if (eksterniDokument == null)
                    return NotFound();

                eksterniDokumentRepository.DeleteEksterniDokument(eksterniDokumentID);
                eksterniDokumentRepository.SaveChanges();

                return NoContent();
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }


    }
}