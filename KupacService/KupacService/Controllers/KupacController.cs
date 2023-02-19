using AutoMapper;
using KupacService.Data;
using KupacService.Entities;
using Microsoft.AspNetCore.Mvc;
using KupacService.DTO;
using Microsoft.AspNetCore.Authorization;
using KupacService.ServiceCalls;
using System.Net;
using System.Xml.Linq;

namespace KupacService.Controllers
{
    /// <summary>
    /// Kontroler za entitet kupac.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/kupci")]
    [Produces("application/json", "application/xml")]
    public class KupacController : ControllerBase
    {
        private readonly IKupacRepository kupacRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        private readonly ILiceService liceService;
        private readonly IOvlascenoLiceService ovlascenoLiceService;

        /// <summary>
        /// Dependency injection za kontroler.
        /// </summary>
        public KupacController(IKupacRepository kupacRepository, LinkGenerator linkGenerator, IMapper mapper, ILiceService liceService, IOvlascenoLiceService ovlascenoLiceService)
        {
            this.kupacRepository = kupacRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.liceService = liceService;
            this.ovlascenoLiceService = ovlascenoLiceService;
        }

        /// <summary>
        /// Vraća sve kupce.
        /// </summary>
        /// <returns>Vraća potvrdu o listi postojećih kupaca.</returns>
        /// <param name="authorization">Autorizovan token.</param>
        /// <response code="200">Vraća listu kupaca.</response>
        /// <response code="204">Ne postoje kupaci.</response>
        /// <response code="500">Kupac nije pronađen.</response>
        [HttpHead]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public ActionResult<List<KupacEntity>> GetKupci([FromHeader] string authorization)
        {
            List<KupacEntity> kupci = kupacRepository.GetKupci();
            if (kupci == null || kupci.Count == 0)
                return NoContent();

            List<KupacDTO> kupciDTO = new();
            foreach (KupacEntity kupac in kupci)
            {
                Guid tempLiceID = kupac.LiceID; 
                LiceDTO? lice = liceService.GetLiceByIDAsync(tempLiceID, authorization).Result;

                Guid tempOvlascenoLiceID = kupac.OvlascenoLiceID;
                OvlascenoLiceDTO? ovlascenoLice = ovlascenoLiceService.GetOvlascenoLiceByIDAsync(tempOvlascenoLiceID, authorization).Result;

                if (lice != null && ovlascenoLice != null)
                {
                    KupacDTO kupacDTO = mapper.Map<KupacDTO>(kupac);
                    kupacDTO.Lice = lice;
                    kupacDTO.OvlascenoLice = ovlascenoLice;
                    kupciDTO.Add(kupacDTO);
                }
                else
                    continue;
            }
            return Ok(kupciDTO);
        }

