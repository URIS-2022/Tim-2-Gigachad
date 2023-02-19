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
        private readonly IDeoParceleService deoParceleService;
        private readonly IJavnoNadmetanjeService javnoNadmetanjeService;
        /// <summary>
        /// Dependency injection za kontroler preko konstruktora.
        /// </summary>
        public UgovorOZakupuController(IUgovorOZakupuRepository ugovorOZakupuRepository, LinkGenerator linkGenerator, IMapper mapper, IDokumentiService dokumentiService, IKupacService kupacService, IDeoParceleService deoParceleService, IJavnoNadmetanjeService javnoNadmetanjeService)
        {
            this.ugovorOZakupuRepository = ugovorOZakupuRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.dokumentiService = dokumentiService;
            this.kupacService = kupacService;
            this.deoParceleService = deoParceleService;
            this.javnoNadmetanjeService = javnoNadmetanjeService;
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

            List<UgovorOZakupuDTO> ugovoriDTO = new();
            foreach (UgovorOZakupuEntity ugovor in ugovoriOZakupu)
            {
                Guid tempDokumentID = ugovor.DokumentID; 
                DokumentDTO? dokument = dokumentiService.GetDokumentByIDAsync(tempDokumentID, authorization).Result;

                Guid temnpKupacID = ugovor.KupacID;
                KupacDTO? kupac = kupacService.GetKupacByIDAsync(temnpKupacID, authorization).Result;

                Guid tempDeoParceleID = ugovor.DeoParceleID;
                DeoParceleDTO? deoParcele = deoParceleService.GetDeoParceleByIDAsync(tempDeoParceleID, authorization).Result;

                Guid tempJavnoNadmetanjeID = ugovor.JavnoNadmetanjeID;
                JavnoNadmetanjeDTO? javnoNadmetanje = javnoNadmetanjeService.GetJavnoNadmetanjeByIDAsync(tempJavnoNadmetanjeID, authorization).Result;

                if (dokument != null && kupac != null && deoParcele != null && javnoNadmetanje != null)
                {
                    UgovorOZakupuDTO ugovorOZakupuDTO = mapper.Map<UgovorOZakupuDTO>(ugovor);
                    ugovorOZakupuDTO.Dokument = dokument;
                    ugovorOZakupuDTO.Kupac = kupac;
                    ugovorOZakupuDTO.DeoParcele = deoParcele;
                    ugovorOZakupuDTO.JavnoNadmetanje = javnoNadmetanje;
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

            Guid tempDokumentID = ugovor.DokumentID;
            DokumentDTO? dokument = dokumentiService.GetDokumentByIDAsync(tempDokumentID, authorization).Result;
            if (dokument != null)
            {
                Guid tempKupacID = ugovor.KupacID;
                KupacDTO? kupac = kupacService.GetKupacByIDAsync(tempKupacID, authorization).Result;
                if (kupac != null)
                {
                    Guid tempDeoParceleID = ugovor.DeoParceleID;
                    DeoParceleDTO? deo = deoParceleService.GetDeoParceleByIDAsync(tempDeoParceleID, authorization).Result;
                    if (deo != null)
                    {
                        Guid tempJavnoNadmetanjeID = ugovor.JavnoNadmetanjeID; 
                        JavnoNadmetanjeDTO? jn = javnoNadmetanjeService.GetJavnoNadmetanjeByIDAsync(tempJavnoNadmetanjeID, authorization).Result;
                        if(jn != null)
                        {
                            UgovorOZakupuDTO ugovorDTO = mapper.Map<UgovorOZakupuDTO>(ugovor);
                            ugovorDTO.Kupac = kupac;
                            ugovorDTO.Dokument = dokument;
                            ugovorDTO.DeoParcele = deo;
                            return Ok(ugovorDTO);
                        }
                        
                        else { return StatusCode(StatusCodes.Status500InternalServerError, "Javno nadmetanje nije pronadjeno. ID javnog nadmetanja: " + tempJavnoNadmetanjeID.ToString() + "."); }
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, "Deo parcele nije pronadjen. ID dela parcele: " + tempDeoParceleID.ToString() + ".");
                    }
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
        /// <param name="authorization> </param>
        /// <returns></returns>
        [HttpDelete("{ugovorOZakupuID}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public IActionResult DeleteUgovorOZakupu(Guid ugovorOZakupuID, [FromHeader] string authorization)
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
        /// <param name="authorization">DTO za ugovora o zakupu.</param>
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
                List<UgovorOZakupuEntity> ugovori = ugovorOZakupuRepository.GetUgovorOZakupu();
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
                            Guid tempDeoParceleID = ugovorOZakupuCreateDTO.DeoParceleID;
                            DeoParceleDTO? deo = deoParceleService.GetDeoParceleByIDAsync(tempDeoParceleID, authorization).Result;
                            if (deo != null)
                            {
                                Guid tempJavnoNadmetanjeID = ugovorOZakupuCreateDTO.JavnoNadmetanjeID;
                                JavnoNadmetanjeDTO? jn = javnoNadmetanjeService.GetJavnoNadmetanjeByIDAsync(tempJavnoNadmetanjeID, authorization).Result;
                                if (jn != null) 
                                {
                                    UgovorOZakupuDTO ugovor = ugovorOZakupuRepository.CreateUgovorOZakupu(ugovorOZakupuCreateDTO);
                                    ugovorOZakupuRepository.SaveChanges();

                                    ugovor.Dokument = dokument;
                                    ugovor.JavnoNadmetanje = jn;
                                    ugovor.Kupac = kupac;
                                    ugovor.DeoParcele = deo;
                                    string? location = linkGenerator.GetPathByAction("GetUgovorOZakupu", "UgovoroZakupu", new { ugovorOZakupuID = ugovor.UgovorOZakupuID });

                                    if (location != null)
                                        return Created(location, ugovor);
                                    else
                                        return Created(string.Empty, ugovor);
                                }
                                else
                                {
                                    return StatusCode(StatusCodes.Status422UnprocessableEntity, "Ne postoji javno nadmetanje sa zadatim ID.");
                                }
                            }
                            else
                            {
                                return StatusCode(StatusCodes.Status422UnprocessableEntity, "Ne postoji deo parcele sa zadatim ID.");
                            }
                        }
                        else
                            return StatusCode(StatusCodes.Status422UnprocessableEntity, "Ne postoji dokument sa zadatim ID-jem.");
                    }
                    else
                        return StatusCode(StatusCodes.Status422UnprocessableEntity, "Vec postoji dokument sa zadatim ID.");
                }
                else
                    return StatusCode(StatusCodes.Status422UnprocessableEntity, "Ne postoji ugovor sa datim dokument ID.");

            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
             }
        }
        /// <summary>
        /// Ažurira jedan Ugovor O ZAKUPU.
        /// </summary>
        /// <param name="ugovorOZakupuUpdateDTO">DTO za ažuriranje ugovora o zakupu.</param>
        /// <param name="authorization">Autorizovan token.</param>
        /// <returns>Vraća potvrdu o ažuriranom ugovoru o zakupu.</returns>
        /// <remarks>
        /// Primer zahteva za ažuriranje postojećeg ugovora o zakupu. \
        /// PUT /api/ugovorOZakupu \
        /// { 
        ///		"deoParceleID": "3846ACAF-3D0E-439A-BF27-85344934F2CA",\
        ///     "kupacID": "753D20F5-73A3-4E00-A3A2-E1C43D6B0777",\
        ///     "javnoNadmetanjeID": "c29c41d4-b729-41fe-a484-d04219fdb5a0",\
        ///     "dokumentID": "500e3385-6365-41d9-98a5-568bc359c5bd",\
        ///     "datumUgovora": "2007-01-05T00:00:00",\
        ///     "trajanjeUgovora": 11,\
         ///    "tipGarancije": "BANKARSKAGARANCIJA"\
        /// }\
        /// </remarks>
        /// <response code="200">Vraća ažurirani ugovor o zakupu.</response>
        /// <response code="404">Specifirani ugovor o zakupu ne postoji.</response>
        /// <response code="500">Došlo je do greške na serveru prilikom azuriranja ugovora o zakupu.</response>
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
                            Guid tempDeoParcele = Guid.Parse(ugovorOZakupuUpdateDTO.DeoParceleID);
                            DeoParceleDTO? deo = deoParceleService.GetDeoParceleByIDAsync(tempDeoParcele, authorization).Result;
                            if( deo != null) 
                            {
                                Guid tempJavnoNadmetanje = Guid.Parse(ugovorOZakupuUpdateDTO.JavnoNadmetanjeID);
                                JavnoNadmetanjeDTO? javno = javnoNadmetanjeService.GetJavnoNadmetanjeByIDAsync(tempJavnoNadmetanje, authorization).Result;
                                if(javno != null)
                                {
                                UgovorOZakupuEntity ugovor = mapper.Map<UgovorOZakupuEntity>(ugovorOZakupuUpdateDTO);
                                mapper.Map(ugovor, oldUgovorOZakupu);
                                ugovorOZakupuRepository.SaveChanges();

                                UgovorOZakupuDTO UGOVORDTO = mapper.Map<UgovorOZakupuDTO>(oldUgovorOZakupu);
                                UGOVORDTO.DeoParcele = deo;
                                UGOVORDTO.Dokument = dokument;
                                UGOVORDTO.JavnoNadmetanje = javno;
                                UGOVORDTO.Kupac = kupac;
                                return Ok(UGOVORDTO);
                                } 
                            else
                            {
                                return StatusCode(StatusCodes.Status422UnprocessableEntity, "Ne postoji kupac sa zadatim ID");
                            }
                            }
                            else
                                return StatusCode(StatusCodes.Status422UnprocessableEntity, "Ne postoji kupac sa zadatim ID");

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