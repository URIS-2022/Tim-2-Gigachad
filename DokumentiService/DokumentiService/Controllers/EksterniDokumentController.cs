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
    [Authorize]
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
        /// <summary>
        /// Vraća listu svih eksternih dokumenata.
        /// </summary>
        /// <returns>Vraća potvrdu o listu postojećih eksternih dokumenata.</returns>
        /// <response code="200">Vraća listu delova parcela.</response>
        /// <response code="204">Ne postoje delovi parcela.</response>
        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<EksterniDokumentDTO>> GetEksterniDokumenti()
        {
            var eksdok = eksterniDokumentRepository.GetEksterniDokument();
            if (eksdok == null || eksdok.Count == 0)
                return NoContent();
            return Ok(mapper.Map<List<EksterniDokumentDTO>>(eksdok));
        }
        /// <summary>
        /// Get za eksterni Dokument sa zadatim ID
        /// </summary>
        /// <param name="eksterniDokumentID"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Delete za ekterni Dokument sa zadatim ID
        /// </summary>
        /// <param name="eksterniDokumentID"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Menja dokument .
        /// </summary>
        /// <param name="eksterniDokumentCreateDTO">DTO za DOKUMENT.</param>
        /// <param name="authorization">Autorizovan token.</param>
        /// <returns>Vraća potvrdu o menjanom dokumentu.</returns>
        /// <remarks>
        /// Primer zahteva za menjanje dokumenta. \
        /// POST /api/eksterniDokument \
        /// { 
        ///	"PutanjaDokumenta" : "Hellou226542"
        /// }
        /// </remarks>
        /// <response code="201">Vraća menjani dokument.</response>
        /// <response code="500">Došlo je do greške na serveru prilikom menjanja dokumenta </response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EksterniDokumentCreateDTO> CreateEksterniDokument([FromBody] EksterniDokumentCreateDTO eksterniDokumentCreateDTO)
        {
            try
            {
                EksterniDokumentDTO eksterniDokument = eksterniDokumentRepository.CreateEksterniDokument(eksterniDokumentCreateDTO);
                eksterniDokumentRepository.SaveChanges();

                string? location = linkGenerator.GetPathByAction("GetEksterniDokument", "EksterniDokument", new { eksterniDokumentID = eksterniDokument.EksterniDokumentID });

                if (location != null)
                    return Created(location, eksterniDokument);
                else
                    return Created("", eksterniDokument);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
        /// <summary>
        /// Menja dokument .
        /// </summary>
        /// <param name="eksterniDokumentUpdateDTO">DTO za DOKUMENT.</param>
        /// <returns>Vraća potvrdu o menjanom eksternom dokumentu.</returns>
        /// <remarks>
        /// Primer zahteva za menjanje eksternog dokumenta. \
        /// PUT /api/eksterniDokument \
        /// { 
        ///	"PutanjaDokumenta" : "Hellou226542"
        /// }
        /// </remarks>
        /// <response code="201">Vraća menjani dokument.</response>
        /// <response code="500">Došlo je do greške na serveru prilikom menjanja dokumenta </response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<EksterniDokumentDTO> UpdateEksterniDokument(EksterniDokumentUpdateDTO eksterniDokumentUpdateDTO)
        {
            try
            {
                EksterniDokumentEntity? eksterniDokument = eksterniDokumentRepository.GetEksterniDokumentID(Guid.Parse(eksterniDokumentUpdateDTO.EksterniDokumentID));
                if (eksterniDokument == null)
                    return NotFound();
                EksterniDokumentEntity eksdok = mapper.Map<EksterniDokumentEntity>(eksterniDokumentUpdateDTO);
                mapper.Map(eksdok, eksterniDokument);
                eksterniDokumentRepository.SaveChanges();
                return Ok(mapper.Map<EksterniDokumentDTO>(eksterniDokument));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }



    }
}