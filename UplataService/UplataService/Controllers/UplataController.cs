using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UplataService.Data;
using UplataService.Entities;
using UplataService.Models;
using UplataService.ServiceCalls;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace UplataService.Controllers
{
    /// <summary>
	/// Kontroler za entitet uplata.
	/// </summary>
    [Authorize]
    [ApiController]
    [Route("api/uplate")]
    [Produces("application/json", "application/xml")]
    public class UplataController : ControllerBase
    {
        private readonly IUplataRepository UplataRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly IKupacService KupacService;
        private readonly IJavnoNadmetanjeService JavnoNadmetanjeService;

        /// <summary>
		/// Dependency injection za kontroler.
		/// </summary>
        public UplataController(IUplataRepository UplataRepository, LinkGenerator linkGenerator, IMapper mapper, IKupacService kupacService, IJavnoNadmetanjeService javnoNadmetanjeService)
        {
            this.UplataRepository = UplataRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.KupacService = kupacService;
            this.JavnoNadmetanjeService = javnoNadmetanjeService;
        }

        /// <summary>
		/// Vraća sve uplate.
		/// </summary>
        /// <param name="authorization">Autorizovan token.</param>
		/// <returns>Vraća potvrdu o listi postojećih uplata.</returns>
		/// <response code="200">Vraća listu uplata.</response>
		/// <response code="204">Ne postoje uplata.</response>
        /// <response code="500">Kupac nije pronađen.</response>
        [HttpHead]
		[HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<UplataEntity>> GetUplate([FromHeader] string authorization)
        {
            List<UplataEntity> uplate = UplataRepository.GetUplate();
            if (uplate == null || uplate.Count == 0)
                return NoContent();

            List<UplataDTO> uplateDTO = new();
            foreach (UplataEntity uplata in uplate)
            {
                Guid kupacID = uplata.KupacID;
                Guid javnoNadmetanjeID = uplata.JavnoNadmetanjeID;
                UplataDTO uplataDTO = mapper.Map<UplataDTO>(uplata);
                KupacDTO? kupacDTO = KupacService.GetKupacByIDAsync(kupacID, authorization).Result;
                JavnoNadmetanjeDTO? javnoNadmetanjeDTO = JavnoNadmetanjeService.GetJavnoNadmetanjeByIDAsync(javnoNadmetanjeID, authorization).Result;
                if (kupacDTO != null && javnoNadmetanjeDTO != null)
                {
                    uplataDTO.Kupac = kupacDTO;
                    uplataDTO.JavnoNadmetanje = javnoNadmetanjeDTO;
                    uplateDTO.Add(uplataDTO);
                }
            }

            return Ok(uplateDTO);
        }

        /// <summary>
		/// Vraća jednu uplatu na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="uplataID">ID uplate.</param>
        /// <param name="authorization">Autorizovan token.</param>
		/// <returns>Vraća potvrdu o traženoj uplati.</returns>
		/// <response code="200">Vraća specifiranu uplatu.</response>
		/// <response code="404">Specifirana uplata ne postoji.</response>
        [HttpGet("{uplataID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UplataDTO> GetUplata(Guid uplataID, [FromHeader] string authorization)
        {
            UplataEntity? uplata = UplataRepository.GetUplataByID(uplataID);
            if (uplata == null)
                return NotFound();

            Guid kupacID = uplata.KupacID;
            Guid javnoNadmetanjeID = uplata.JavnoNadmetanjeID;
            KupacDTO? kupacDTO = KupacService.GetKupacByIDAsync(kupacID, authorization).Result;
            UplataDTO uplataDTO = mapper.Map<UplataDTO>(uplata);
            JavnoNadmetanjeDTO? javnoNadmetanjeDTO = JavnoNadmetanjeService.GetJavnoNadmetanjeByIDAsync(javnoNadmetanjeID, authorization).Result;
            if (kupacDTO != null)
            {
                if(javnoNadmetanjeDTO != null)
                {
                    uplataDTO.Kupac = kupacDTO;
                    uplataDTO.JavnoNadmetanje = javnoNadmetanjeDTO;
                    return Ok(uplataDTO);
                }
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, "Javno nadmetanje nije pronađen. ID javnog nadmetanja: " + javnoNadmetanjeID.ToString() + ".");
            }
            else
                return StatusCode(StatusCodes.Status500InternalServerError, "Kupac nije pronađen. ID kupca: " + kupacID.ToString() + ".");
        }

        /// <summary>
		/// Briše jednu uplatu na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="uplataID">ID uplate.</param>
		/// <returns>Potvrdu o brisanju uplate.</returns>
		/// <response code="204">Uplata uspešno obrisano.</response>
		/// <response code="404">Specifirana uplata ne postoji i nije obrisana.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom brisanja uplate.</response>
		[HttpDelete("{uplataID}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteUplata(Guid uplataID)
        {
            try
            {
                UplataEntity? uplata = UplataRepository.GetUplataByID(uplataID);

                if (uplata == null)
                    return NotFound();

                UplataRepository.DeleteUplata(uplataID);
                UplataRepository.SaveChanges();

                return NoContent();
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
		/// Kreira novu uplatu.
		/// </summary>
		/// <param name="uplataCreateDTO">DTO za kreiranje uplate.</param>
        /// <param name="authorization">Autorizovan token.</param>
		/// <returns>Potvrdu o kreiranoj uplati.</returns>
        /// <remarks>
		/// Primer zahteva za kreiranje nove uplate. \
		/// POST /api/uplate \
		/// { \
        ///     "JavnoNadmetanjeID": "ABEC715B-03E0-4C9A-B97B-327F0AF16823", \
        ///     "KupacID": "93D92981-A754-41D8-8D1F-B5462A9E0386", \
        ///     "BrojRacuna": "005-417672-67", \
        ///     "PozivNaBroj": "45264", \
        ///     "Iznos": 363357, \
        ///     "Uplatilac": "Kaile Botterman", \
        ///     "SvrhaUplate": "Pellentesque at nulla", \
        ///     "DatumUplate": "2022-01-09T00:00:00" \
        /// }
        /// </remarks>
        /// <response code="201">Vraća kreiranu uplatu.</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja uplate.</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UplataCreateDTO> CreateUplata([FromBody] UplataCreateDTO uplataCreateDTO, [FromHeader] string authorization)
        {
            try
            {
                Guid kupacID = Guid.Parse(uplataCreateDTO.KupacID);
                Guid javnoNadmetanjeID = Guid.Parse(uplataCreateDTO.JavnoNadmetanjeID);
                KupacDTO? kupacDTO = KupacService.GetKupacByIDAsync(kupacID, authorization).Result;
                JavnoNadmetanjeDTO? javnoNadmetanjeDTO = JavnoNadmetanjeService.GetJavnoNadmetanjeByIDAsync(javnoNadmetanjeID, authorization).Result;
                if (kupacDTO != null)
                {
                    if(javnoNadmetanjeDTO != null)
                    {
                        UplataDTO uplata = UplataRepository.CreateUplata(uplataCreateDTO);
                        UplataRepository.SaveChanges();

                        string? location = linkGenerator.GetPathByAction("GetUplata", "Uplata", new { UplataID = uplata.UplataID });

                        if (location != null)
                            return Created(location, uplata);
                        else
                            return Created(string.Empty, uplata);
                    }
                    else
                        return StatusCode(StatusCodes.Status422UnprocessableEntity, "Ne postoji javno nadmetanje sa zadatim ID-jem.");
                }
                else
                    return StatusCode(StatusCodes.Status422UnprocessableEntity, "Ne postoji kupac sa zadatim ID-jem.");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
		/// Ažurira jednu uplatu.
		/// </summary>
		/// <param name="uplataUpdateDTO">DTO za ažuriranje uplate.</param>
		/// <returns>Potvrdu o ažuriranoj uplati.</returns>
        /// <remarks>
		/// Primer zahteva za apdejt uplate. \
		/// POST /api/uplate \
		/// { \
        ///     "JavnoNadmetanjeID": "ABEC715B-03E0-4C9A-B97B-327F0AF16823", \
        ///     "KupacID": "93D92981-A754-41D8-8D1F-B5462A9E0386", \
        ///     "BrojRacuna": "005-417672-67", \
        ///     "PozivNaBroj": "45264", \
        ///     "Iznos": 363357, \
        ///     "Uplatilac": "Kaile Botterman", \
        ///     "SvrhaUplate": "Pellentesque at nulla", \
        ///     "DatumUplate": "2022-01-09T00:00:00" \
        /// }
        /// </remarks>
		/// <response code="200">Vraća ažuriranu uplatu.</response>
		/// <response code="404">Specifiranu uplatu ne postoji.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom ažuriranja uplate.</response>
		[HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UplataDTO> UpdateUplata([FromBody] UplataUpdateDTO uplataUpdateDTO, [FromHeader] string authorization)
        {
            try
            {
                UplataEntity? oldUplata = UplataRepository.GetUplataByID(Guid.Parse(uplataUpdateDTO.UplataID));
                if (oldUplata == null)
                    return NotFound();

                Guid kupacID = Guid.Parse(uplataUpdateDTO.KupacID);
                Guid javnoNadmetanjeID = Guid.Parse(uplataUpdateDTO.JavnoNadmetanjeID);
                KupacDTO? kupacDTO = KupacService.GetKupacByIDAsync(kupacID, authorization).Result;
                JavnoNadmetanjeDTO? javnoNadmetanjeDTO = JavnoNadmetanjeService.GetJavnoNadmetanjeByIDAsync(javnoNadmetanjeID, authorization).Result;
                if (kupacDTO != null)
                {
                    if(javnoNadmetanjeDTO != null)
                    {
                        UplataEntity uplata = mapper.Map<UplataEntity>(uplataUpdateDTO);
                        mapper.Map(uplata, oldUplata);
                        UplataRepository.SaveChanges();

                        UplataDTO uplataDTO = mapper.Map<UplataDTO>(oldUplata);

                        return Ok(uplataDTO);
                    }
                    else
                        return StatusCode(StatusCodes.Status422UnprocessableEntity, "Ne postoji javno nadmetanje sa zadatim ID-jem.");
                }
                else
                    return StatusCode(StatusCodes.Status422UnprocessableEntity, "Ne postoji lice sa zadatim ID-jem.");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
		/// Vraća opcije za rad sa entitetom uplata.
		/// </summary>
		/// <returns>Vraća prazan 200 HTTP kod.</returns>
		/// <response code="200">Vraća prazan 200 HTTP kod.</response>
		[HttpOptions]
        [AllowAnonymous]
        public IActionResult GetLicaOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }
    }
}
