using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UplataService.Data;
using UplataService.Entities;
using UplataService.Models;

namespace UplataService.Controllers
{
    [ApiController]
    [Route("api/uplate")]
    [Produces("application/json", "application/xml")]
    public class UplataController : ControllerBase
    {
        private readonly IUplataRepository UplataRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public UplataController(IUplataRepository UplataRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.UplataRepository = UplataRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        /// <summary>
		/// Vraća sve uplate.
		/// </summary>
		/// <returns>Vraća potvrdu o listi postojećih uplata.</returns>
		/// <response code="200">Vraća listu fizičkih lica.</response>
		/// <response code="204">Ne postoje fizička lica.</response>
		[HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<UplataEntity>> GetUplate()
        {
            var uplate = UplataRepository.GetUplate();
            if (uplate == null || uplate.Count == 0)
                return NoContent();
            return Ok(mapper.Map<List<UplataEntity>>(uplate));
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
        public ActionResult<UplataDTO> GetUplata(Guid uplataID)
        {
            var uplata = UplataRepository.GetUplataByID(uplataID);
            if (uplata == null)
                return NotFound();
            return Ok(mapper.Map<UplataEntity>(uplata));
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
        public ActionResult<UplataCreateDTO> CreateUplata([FromBody] UplataCreateDTO uplataCreateDTO)
        {
            try
            {
                UplataDTO uplata = UplataRepository.CreateUplata(uplataCreateDTO);
                UplataRepository.SaveChanges();

                string? location = linkGenerator.GetPathByAction("GetUplata", "Uplata", new { uplataID = uplata.UplataID });

                if (location != null)
                    return Created(location, uplata);
                else
                    return Created("", uplata);
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
        public ActionResult<UplataDTO> UpdateUplata(UplataUpdateDTO uplataUpdateDTO)
        {
            try
            {
                UplataEntity? oldUplata = UplataRepository.GetUplataByID(uplataUpdateDTO.UplataID);
                if (oldUplata == null)
                    return NotFound();
                UplataEntity uplata = mapper.Map<UplataEntity>(uplataUpdateDTO);
                mapper.Map(uplata, oldUplata);
                UplataRepository.SaveChanges();
                return Ok(mapper.Map<UplataDTO>(oldUplata));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
    }
}
