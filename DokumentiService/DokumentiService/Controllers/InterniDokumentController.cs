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
    [Route("api/interniDokumenti")]
    [Produces("application/json", "application/xml")]
    public class InterniDokumentController : ControllerBase
    {
        private readonly IInterniDokumentRepository interniDokumentRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        /// <summary>
        /// Dependency injection za kontroler preko konstruktora.
        /// </summary>
        public InterniDokumentController(IInterniDokumentRepository interniDokumentRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.interniDokumentRepository = interniDokumentRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<EksterniDokumentEntity>> GetInterniDokumenti()
        {
            var intdok = interniDokumentRepository.GetInterniDokument();
            if (intdok == null || intdok.Count == 0)
                return NoContent();
            return Ok(mapper.Map<List<InterniDokumentEntity>>(intdok));
        }

        [HttpGet("{interniDokumentID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<InterniDokumentDTO> GetInterniDokument(Guid interniDokumentID)
        {
            var interniDokument = interniDokumentRepository.GetInterniDokumentID(interniDokumentID);
            if (interniDokument == null)
                return NotFound();
            return Ok(mapper.Map<InterniDokumentEntity>(interniDokument));
        }

        [HttpDelete("{interniDokumentID}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteInterniDokument(Guid interniDokumentID)
        {
            try
            {
                InterniDokumentEntity? interniDokument = interniDokumentRepository.GetInterniDokumentID(interniDokumentID);

                if (interniDokument == null)
                    return NotFound();

                interniDokumentRepository.DeleteInterniDokument(interniDokumentID);
                interniDokumentRepository.SaveChanges();

                return NoContent();
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<InterniDokumentCreateDTO> CreateInterniiDokument([FromBody] InterniDokumentCreateDTO interniDokumentCreateDTO)
        {
            try
            {
                InterniDokumentDTO interniDokument = interniDokumentRepository.CreateInterniDokument(interniDokumentCreateDTO);
                interniDokumentRepository.SaveChanges();

                string? location = linkGenerator.GetPathByAction("GetInterniDokument", "InterniDokument", new { interniDokumentID = interniDokument.InterniDokumentID });

                if (location != null)
                    return Created(location, interniDokument);
                else
                    return Created("", interniDokument);
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
        public ActionResult<InterniDokumentDTO> UpdateInterniDokument(InterniDokumentUpdateDTO interniDokumentUpdateDTO)
        {
            try
            {
                InterniDokumentEntity? interniDokument = interniDokumentRepository.GetInterniDokumentID(interniDokumentUpdateDTO.InterniDokumentID);
                if (interniDokument == null)
                    return NotFound();
                InterniDokumentEntity intdok = mapper.Map<InterniDokumentEntity>(interniDokumentUpdateDTO);
                mapper.Map(intdok, interniDokument);
                interniDokumentRepository.SaveChanges();
                return Ok(mapper.Map<InterniDokumentDTO>(interniDokument));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
    }
}