        /// <summary>
        /// Vraća sve kupce.
        /// </summary>
        /// <returns>Vraća potvrdu o listi postojećih kupaca.</returns>
        /// <param name="kupacID">ID lica.</param>
        /// <param name="authorization">Autorizovan token.</param>
        /// <response code="200">Vraća listu kupaca.</response>
        /// <response code="204">Ne postoje kupaca.</response>
        /// <response code="500">Adresa lica nije pronađena.</response>
        [HttpGet("{kupacID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KupacDTO> GetKupac(Guid kupacID, [FromHeader] string authorization)
        {
            KupacEntity? kupac = kupacRepository.GetKupacByID(kupacID);
            if (kupac == null)
                return NotFound();

            Guid tempLiceID = kupac.LiceID; 
            LiceDTO? lice = liceService.GetLiceByIDAsync(tempLiceID, authorization).Result;
            if (lice != null)
            {
                Guid tempOvlascenoLiceID = kupac.OvlascenoLiceID;
                OvlascenoLiceDTO? ovlascenoLice = ovlascenoLiceService.GetOvlascenoLiceByIDAsync(tempOvlascenoLiceID, authorization).Result;
                if (ovlascenoLice != null) {
                    
                    KupacDTO kupacDTO = mapper.Map<KupacDTO>(kupac);

                    kupacDTO.Lice = lice;
                    kupacDTO.OvlascenoLice = ovlascenoLice;
                    return Ok(kupacDTO);
                }
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, "Ovlasceno lice nije pronađena. ID ovlascenog lica: " + tempOvlascenoLiceID.ToString() + ".");
            }
            else
                return StatusCode(StatusCodes.Status500InternalServerError, "Lice nije pronađeno. ID lica: " + tempLiceID.ToString() + ".");
        }

        /// <summary>
        /// Kreira novog kupca.
        /// </summary>
        /// <param name="kupacCreateDTO">Model kupca.</param>
        /// <param name="authorization">Autorizovan token.</param>
        /// <returns>Potvrdu o kreiranom kupcu.</returns>
        /// <remarks>
        /// Primer zahteva za kreiranje novog kupca. \
        /// POST /api/kupci \
        ///{ \
        ///    "liceID": "f127642e-4d73-42f1-979d-6a506aea9bdc", \
        ///    "ovlascenoLiceID": "904BD8B6-E268-4CA8-89FB-EF2750A74E19", \
        ///    "prioritet": "VLASNIKSISTEMAZANAVODNJAVANJE", \
        ///    "imaZabranu": true, \
        ///    "datumPocetkaZabrane": "2013-11-10T00:00:00", \
        ///    "datumZavrsetkaZabrane": "2020-10-10T00:00:00", \
        ///    "brojKupovina": 20 \
        ///}
        /// </remarks>
        /// <response code="200">Vraća kreiranog kupca.</response>
        /// <response code="404">Došlo je do greške na serveru prilikom kreiranja kupca.</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja lica.</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KupacCreateDTO> CreateKupac([FromBody] KupacCreateDTO kupacCreateDTO, [FromHeader] string authorization)
        {
            try
            {
                List<KupacEntity> kupci = kupacRepository.GetKupci();
                if (kupci.Find(e => e.LiceID == Guid.Parse(kupacCreateDTO.LiceID)) == null)
                { 
                    Guid tempID = Guid.Parse(kupacCreateDTO.LiceID);
                    LiceDTO? lice = liceService.GetLiceByIDAsync(tempID, authorization).Result;
                    if (lice != null)
                    {
                        Guid tempOvlascenoLiceID = Guid.Parse(kupacCreateDTO.OvlascenoLiceID);
                        OvlascenoLiceDTO? ovlascenoLice = ovlascenoLiceService.GetOvlascenoLiceByIDAsync(tempOvlascenoLiceID, authorization).Result;
                       
                        if (ovlascenoLice != null)
                        {
                            KupacDTO kupac = kupacRepository.CreateKupac(kupacCreateDTO);
                            kupacRepository.SaveChanges();

                            kupac.Lice = lice;
                            kupac.OvlascenoLice = ovlascenoLice;

                            string? location = linkGenerator.GetPathByAction("GetKupac", "Kupac", new { kupacID = kupac.KupacID });

                            if (location != null)
                                return Created(location, kupac);
                            else
                                return Created(string.Empty, kupac);
                        }
                        else
                            return StatusCode(StatusCodes.Status422UnprocessableEntity, "Ne postoji ovlasceno lice sa zadatim ID-jem.");
                    }
                    else
                        return StatusCode(StatusCodes.Status422UnprocessableEntity, "Ne postoji lice sa zadatim ID-jem.");
                }
                else
                    return StatusCode(StatusCodes.Status422UnprocessableEntity, "Već postoji kupac koji je predstavljen ovim licem.");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Briše jednog kupca na osnovu zadatog ID-ja.
        /// </summary>
        /// <param name="kupacID">ID fizičkog lica.</param>
        /// <param name="authorization">Autorizovan token.</param>
        /// <returns>Potvrdu o brisanju kupca.</returns>
        /// <response code="204">Kupac uspešno obrisan.</response>
        /// <response code="404">Specifirani kupac ne postoji i nije obrisan.</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja kupca.</response>
        [HttpDelete("{kupacID}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteKupac(Guid kupacID, [FromHeader] string authorization)
        {
            try
            {
                KupacEntity? kupac = kupacRepository.GetKupacByID(kupacID);

                if (kupac == null)
                    return NotFound();

                kupacRepository.DeleteKupac(kupacID);
                kupacRepository.SaveChanges();

                return NoContent();
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Ažurira jednog kupca.
        /// </summary>
        /// <param name="kupacUpdateDTO">DTO za ažuriranje kupca.</param>
        /// <param name="authorization">Autorizovan token.</param>
        /// <returns>Potvrdu o ažuriranom kupcu.</returns>
        /// <remarks>
        /// Primer zahteva za azuriranje kupca. \
        /// PUT /api/kupci \
        ///{ \
        ///    "kupacID" : "df2d74ef-65b6-4409-b1c3-5851f7089e0d", \
        ///    "liceID": "f127642e-4d73-42f1-979d-6a506aea9bdc", \
        ///    "ovlascenoLiceID": "904BD8B6-E268-4CA8-89FB-EF2750A74E19", \
        ///    "prioritet": "VLASNIKSISTEMAZANAVODNJAVANJE", \
        ///    "imaZabranu": true, \
        ///    "datumPocetkaZabrane": "2013-11-10T00:00:00", \
        ///    "datumZavrsetkaZabrane": "2020-10-10T00:00:00", \
        ///    "brojKupovina": 20 \
        ///}
        /// </remarks>
        /// <response code="200">Vraća ažuriranog kupca.</response>
        /// <response code="404">Specifirani kupac ne postoji.</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja kupca.</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KupacEntity> UpdateKupac(KupacUpdateDTO kupacUpdateDTO, [FromHeader] string authorization)
        {
            try
            {
                KupacEntity? oldKupac = kupacRepository.GetKupacByID(Guid.Parse(kupacUpdateDTO.KupacID));
                if (oldKupac == null)
                    return NotFound();


                List<KupacEntity> kupci = kupacRepository.GetKupci();
                KupacEntity? tempKupac = kupci.Find(e => e.KupacID == Guid.Parse(kupacUpdateDTO.KupacID));
                if (tempKupac != null)
                    kupci.Remove(tempKupac);

                if (kupci.Find(e => e.LiceID == Guid.Parse(kupacUpdateDTO.LiceID)) == null)
                {
                    Guid tempID = Guid.Parse(kupacUpdateDTO.LiceID);
                    LiceDTO? lice = liceService.GetLiceByIDAsync(tempID, authorization).Result;
                    if (lice != null)
                    {
                        Guid tempOvlascenoLiceID = Guid.Parse(kupacUpdateDTO.OvlascenoLiceID);
                        OvlascenoLiceDTO? ovlascenoLice = ovlascenoLiceService.GetOvlascenoLiceByIDAsync(tempOvlascenoLiceID, authorization).Result;
                        if (ovlascenoLice != null)
                        {
                            KupacEntity kupac = mapper.Map<KupacEntity>(kupacUpdateDTO);
                            mapper.Map(kupac, oldKupac);
                            kupacRepository.SaveChanges();

                            KupacDTO kupacDTO = mapper.Map<KupacDTO>(oldKupac);

                            kupacDTO.Lice= lice;
                            kupacDTO.OvlascenoLice = ovlascenoLice;
                            return Ok(kupacDTO);
                        }
                        else
                            return StatusCode(StatusCodes.Status422UnprocessableEntity, "Ne postoji ovlasceno lice sa zadatim ID-jem.");
                    }
                    else
                        return StatusCode(StatusCodes.Status422UnprocessableEntity, "Ne postoji lice sa zadatim ID-jem.");
                }
                else
                    return StatusCode(StatusCodes.Status422UnprocessableEntity, "Već postoji kupac koji je predstavljen ovim licem.");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Vraća opcije za rad sa kupcima.
        /// </summary>
        /// <returns>Vraća prazan 200 HTTP kod.</returns>
        /// <response code="200">Vraća prazan 200 HTTP kod.</response>
        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetKupciOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }

    }

}