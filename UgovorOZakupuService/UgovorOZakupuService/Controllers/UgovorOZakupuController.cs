using AutoMapper;
using UgovorOZakupuService.Data;
using UgovorOZakupuService.DTO;
using UgovorOZakupuService.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UgovorOZakupuService.ServiceCalls;
using System.Net;

namespace UgovorOZakupuService.Controllers
{
    /// <summary>
    /// Kontroler za entitete eksternih dokumenata.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/ugovorOZakupu")]
    [Produces("application/json", "application/xml")]
    public class UgovorOZakupuController : ControllerBase
    {
        private readonly IUgovorOZakupuRepository ugovorOZakupuRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly IDokumentiService dokumentiService;
        private readonly IKupacService kupacService;
       // private readonly IDeoParceleService deoParceleService;
        /// <summary>
        /// Dependency injection za kontroler preko konstruktora.
        /// </summary>
        public UgovorOZakupuController(IUgovorOZakupuRepository ugovorOZakupuRepository, LinkGenerator linkGenerator, IMapper mapper, IDokumentiService dokumentiService, IKupacService kupacService /*IDeoParceleService deoParceleService*/)
        {
            this.ugovorOZakupuRepository = ugovorOZakupuRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.dokumentiService = dokumentiService;
            this.kupacService = kupacService;
            //this.deoParceleService = deoParceleService;
        }
        /// <summary>
        /// GET za sve ugovore o zakupu
        /// </summary>
        /// <returns></returns>
        [HttpHead]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<UgovorOZakupuDTO>> GetUgovorOZakupu([FromHeader] string authorization)
        {
            List<UgovorOZakupuEntity> ugovoriOZakupu = ugovorOZakupuRepository.GetUgovorOZakupu();
            if (ugovoriOZakupu == null || ugovoriOZakupu.Count == 0)
                return NoContent();

            List<UgovorOZakupuDTO>  ugovoriDTO = new();
            foreach (UgovorOZakupuEntity ugovor in ugovoriOZakupu)
            {
                Guid tempDokumentID = ugovor.DokumentID; ;
                DokumentDTO? dokument = dokumentiService.GetDokumentByIDAsync(tempDokumentID, authorization).Result;

                Guid temnpKupacID = ugovor.KupacID;
                KupacDTO? kupac = kupacService.GetKupacByIDAsync(temnpKupacID, authorization).Result;

              //  Guid tempDeoParceleID = ugovor.DeoParceleID;
               // DeoParceleDTO? deoParcele = deoParceleService.GetDeoParceleByIDAsync(tempDeoParceleID, authorization).Result;

                if (dokument != null && kupac != null /*&& deoParcele != null*/)
                {
                    UgovorOZakupuDTO ugovorOZakupuDTO = mapper.Map<UgovorOZakupuDTO>(ugovor);
                    ugovorOZakupuDTO.Dokument = dokument;
                    ugovorOZakupuDTO.Kupac = kupac;
                    //ugovorOZakupuDTO.DeoParcele = deoParcele;
                    ugovoriDTO.Add(ugovorOZakupuDTO);
                }
                else
                    continue;
                
            }
            return Ok(ugovoriDTO);

        }


