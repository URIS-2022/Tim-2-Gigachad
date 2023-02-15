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


        [HttpGet("{DokumentID}")]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<DokumentDTO> GetDokument(Guid DokumentID)
        {
            var Dokument = DokumentRepository.GetDokumentID(DokumentID);
            if (Dokument == null)
                return NotFound();
            return Ok(mapper.Map<DokumentDTO>(Dokument));
        }

        [HttpDelete("{DokumentID}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteDokument(Guid DokumentID)
        {
            try
            {
                DokumentEntity? Dokument = DokumentRepository.GetDokumentID(DokumentID);

                if (Dokument == null)
                    return NotFound();

                DokumentRepository.DeleteDokument(DokumentID);
                DokumentRepository.SaveChanges();

                return NoContent();
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
    }
}