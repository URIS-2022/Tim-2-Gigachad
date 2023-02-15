using AutoMapper;
using KupacService.Data;
using KupacService.Entities;
using Microsoft.AspNetCore.Mvc;
using KupacService.DTO;
using Microsoft.AspNetCore.Authorization;

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

        public KupacController(IKupacRepository kupacRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.kupacRepository = kupacRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        /// <summary>
		/// Vraća sve kupce.
		/// </summary>
		/// <returns>Vraća potvrdu o listi postojećih kupaca.</returns>
		/// <response code="200">Vraća listu kupaca.</response>
		/// <response code="204">Ne postoje kupaca.</response>
        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<KupacEntity>> GetKupci()
        {
            var kupci = kupacRepository.GetKupci();
            if (kupci == null || kupci.Count == 0)
                return NoContent();
            return Ok(mapper.Map<List<KupacDTO>>(kupci));
        }

        /// <summary>
		/// Vraća jednog kupca na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="kupacID">ID kupca.</param>
		/// <returns>Vraća potvrdu o traženom kupcu.</returns>
		/// <response code="200">Vraća specifiranog kupca.</response>
		/// <response code="404">Specifirani kupac ne postoji.</response>
        [HttpGet("{kupacID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KupacDTO> GetKupac(Guid kupacID)
        {
            var kupac = kupacRepository.GetKupacByID(kupacID);
            if (kupac == null)
                return NotFound();
            return Ok(mapper.Map<KupacEntity>(kupac));
        }

        /// <summary>
		/// Kreira novog kupca.
		/// </summary>
		/// <param name="kupacCreateDTO">Model kupca.</param>
		/// <returns>Potvrdu o kreiranom kupcu.</returns>
		/// <response code="200">Vraća kreiranog kupca.</response>
		/// <response code="404">Došlo je do greške na serveru prilikom kreiranja kupca.</response>
		[HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KupacCreateDTO> CreateKupac([FromBody] KupacCreateDTO kupacCreateDTO)
        {
            try
            {
                KupacDTO kupac = kupacRepository.CreateKupac(kupacCreateDTO);
                kupacRepository.SaveChanges();

                string? location = linkGenerator.GetPathByAction("GetKupac", "Kupac", new { kupacID = kupac.KupacID });

                if (location != null)
                    return Created(location, kupac);
                else
                    return Created("", kupac);
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
		/// <returns>Potvrdu o brisanju kupca.</returns>
		/// <response code="204">Kupac uspešno obrisan.</response>
		/// <response code="404">Specifirani kupac ne postoji i nije obrisan.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom brisanja kupca.</response>
		[HttpDelete("{kupacID}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteKupac(Guid kupacID)
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
        /// <returns>Potvrdu o ažuriranom kupcu.</returns>
        /// <response code="200">Vraća ažuriranog kupca.</response>
        /// <response code="404">Specifirani kupac ne postoji.</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja kupca.</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KupacEntity> UpdateFizickoLice(KupacUpdateDTO kupacUpdateDTO)
        {
            try
            {
                KupacEntity? oldKupac = kupacRepository.GetKupacByID(Guid.Parse(kupacUpdateDTO.KupacID));
                if (oldKupac == null)
                    return NotFound();
                KupacEntity kupac = mapper.Map<KupacEntity>(kupacUpdateDTO);
                mapper.Map(kupac, oldKupac);
                kupacRepository.SaveChanges();
                return Ok(mapper.Map<KupacEntity>(oldKupac));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
    }
}