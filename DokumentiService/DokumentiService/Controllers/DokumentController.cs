using AutoMapper;
using DokumentiService.Data;
using DokumentiService.DTO;
using DokumentiService.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace DokumentiService.Controllers
{
    /// <summary>
    /// Kontroler za entitete eksternih dokumenata.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/Dokumenti")]
    [Produces("application/json", "application/xml")]
    public class DokumentController : ControllerBase
    {
        private readonly IDokumentRepository DokumentRepository;
        private readonly IInterniDokumentRepository interniDokumentRepository;
        private readonly IEksterniDokumentRepository eksterniDokumentRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        /// <summary>
        /// Dependency injection za kontroler preko konstruktora.
        /// </summary>
        public DokumentController(IDokumentRepository DokumentRepository, IInterniDokumentRepository interniDokumentRepository, IEksterniDokumentRepository eksterniDokumentRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.DokumentRepository = DokumentRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.interniDokumentRepository = interniDokumentRepository;
            this.eksterniDokumentRepository = eksterniDokumentRepository;
        }
        /// <summary>
        /// GET za sva dokumenta
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<DokumentDTO>> GetDokumenti()
        {
            List<DokumentEntity> dokumenta = DokumentRepository.GetDokument();
            if (dokumenta == null || dokumenta.Count == 0)
                return NoContent();

            List<DokumentDTO> dokumentaDTO = new();
            foreach (DokumentEntity dokument in dokumenta)
            {
                DokumentDTO dokumentDTO = mapper.Map<DokumentDTO>(dokument);
                dokumentDTO.InterniDokument = mapper.Map<InterniDokumentDTO>(interniDokumentRepository.GetInterniDokumentID(dokument.InterniDokumentID));
                dokumentDTO.EksterniDokument = mapper.Map<EksterniDokumentDTO>(eksterniDokumentRepository.GetEksterniDokumentID(dokument.EksterniDokumentID));
                dokumentaDTO.Add(dokumentDTO);
            }

            return Ok(dokumentaDTO);
        }

        /// <summary>
        /// Get za dokument sa zadatim ID
        /// </summary>
        /// <param name="DokumentID"></param>
        /// <returns></returns>
        [HttpGet("{DokumentID}")]
        //[HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<DokumentDTO> GetDokument(Guid DokumentID)
        {
            DokumentEntity? dokument = DokumentRepository.GetDokumentID(DokumentID);
            if(dokument == null)
            {
                return NotFound();
            }
            DokumentDTO dokumentDTO = mapper.Map<DokumentDTO>(dokument);
            dokumentDTO.EksterniDokument = mapper.Map<EksterniDokumentDTO>(eksterniDokumentRepository.GetEksterniDokumentID(dokument.EksterniDokumentID));
            dokumentDTO.InterniDokument = mapper.Map<InterniDokumentDTO>(interniDokumentRepository.GetInterniDokumentID(dokument.InterniDokumentID));

            return Ok(dokumentDTO);
        }
        /// <summary>
        /// Delete za dokument sa zadatim ID
        /// </summary>
        /// <param name="DokumentID"></param>
        /// <returns></returns>
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
		/// Kreira novi dokument parcele.
		/// </summary>
		/// <param name="DokumentCreateDTO">DTO za eksterni DOKUMENT.</param>
		/// <returns>Vraća potvrdu o kreiranom  eksternom dokumentu.</returns>
		/// <remarks>
		/// Primer zahteva za kreiranje novog eksternog dokumenta. \
		/// POST /api/Dokument \
		/// { 
		///	     "eksterniDokumentID": "36701e85-41ac-410e-8889-1cc1423c3b3a",\
        ///      "interniDokumentID": "858930f0-92ec-4975-b697-0c7afb2842de",\
        ///      "datumDonosenja": "2012-09-20T00:00:00",\
        ///      "sablon": "11",\
        ///      "statusDokumenta": "33"\
		/// }
		/// </remarks>
		/// <response code="201">Vraća kreirani eksterni dokument.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom kreiranja dela parcele.</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<DokumentCreateDTO> CreateDokument([FromBody] DokumentCreateDTO DokumentCreateDTO)
        {
            try
            {
                
                    DokumentDTO dokumentDTO = DokumentRepository.CreateDokument(DokumentCreateDTO);
                    DokumentRepository.SaveChanges();
                    dokumentDTO.EksterniDokument = mapper.Map<EksterniDokumentDTO>(eksterniDokumentRepository.GetEksterniDokumentID(Guid.Parse(DokumentCreateDTO.EksterniDokumentID)));
                    dokumentDTO.InterniDokument = mapper.Map<InterniDokumentDTO>(interniDokumentRepository.GetInterniDokumentID(Guid.Parse(DokumentCreateDTO.InterniDokumentID)));
                    
                    string? location = linkGenerator.GetPathByAction("GetDokument", "Dokument", new { DokumentID = dokumentDTO.DokumentID });

                    if (location != null)
                        return Created(location, dokumentDTO);
                    else
                        return Created(string.Empty, dokumentDTO);
                
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
        /// <summary>
		/// Menja dokument .
		/// </summary>
		/// <param name="DokumentUpdateDTO">DTO za DOKUMENT.</param>
		/// <returns>Vraća potvrdu o menjanom dokumentu.</returns>
		/// <remarks>
		/// Primer zahteva za menjanje dokumenta. \
		/// PUT /api/Dokument \
		/// { 
		///		"eksterniDokumentID": "36701e85-41ac-410e-8889-1cc1423c3b3a",\
		///		"interniDokumentID": "858930f0-92ec-4975-b697-0c7afb2842de",\
		///		"datumDonosenja": "2012-09-20T00:00:00",\
		///		"sablon": "11",\
		///		"statusDokumenta": "33"\
		/// }
		/// </remarks>
		/// <response code="201">Vraća menjani dokument.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom menjanja dokumenta </response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<DokumentDTO> UpdateDokument([FromBody]DokumentUpdateDTO DokumentUpdateDTO)
        {
            try
            {
                DokumentEntity? oldDokument = DokumentRepository.GetDokumentID(DokumentUpdateDTO.DokumentID);
                if (oldDokument == null)
                    return NotFound();

                List<DokumentEntity> dokument = DokumentRepository.GetDokument();
                DokumentEntity? tempDokument = dokument.Find(e => e.DokumentID == DokumentUpdateDTO.DokumentID);
                if (tempDokument != null)
                    dokument.Remove(tempDokument);
                
                DokumentEntity Dokument = mapper.Map<DokumentEntity>(DokumentUpdateDTO);
                mapper.Map(Dokument, oldDokument);
                DokumentRepository.SaveChanges();

                DokumentDTO dokumentDTO = mapper.Map<DokumentDTO>(oldDokument);
                dokumentDTO.EksterniDokument = mapper.Map<EksterniDokumentDTO>(eksterniDokumentRepository.GetEksterniDokumentID(oldDokument.EksterniDokumentID));
                dokumentDTO.InterniDokument = mapper.Map<InterniDokumentDTO>(interniDokumentRepository.GetInterniDokumentID(oldDokument.InterniDokumentID));
                return Ok(dokumentDTO);
                
                
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

    }
}