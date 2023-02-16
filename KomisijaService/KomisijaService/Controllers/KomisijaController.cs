using AutoMapper;
using KomisijaService.Data;
using KomisijaService.Entities;
using KomisijaService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KomisijaService.Controllers
{
    /// <summary>
    /// Kontroler za entitet komisija.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/komisije")]
    [Produces("application/json", "application/xml")]
    public class KomisijaController : ControllerBase
    {
        private readonly IKomisijaRepository komisijaRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        /// <summary>
        /// Dependency injection za kontroler.
        /// </summary>
        public KomisijaController(IKomisijaRepository komisijaRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.komisijaRepository = komisijaRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        /// <summary>
        /// Vraća listu svih komisija.
        /// </summary>
        /// <returns>Vraća potvrdu o listi postojećih komisija.</returns>
		/// <response code="200">Vraća listu komisija.</response>
		/// <response code="204">Ne postoje komisija.</response>
        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<KomisijaEntity>> GetKomisije()
        {
            //List<KomisijaEntity>
            var komisije = komisijaRepository.GetKomisije();
            if (komisije == null || komisije.Count == 0)
                return NoContent();
            return Ok(mapper.Map<List<KomisijaDTO>>(komisije));
            //return Ok(komisije);
        }

        /// <summary>
        /// Vraća jednu komisiju na osnovu prosleđenog ID-ja.
        /// </summary>
        /// <param name="komisijaID">ID žalbe</param>
        /// <returns>Vraća potvrdu o specifiranoj komisiji.</returns>
        /// /// <response code="200">Vraća specifiranu komisiju.</response>
        /// <response code="404">Specifirana komisija ne postoji.</response>
        [HttpGet("{komisijaID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KomisijaDTO> GetKomisijaByID(Guid komisijaID)
        {
            var komisija = komisijaRepository.GetKomisijaByID(komisijaID);
            if (komisija == null)
                return NotFound();
            return Ok(mapper.Map<KomisijaDTO>(komisija));
        }

        /// <summary>
        /// Kreira novu komisiju.
        /// </summary>
        /// <param name="komisijaCreateDTO"> DTO za kreiranje komisije</param>
        /// <returns>Potvrdu o kreiranoj komisiji.</returns>
        /// /// <response code="201">Vraća kreiranu komisiju.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom kreiranja komisije.</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KomisijaCreateDTO> CreateKomisija([FromBody] KomisijaCreateDTO komisijaCreateDTO)
        {
            try
            {
                KomisijaDTO komisija = komisijaRepository.CreateKomisija(komisijaCreateDTO);
                komisijaRepository.SaveChanges();

                string? location = linkGenerator.GetPathByAction("GetKomisija", "Komisija", new { komisijaID = komisija.KomisijaID });

                if (location != null)
                    return Created(location, komisija);
                else
                    return Created("", komisija);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Ažurira jednu komisiju.
        /// </summary>
        /// <param name="komisijaUpdateDTO">DTO za ažuriranje komisije.</param>
        /// <returns>Potvrdu o ažuriranoj komisiji.</returns>
		/// <response code="200">Vraća ažuriranu komisiju.</response>
		/// <response code="404">Specifirana komisija ne postoji.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom ažuriranja komisije.</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KomisijaDTO> UpdateKomisija(KomisijaUpdateDTO komisijaUpdateDTO)
        {
            try
            {
                KomisijaEntity? oldKomisija = komisijaRepository.GetKomisijaByID(komisijaUpdateDTO.KomisijaID);
                if (oldKomisija == null)
                    return NotFound();
                KomisijaEntity komisija = mapper.Map<KomisijaEntity>(komisijaUpdateDTO);
                mapper.Map(komisija, oldKomisija);
                komisijaRepository.SaveChanges();
                return Ok(mapper.Map<KomisijaDTO>(oldKomisija));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }


        [HttpDelete("{komisijaID}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteKomsija(Guid komisijaID)
        {
            try
            {
                KomisijaEntity? komisija = komisijaRepository.GetKomisijaByID(komisijaID);

                if (komisija == null)
                    return NotFound();

                komisijaRepository.DeleteKomisija(komisijaID);
                komisijaRepository.SaveChanges();

                return NoContent();
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
		/// Vraća opcije za rad sa komisijama.
		/// </summary>
		/// <returns>Vraća prazan 200 HTTP kod.</returns>
		/// <response code="200">Vraća prazan 200 HTTP kod.</response>
		[HttpOptions]
        [AllowAnonymous]
        public IActionResult GetKomisijeOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }
    }
}
