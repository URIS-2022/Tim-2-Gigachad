using AutoMapper;
using JavnoNadmetanjeService.Data;
using JavnoNadmetanjeService.DTO;
using JavnoNadmetanjeService.Entities;
using JavnoNadmetanjeService.ServiceCalls;
using LicitacijaService.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace JavnoNadmetanjeService.Controllers
{
    /// <summary>
    /// Kontroler za javna nadmetanja.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/javnaNadmetanja")]
    [Produces("application/json", "application/xml")]
    public class JavnoNadmetanjeController : ControllerBase
    {
        private readonly IJavnoNadmetanjeRepository javnoNadmetanjeRepository;
        private readonly ILicitacijaRepository licitacijaRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        private readonly IAdresaService adresaService;
        private readonly IDeoParceleService deoParceleService;
        private readonly IKupacService kupacService;

        /// <summary>
		/// Dependency injection za JavnoNadmetanje kontroler.
		/// </summary>
        public JavnoNadmetanjeController(IJavnoNadmetanjeRepository javnoNadmetanjeRepository,IAdresaService adresaService, IDeoParceleService deoParceleService, IKupacService kupacService, LinkGenerator linkGenerator, IMapper mapper, ILicitacijaRepository licitacijaRepository)
        {
            this.javnoNadmetanjeRepository = javnoNadmetanjeRepository;
            this.licitacijaRepository = licitacijaRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.adresaService = adresaService;
            this.deoParceleService = deoParceleService;
            this.kupacService = kupacService;
        }

        /// <summary>
		/// Vraca listu svih javnih nadmetanja.
		/// </summary>
		/// <returns>Vraca potvrdu o listi postojećih javnih nadmetanja.</returns>
		/// <param name="authorization">Autorizovan token.</param>
        /// <response code="200">Vraca listu javnih nadmetanja.</response>
		/// <response code="204">Ne postoje javna nadmetanja.</response>
        [HttpHead]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<JavnoNadmetanjeEntity>> GetJavnaNadmetanja([FromHeader] string authorization)
        {
            List<JavnoNadmetanjeEntity> javnaNadmetanja = javnoNadmetanjeRepository.GetJavnaNadmetanja();
            if (javnaNadmetanja == null || javnaNadmetanja.Count == 0)
                return NoContent();

            List<JavnoNadmetanjeDTO> javnaNadmetanjaDTO = new();
            foreach (JavnoNadmetanjeEntity javnoNadmetanje in javnaNadmetanja)
            {
                JavnoNadmetanjeDTO javnoNadmetanjeDTO = mapper.Map<JavnoNadmetanjeDTO>(javnoNadmetanje);

                Guid adresaID = javnoNadmetanje.AdresaID;
                AdresaDTO? adresaDTO = adresaService.GetAdresaByIDAsync(adresaID, authorization).Result;

                Guid deoParceleID = javnoNadmetanje.DeoParceleID;
                DeoParceleDTO? deoParceleDTO = deoParceleService.GetDeoParceleByIDAsync(deoParceleID, authorization).Result;

                Guid kupacID = javnoNadmetanje.KupacID;
                KupacDTO? kupacDTO = kupacService.GetKupacByIDAsync(kupacID, authorization).Result;

                if (adresaDTO != null)
                {
                    if (kupacDTO != null)
                    {
                        if (deoParceleDTO != null)
                        {
                            javnoNadmetanjeDTO.Adresa = adresaDTO;
                            javnoNadmetanjeDTO.DeoParcele = deoParceleDTO;
                            javnoNadmetanjeDTO.Kupac = kupacDTO;
                            javnoNadmetanjeDTO.Licitacija = mapper.Map<LicitacijaDTO>(licitacijaRepository.GetLicitacijaByID(javnoNadmetanje.LicitacijaID));
                            javnaNadmetanjaDTO.Add(javnoNadmetanjeDTO);
                        }
                        else
                            return StatusCode(StatusCodes.Status500InternalServerError, "Deo parcele nije pronadjen. ID dela parcele: " + deoParceleID.ToString() + ".");
                    }
                    else
                        return StatusCode(StatusCodes.Status500InternalServerError, "Kupac nije pronadjen. ID kupca: " + kupacID.ToString() + ".");
                }
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, "Adresa nije pronadjena. ID adrese: " + adresaID.ToString() + ".");
            }
            return Ok(javnaNadmetanjaDTO);
        }


        /// <summary>
        /// Vraca jedno javno nadmetanje na osnovu zadatog ID-ja.
        /// </summary>
        /// <param name="javnoNadmetanjeID">ID javnog nadmetanja.</param>
        /// <param name="authorization">Autorizovan token.</param>
        /// <returns>Vraca potvrdu o specifiranom javnom nadmetanju.</returns>
        /// <response code="200">Vraca specifirano javno nadmetanje.</response>
        /// <response code="404">Specifirano javno nadmetanje ne postoji.</response>
        [HttpGet("{javnoNadmetanjeID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<JavnoNadmetanjeDTO> GetJavnoNadmetanje(Guid javnoNadmetanjeID, [FromHeader] string authorization)
        {
            JavnoNadmetanjeEntity? javnoNadmetanje = javnoNadmetanjeRepository.GetJavnoNadmetanjeByID(javnoNadmetanjeID);
            if (javnoNadmetanje == null)
                return NotFound();

            Guid adresaID = javnoNadmetanje.AdresaID;
            AdresaDTO? adresa = adresaService.GetAdresaByIDAsync(adresaID, authorization).Result;

            Guid deoParceleID = javnoNadmetanje.DeoParceleID;
            DeoParceleDTO? deoParceleDTO = deoParceleService.GetDeoParceleByIDAsync(deoParceleID, authorization).Result;

            Guid kupacID = javnoNadmetanje.KupacID;
            KupacDTO? kupacDTO = kupacService.GetKupacByIDAsync(kupacID, authorization).Result;

            if (adresa != null)
            {
                if (kupacDTO != null)
                {
                    if (deoParceleDTO != null)
                    {
                        JavnoNadmetanjeDTO javnoNadmetanjeDTO = mapper.Map<JavnoNadmetanjeDTO>(javnoNadmetanje);
                        javnoNadmetanjeDTO.Licitacija = mapper.Map<LicitacijaDTO>(licitacijaRepository.GetLicitacijaByID(javnoNadmetanje.LicitacijaID));
                        javnoNadmetanjeDTO.Adresa = adresa;
                        javnoNadmetanjeDTO.DeoParcele = deoParceleDTO;
                        javnoNadmetanjeDTO.Kupac = kupacDTO;
                        return Ok(javnoNadmetanjeDTO);
                    }
                    else
                        return StatusCode(StatusCodes.Status500InternalServerError, "Deo parcele nije pronadjen. ID dela parcele: " + deoParceleID.ToString() + ".");
                }
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, "Kupac nije pronadjen. ID kupca: " + kupacID.ToString() + ".");
            }
            else
                return StatusCode(StatusCodes.Status500InternalServerError, "Adresa nije pronadjena. ID adrese: " + adresaID.ToString() + ".");
        }


        /// <summary>
		/// Kreira novo javno nadmetanje.
		/// </summary>
		/// <param name="javnoNadmetanjeCreateDTO">DTO za kreiranje javnog nadmetanja.</param>
		/// <param name="authorization">Autorizovan token.</param>
		/// <returns>Vraca potvrdu o kreiranom javnom nadmetanju.</returns>
        /// <remarks>
		/// Primer zahteva za kreiranje novog javnog nadmetanja. \
		/// POST /api/javnaNadmetanja \
		/// { \
        ///     "id": "02994fa5-b1aa-40c9-80cb-582a3549f0c1", \
        ///     "licitacijaID": "01724de1-1281-4206-a9ee-a153ba559304", \
        ///     "adresaID":  "6f79d49c-1c14-49b7-94c3-19a81c7f97a0", \
        ///     "deoParceleID":  "3846acaf-3d0e-439a-bf27-85344934f2ca", \
        ///     "kupacID": "93d92981-a754-41d8-8d1f-b5462a9e0386", \
        ///     "tipNadmetanja": "OTVARANJE_ZATVORENIH_PONUDA", \
        ///     "opstina": "ZEDNIK", \
        ///     "datumNad": "2019-05-25T00:00:00", \
        ///     "vremePoc": "2019-05-25T10:00:00", \
        ///     "vremeKraj": "2019-05-25T12:30:00", \
        ///     "periodZakupa": 28, \
        ///     "pocetnaCena": 100, \
        ///     "visinaCene": 1000000, \
        ///     "izlicitiranaCena": 14000, \
        ///     "brojUcesnika": 95, \
        ///     "prijavljeniKupci": 52, \
        ///     "licitanti": 39, \
        ///     "krug": 5, \
        ///     "statusNadmetanja": "DRUGI_KRUG_STARI", \
        ///     "izuzeto": false \
        /// }
		/// </remarks>
		/// <response code="201">Vraća kreirano javno nadmetanje.</response>
		/// <response code="422">Došlo je do greške, već postoji atribut na serveru sa istim vrednostima.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom kreiranja javnog nadmetanja.</response>
		[HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<JavnoNadmetanjeCreateDTO> CreateJavnoNadmetanje([FromBody] JavnoNadmetanjeCreateDTO javnoNadmetanjeCreateDTO, [FromHeader] string authorization)
        {
            try
            {
                Guid adresaID = Guid.Parse(javnoNadmetanjeCreateDTO.AdresaID);
                AdresaDTO? adresaDTO = adresaService.GetAdresaByIDAsync(adresaID, authorization).Result;

                Guid deoParceleID = Guid.Parse(javnoNadmetanjeCreateDTO.DeoParceleID);
                DeoParceleDTO? deoParceleDTO = deoParceleService.GetDeoParceleByIDAsync(deoParceleID, authorization).Result;

                Guid kupacID = Guid.Parse(javnoNadmetanjeCreateDTO.KupacID);
                KupacDTO? kupacDTO = kupacService.GetKupacByIDAsync(kupacID, authorization).Result;

                if (adresaDTO != null)
                {
                    if (kupacDTO != null)
                    {
                        if (deoParceleDTO != null)
                        {
                            JavnoNadmetanjeDTO javnoNadmetanje = javnoNadmetanjeRepository.CreateJavnoNadmetanje(javnoNadmetanjeCreateDTO);
                            javnoNadmetanjeRepository.SaveChanges();

                            javnoNadmetanje.Licitacija = mapper.Map<LicitacijaDTO>(licitacijaRepository.GetLicitacijaByID(Guid.Parse(javnoNadmetanjeCreateDTO.LicitacijaID)));
                            javnoNadmetanje.Adresa = adresaDTO;
                            javnoNadmetanje.DeoParcele = deoParceleDTO;
                            javnoNadmetanje.Kupac = kupacDTO;

                            string? location = linkGenerator.GetPathByAction("GetJavnoNadmetanje", "Kupac", new { javnoNadmetanjeID = javnoNadmetanje.ID });

                            if (location != null)
                                return Created(location, javnoNadmetanje);
                            else
                                return Created(string.Empty, javnoNadmetanje);
                        }
                        else
                            return StatusCode(StatusCodes.Status500InternalServerError, "Deo parcele nije pronadjen. ID dela parcele: " + deoParceleID.ToString() + ".");
                    }
                    else
                        return StatusCode(StatusCodes.Status500InternalServerError, "Kupac nije pronadjen. ID kupca: " + kupacID.ToString() + ".");
                }
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, "Adresa javnog nadmetanja nije pronadjena. ID adrese nadmetanja: " + adresaID.ToString() + ".");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }


        /// <summary>
        /// Azurira jedno javno nadmetanje.
        /// </summary>
        /// <param name="javnoNadmetanjeUpdateDTO">DTO za azuriranje javnog nadmetanja.</param>
        /// <param name="authorization">Autorizovan token.</param>
        /// <returns>Vraca potvrdu o azuriranom javnom nadmetanju.</returns>
        /// <remarks>
        /// Primer zahteva za azuriranje postojeceg javnog nadmetanja. \
        /// PUT /api/javnaNadmetanja \
        /// { \
        ///     "id": "02994fa5-b1aa-40c9-80cb-582a3549f0c1", \
        ///     "licitacijaID": "01724de1-1281-4206-a9ee-a153ba559304", \
        ///     "adresaID":  "6f79d49c-1c14-49b7-94c3-19a81c7f97a0", \
        ///     "deoParceleID":  "3846acaf-3d0e-439a-bf27-85344934f2ca", \
        ///     "kupacID": "93d92981-a754-41d8-8d1f-b5462a9e0386", \
        ///     "tipNadmetanja": "OTVARANJE_ZATVORENIH_PONUDA", \
        ///     "opstina": "ZEDNIK", \
        ///     "datumNad": "2019-05-25T00:00:00", \
        ///     "vremePoc": "2019-05-25T10:00:00", \
        ///     "vremeKraj": "2019-05-25T12:30:00", \
        ///     "periodZakupa": 28, \
        ///     "pocetnaCena": 700, \
        ///     "visinaCene": 7000000, \
        ///     "izlicitiranaCena": 74000, \
        ///     "brojUcesnika": 95, \
        ///     "prijavljeniKupci": 52, \
        ///     "licitanti": 39, \
        ///     "krug": 5, \
        ///     "statusNadmetanja": "DRUGI_KRUG_STARI", \
        ///     "izuzeto": false \
        /// }
        /// </remarks>
        /// <response code="200">Vraca azurirano javno nadmetanje.</response>
        /// <response code="404">Specifirano javno nadmetanje ne postoji.</response>
        /// <response code="422">Doslo je do greške, već postoji atribut sa istim vrednostima.</response>
        /// <response code="500">Doslo je do greške na serveru prilikom ažuriranja javnog nadmetanja.</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<JavnoNadmetanjeDTO> UpdateJavnoNadmetanje(JavnoNadmetanjeUpdateDTO javnoNadmetanjeUpdateDTO, [FromHeader] string authorization)
        {
            try
            {
                JavnoNadmetanjeEntity? oldJavnoNadmetanje = javnoNadmetanjeRepository.GetJavnoNadmetanjeByID(javnoNadmetanjeUpdateDTO.ID);
                if (oldJavnoNadmetanje == null)
                    return NotFound();

                List<JavnoNadmetanjeEntity> javnaNadmetanja = javnoNadmetanjeRepository.GetJavnaNadmetanja();
                JavnoNadmetanjeEntity? tempJavnoNadmetanje = javnaNadmetanja.Find(e => e.ID == javnoNadmetanjeUpdateDTO.ID);
                if (tempJavnoNadmetanje != null)
                    javnaNadmetanja.Remove(tempJavnoNadmetanje);

                Guid adresaID = Guid.Parse(javnoNadmetanjeUpdateDTO.AdresaID);
                AdresaDTO? adresaDTO = adresaService.GetAdresaByIDAsync(adresaID, authorization).Result;

                Guid deoParceleID = Guid.Parse(javnoNadmetanjeUpdateDTO.DeoParceleID);
                DeoParceleDTO? deoParceleDTO = deoParceleService.GetDeoParceleByIDAsync(deoParceleID, authorization).Result;

                Guid kupacID = Guid.Parse(javnoNadmetanjeUpdateDTO.KupacID);
                KupacDTO? kupacDTO = kupacService.GetKupacByIDAsync(kupacID, authorization).Result;

                if (adresaDTO != null)
                {
                    if (kupacDTO != null)
                    {
                        if (deoParceleDTO != null)
                        {
                            JavnoNadmetanjeEntity javnoNadmetanje = mapper.Map<JavnoNadmetanjeEntity>(javnoNadmetanjeUpdateDTO);
                            mapper.Map(javnoNadmetanje, oldJavnoNadmetanje);
                            javnoNadmetanjeRepository.SaveChanges();

                            JavnoNadmetanjeDTO javnoNadmetanjeDTO = mapper.Map<JavnoNadmetanjeDTO>(oldJavnoNadmetanje);

                            javnoNadmetanjeDTO.Licitacija = mapper.Map<LicitacijaDTO>(licitacijaRepository.GetLicitacijaByID(Guid.Parse(javnoNadmetanjeUpdateDTO.LicitacijaID)));
                            javnoNadmetanjeDTO.Adresa = adresaDTO;
                            javnoNadmetanjeDTO.DeoParcele = deoParceleDTO;
                            javnoNadmetanjeDTO.Kupac = kupacDTO;
                            return Ok(javnoNadmetanjeDTO);
                        }
                        else
                            return StatusCode(StatusCodes.Status500InternalServerError, "Deo parcele nije pronadjen. ID dela parcele: " + deoParceleID.ToString() + ".");
                    }
                    else
                        return StatusCode(StatusCodes.Status500InternalServerError, "Kupac nije pronadjen. ID kupca: " + kupacID.ToString() + ".");
                }
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, "Adresa javnog nadmetanja nije pronadjena. ID adrese nadmetanja: " + adresaID.ToString() + ".");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }


        /// <summary>
		/// Briše jedno javno nadmetanje na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="javnoNadmetanjeID">ID javnog nadmetanja.</param>
		/// <param name="authorization">Autorizovan token.</param>
		/// <returns>Vraća potvrdu o brisanju javnog nadmetanja.</returns>
		/// <response code="204">Specifirano javno nadmetanje je uspešno obrisano.</response>
		/// <response code="404">Specifirano javno nadmetanje ne postoji.</response>
		/// <response code="500">Došlo je do greske na serveru prilikom brisanja specifiranog javnog nadmetanja.</response>
		[HttpDelete("{javnoNadmetanjeID}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteJavnoNadmetanje(Guid javnoNadmetanjeID, [FromHeader] string authorization)
        {
            try
            {
                JavnoNadmetanjeEntity? javnoNadmetanje = javnoNadmetanjeRepository.GetJavnoNadmetanjeByID(javnoNadmetanjeID);

                if (javnoNadmetanje == null)
                    return NotFound();

                javnoNadmetanjeRepository.DeleteJavnoNadmetanje(javnoNadmetanjeID);
                javnoNadmetanjeRepository.SaveChanges();

                return NoContent();
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Vraca opcije za rad sa javnim nadmetanjima.
        /// </summary>
        /// <returns>Vraca prazan 200 HTTP kod.</returns>
        /// <response code="200">Vraca prazan 200 HTTP kod.</response>
        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetFizickaLicaOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }
    }
}