        /// <summary>
        /// Vraća sve kupce.
        /// </summary>
        /// <returns>Vraća potvrdu o listi postojećih kupaca.</returns>
        /// <param name="ugovorOZakupuID">ID lica.</param>
        /// <param name="authorization">Autorizovan token.</param>
        /// <response code="200">Vraća listu kupaca.</response>
        /// <response code="204">Ne postoje kupaca.</response>
        /// <response code="500">Adresa lica nije pronađena.</response>
        [HttpGet("{ugovorOZakupuID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UgovorOZakupuDTO> GetUgovor(Guid ugovorOZakupuID, [FromHeader] string authorization)
        {
            UgovorOZakupuEntity? ugovor = ugovorOZakupuRepository.GetUgovorOZakupuID(ugovorOZakupuID);
            if (ugovor == null)
                return NotFound();

            Guid tempDokumentID = ugovor.DokumentID; ;
            DokumentDTO? dokument = dokumentiService.GetDokumentByIDAsync(tempDokumentID, authorization).Result;
            if (dokument != null)
            {
                Guid tempKupacID = ugovor.KupacID; ;
                KupacDTO? kupac = kupacService.GetKupacByIDAsync(tempKupacID, authorization).Result;
                if (kupac != null)
                {
                    UgovorOZakupuDTO ugovorDTO = mapper.Map<UgovorOZakupuDTO>(ugovor);
                    ugovorDTO.Kupac = kupac;
                    ugovorDTO.Dokument = dokument;
                    return Ok(ugovorDTO);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Kupac nije pronadjen. ID kupca: " + tempKupacID.ToString() + ".");
                }

            }
            else
                return StatusCode(StatusCodes.Status500InternalServerError, "Dokument nije pronađen. ID dokumenta: " + tempDokumentID.ToString() + ".");
        }
        /// <summary>
        /// Delete za Ugovor o zakupu za zadati ID
        /// </summary>
        /// <param name="ugovorOZakupuID"></param>
        /// <returns></returns>
        [HttpDelete("{ugovorOZakupuID}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult DeleteUgovorOZakupu(Guid ugovorOZakupuID, [FromHeader] string  authorization)
        {
            try
            {
                UgovorOZakupuEntity? ugovorOZakupu = ugovorOZakupuRepository.GetUgovorOZakupuID(ugovorOZakupuID);

                if (ugovorOZakupu == null)
                    return NotFound();

                ugovorOZakupuRepository.DeleteUgovorOZakupu(ugovorOZakupuID);
                ugovorOZakupuRepository.SaveChanges();

                return NoContent();
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
		/// Kreira novi ugovor o zakupu.
		/// </summary>
		/// <param name="ugovorOZakupuCreateDTO">DTO za ugovora o zakupu.</param>
		/// <returns>Potvrdu o kreiranom ugovoru o zakupu.</returns>
		/// <response code="201">Vraća kreiran Ugovor O Zakupu.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom kreiranja ugovora o zakupu.</response>
		[HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UgovorOZakupuDTO> CreateUgovorOZakupu([FromBody] UgovorOZakupuCreateDTO ugovorOZakupuCreateDTO, [FromHeader] string authorization)
        {
            try
            {
                List<UgovorOZakupuEntity> ugovori =ugovorOZakupuRepository.GetUgovorOZakupu();
                if (ugovori.Find(e => e.DokumentID == Guid.Parse(ugovorOZakupuCreateDTO.DokumentID)) == null)
                {
                    Guid tempID = Guid.Parse(ugovorOZakupuCreateDTO.DokumentID);
                    DokumentDTO? dokument = dokumentiService.GetDokumentByIDAsync(tempID, authorization).Result;
                    if (dokument != null)
                    {
                        Guid tempKupacID = Guid.Parse(ugovorOZakupuCreateDTO.KupacID);
                        KupacDTO? kupac = kupacService.GetKupacByIDAsync(tempKupacID, authorization).Result;
                        if (kupac != null)
                        {
                            UgovorOZakupuDTO ugovor = ugovorOZakupuRepository.CreateUgovorOZakupu(ugovorOZakupuCreateDTO);
                            ugovorOZakupuRepository.SaveChanges();

                            ugovor.Dokument = dokument;
                            ugovor.Kupac = kupac;
                            string? location = linkGenerator.GetPathByAction("GetUgovorOZakupu", "UgovoroZakupu", new { ugovorOZakupuID = ugovor.UgovorOZakupuID });

                            if (location != null)
                                return Created(location, ugovor);
                            else
                                return Created(string.Empty, ugovor);
                        }
                        else
                        {
                            return StatusCode(StatusCodes.Status422UnprocessableEntity, "Ne postoji kupac sa zadatim ID.");
                        }
                    }
                    else
                        return StatusCode(StatusCodes.Status422UnprocessableEntity, "Ne postoji dokument sa zadatim ID-jem.");
                }
                else
                    return StatusCode(StatusCodes.Status422UnprocessableEntity, "Već postoji Ugovor koji je predstavljen ovim dokumentom.");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
        /// <summary>
        /// Promena ugovora o zakupu
        /// </summary>
        /// <param name="ugovorOZakupuUpdateDTO"></param>
        /// <returns></returns>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UgovorOZakupuDTO> UpdateUgovorOZakupu(UgovorOZakupuUpdateDTO ugovorOZakupuUpdateDTO, [FromHeader] string authorization)
        {
            try
            {
                UgovorOZakupuEntity? oldUgovorOZakupu = ugovorOZakupuRepository.GetUgovorOZakupuID(Guid.Parse(ugovorOZakupuUpdateDTO.UgovorOZakupuID));
                if (oldUgovorOZakupu == null)
                    return NotFound();

                List<UgovorOZakupuEntity> ugovori = ugovorOZakupuRepository.GetUgovorOZakupu();
                UgovorOZakupuEntity? tempUgovor = ugovori.Find(e => e.UgovorOZakupuID == Guid.Parse(ugovorOZakupuUpdateDTO.UgovorOZakupuID));
                if(tempUgovor == null)
                {
                    ugovori.Remove(tempUgovor);
                }
                    Guid tempID = Guid.Parse(ugovorOZakupuUpdateDTO.DokumentID);
                    DokumentDTO? dokument = dokumentiService.GetDokumentByIDAsync(tempID, authorization).Result;
                    if (dokument != null)
                    {
                        Guid tempKupacID = Guid.Parse(ugovorOZakupuUpdateDTO.KupacID);
                        KupacDTO? kupac = kupacService.GetKupacByIDAsync(tempKupacID, authorization).Result;
                        if (kupac != null)
                        {
                            UgovorOZakupuEntity ugovor = mapper.Map<UgovorOZakupuEntity>(ugovorOZakupuUpdateDTO);
                            mapper.Map(ugovor, oldUgovorOZakupu);
                            ugovorOZakupuRepository.SaveChanges();

                            UgovorOZakupuDTO UGOVORDTO = mapper.Map<UgovorOZakupuDTO>(oldUgovorOZakupu);
                            UGOVORDTO.Dokument = dokument;
                            UGOVORDTO.Kupac = kupac;
                            return Ok(UGOVORDTO);
                        }
                        else
                        {
                            return StatusCode(StatusCodes.Status422UnprocessableEntity, "Ne postoji kupac sa zadatim ID");
                        }
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status422UnprocessableEntity, "Ne postoji dokument sa ID.");
                    }
                }
                
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }


        }


        /// <summary>
        /// Vraća opcije za rad.
        /// </summary>
        /// <returns>Vraća prazan 200 HTTP kod.</returns>
        /// <response code="200">Vraća prazan 200 HTTP kod.</response>
        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetUgovoriOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }
    }
}