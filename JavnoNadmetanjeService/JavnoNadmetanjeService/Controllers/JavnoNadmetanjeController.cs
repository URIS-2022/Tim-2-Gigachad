using AutoMapper;
using JavnoNadmetanjeService.Data;
using JavnoNadmetanjeService.DTO;
using JavnoNadmetanjeService.Entities;
using JavnoNadmetanjeService.ServiceCalls;
using LicitacijaService.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public JavnoNadmetanjeController(IJavnoNadmetanjeRepository javnoNadmetanjeRepository, LinkGenerator linkGenerator, IMapper mapper)
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
        //[HttpHead]
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
                Guid adresaID = javnoNadmetanje.AdresaID;
                JavnoNadmetanjeDTO javnoNadmetanjeDTO = mapper.Map<JavnoNadmetanjeDTO>(javnoNadmetanje);
                AdresaDTO? adresaDTO = adresaService.GetAdresaByIDAsync(adresaID, authorization).Result;
                if (adresaDTO != null)
                {
                    javnoNadmetanjeDTO.Adresa = adresaDTO;
                    javnoNadmetanjeDTO.Licitacija = mapper.Map<LicitacijaDTO>(licitacijaRepository.GetLicitacijaByID(javnoNadmetanje.LicitacijaID));
                    javnaNadmetanjaDTO.Add(javnoNadmetanjeDTO);
                }
            }
            return Ok(javnaNadmetanjaDTO);
        }
        /*
        /// <summary>
		/// Vraća jedno javno nadmetanje na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="javnoNadmetanjeID">ID javnog nadmetanja.</param>
		/// <param name="authorization">Autorizovan token.</param>
		/// <returns>Vraća potvrdu o specifiranom javnom nadmetanju.</returns>
		/// <response code="200">Vraća specifirano javno nadmetanje.</response>
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
            AdresaDTO? adresaDTO = adresaService.GetAdresaByIDAsync(adresaID, authorization).Result;
            if (adresaDTO != null)
            {
                JavnoNadmetanjeDTO javnoNadmetanjeDTO = mapper.Map<JavnoNadmetanjeDTO>(javnoNadmetanje);
                javnoNadmetanjeDTO.DeoParcele = mapper.Map<DeoParceleDTO>(deoParceleRepository.GetDeoParceleByID(javnoNadmetanje.DeoParceleID));
                
                javnoNadmetanjeDTO.Adresa = adresaDTO;
                return Ok(javnoNadmetanjeDTO);
            }
            else
                return StatusCode(StatusCodes.Status500InternalServerError, "Adresa lica nije pronađena. ID adrese lica: " + adresaID.ToString() + ".");
        }

        /// <summary>
		/// Kreira novo javno nadmetanje.
		/// </summary>
		/// <param name="javnoNadmetanjeCreateDTO">DTO za kreiranje javnog nadmetanja.</param>
		/// <param name="authorization">Autorizovan token.</param>
		/// <returns>Vraća potvrdu o kreiranom javnom nadmetanju.</returns>
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
                if (adresaDTO != null)
                {
                    JavnoNadmetanjeDTO javnoNadmetanje = javnoNadmetanjeRepository.CreateJavnoNadmetanje(javnoNadmetanjeCreateDTO);
                    javnoNadmetanjeRepository.SaveChanges();
                    javnoNadmetanje.FizickoLice = mapper.Map<FizickoLiceDTO>(fizickoLiceRepository.GetFizickoLiceByID(Guid.Parse(javnoNadmetanjeCreateDTO.FizickoLiceID)));
                    if (Guid.TryParse(javnoNadmetanjeCreateDTO.PravnoLiceID, out Guid pravnoLiceID))
                    {
                        PravnoLiceEntity? pravnoLice = pravnoLiceRepository.GetPravnoLiceByID(pravnoLiceID);
                        if (pravnoLice != null)
                        {
                            javnoNadmetanje.PravnoLice = mapper.Map<PravnoLiceDTO>(pravnoLice);
                            KontaktOsobaDTO kontaktOsobaDTO = mapper.Map<KontaktOsobaDTO>(kontaktOsobaRepository.GetKontaktOsobaByID(pravnoLice.KontaktOsobaID));
                            javnoNadmetanje.PravnoLice.KontaktOsoba = kontaktOsobaDTO;
                        }
                        else
                            return StatusCode(StatusCodes.Status422UnprocessableEntity, "Već postoji zadati broj računa lica.");
                    }
                    javnoNadmetanje.Adresa = adresaDTO;

                    string? location = linkGenerator.GetPathByAction("GetLice", "Lice", new { javnoNadmetanjeID = javnoNadmetanje.ID });

                    if (location != null)
                        return Created(location, javnoNadmetanje);
                    else
                        return Created(string.Empty, javnoNadmetanje);
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
		/// Ažurira jedno javno nadmetanje.
		/// </summary>
		/// <param name="javnoNadmetanjeUpdateDTO">DTO za ažuriranje javnog nadmetanja.</param>
		/// <param name="authorization">Autorizovan token.</param>
		/// <returns>Vraća potvrdu o ažuriranom javnom nadmetanju.</returns>
		/// <response code="200">Vraća ažurirano javno nadmetanje.</response>
		/// <response code="404">Specifirano javno nadmetanje ne postoji.</response>
		/// <response code="422">Došlo je do greške, već postoji atribut sa istim vrednostima.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom ažuriranja javnog nadmetanja.</response>
		[HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<JavnoNadmetanjeDTO> UpdateJavnoNadmetanje(JavnoNadmetanjeUpdateDTO javnoNadmetanjeUpdateDTO, [FromHeader] string authorization)
        {
            try
            {
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
        */


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
