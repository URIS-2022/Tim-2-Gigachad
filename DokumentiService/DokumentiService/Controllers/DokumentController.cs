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
        /// <summary>
        /// Kreira novi  doument.
        /// </summary>
        /// <param name="DokumentCreateDTO">DTO za kreiranje dokumenta.</param>
        /// <returns>Potvrdu o kreiranom dokumentu.</returns>
        /// <response code="201">Vraća kreiran dokument.</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja dokumenta.</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<DokumentCreateDTO> CreateDokument([FromBody] DokumentCreateDTO DokumentCreateDTO)
        {
            try
            {
                DokumentDTO Dokument = DokumentRepository.CreateDokument(DokumentCreateDTO);
                DokumentRepository.SaveChanges();

                string? location = linkGenerator.GetPathByAction("GetDokument", "Dokument", new { DokumentID = Dokument.DokumentID });

                if (location != null)
                    return Created(location, Dokument);
                else
                    return Created("", Dokument);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<DokumentDTO> UpdateDokument(DokumentUpdateDTO DokumentUpdateDTO)
        {
            try
            {
                DokumentEntity? Dokument = DokumentRepository.GetDokumentID(DokumentUpdateDTO.DokumentID);
                if (Dokument == null)
                    return NotFound();
                DokumentEntity dok = mapper.Map<DokumentEntity>(DokumentUpdateDTO);
                mapper.Map(dok, Dokument);
                DokumentRepository.SaveChanges();
                return Ok(mapper.Map<DokumentDTO>(Dokument));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

    }
}