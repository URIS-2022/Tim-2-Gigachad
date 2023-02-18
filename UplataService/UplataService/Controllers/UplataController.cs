using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UplataService.Data;
using UplataService.Entities;
using UplataService.Models;
using UplataService.ServiceCalls;

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

        /// <summary>
		/// Dependency injection za kontroler.
		/// </summary>
        public UplataController(IUplataRepository UplataRepository, LinkGenerator linkGenerator, IMapper mapper, IKupacService kupacService)
        {
            this.UplataRepository = UplataRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.KupacService = kupacService;
        }

        /// <summary>
		/// Vraća sve uplate.
		/// </summary>
		/// <returns>Vraća potvrdu o listi postojećih uplata.</returns>
		/// <response code="200">Vraća listu uplata.</response>
		/// <response code="204">Ne postoje uplata.</response>
        /// /// <response code="500">Kupac nije pronađen.</response>
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
                UplataDTO uplataDTO = mapper.Map<UplataDTO>(uplata);
                KupacDTO? kupacDTO = KupacService.GetKupacByIDAsync(kupacID, authorization).Result;
                if (kupacDTO != null)
                {
                    uplataDTO.Kupac = kupacDTO;
                    uplateDTO.Add(uplataDTO);
                }
            }

            return Ok(uplateDTO);
        }

        /// <summary>
		/// Vraća jednu uplatu na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="uplataID">ID uplate.</param>
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
            KupacDTO? kupacDTO = KupacService.GetKupacByIDAsync(kupacID, authorization).Result;
            if (kupacDTO != null)
            {
                UplataDTO uplataDTO = mapper.Map<UplataDTO>(uplata);
                uplataDTO.Kupac = kupacDTO;
                return Ok(uplataDTO);
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
		/// <returns>Potvrdu o kreiranoj uplati.</returns>
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
                Guid tempID = Guid.Parse(uplataCreateDTO.KupacID);
                KupacDTO? kupac = KupacService.GetKupacByIDAsync(tempID, authorization).Result;
                if (kupac != null)
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

                Guid tempID = Guid.Parse(uplataUpdateDTO.KupacID);
                KupacDTO? kupac = KupacService.GetKupacByIDAsync(tempID, authorization).Result;
                if (kupac != null)
                {
                    UplataEntity uplata = mapper.Map<UplataEntity>(uplataUpdateDTO);
                    mapper.Map(uplata, oldUplata);
                    UplataRepository.SaveChanges();

                    UplataDTO uplataDTO = mapper.Map<UplataDTO>(oldUplata);

                    return Ok(uplataDTO);
                }
                else
                    return StatusCode(StatusCodes.Status422UnprocessableEntity, "Ne postoji lice sa zadatim ID-jem.");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
    }
}
