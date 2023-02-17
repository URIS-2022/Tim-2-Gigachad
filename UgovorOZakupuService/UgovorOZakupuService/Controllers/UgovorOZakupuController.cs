using AutoMapper;
using UgovorOZakupuService.Data;
using UgovorOZakupuService.DTO;
using UgovorOZakupuService.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DokumentiService.Controllers
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

        /// <summary>
        /// Dependency injection za kontroler preko konstruktora.
        /// </summary>
        public UgovorOZakupuController(IUgovorOZakupuRepository ugovorOZakupuRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.ugovorOZakupuRepository = ugovorOZakupuRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }
        /// <summary>
        /// GET za sve ugovore o zakupu
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<UgovorOZakupuDTO>> GetUgovorOZakupu()
        {
            var ugovor = ugovorOZakupuRepository.GetUgovorOZakupu();
            if (ugovor == null || ugovor.Count == 0)
                return NoContent();
            return Ok(mapper.Map<List<UgovorOZakupuDTO>>(ugovor));
        }
        /// <summary>
        /// Get za Ugovor O Zakupu
        /// </summary>
        /// <param name="ugovorOZakupuID"></param>
        /// <returns></returns>
        [HttpGet("{ugovorOZakupuID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<UgovorOZakupuDTO> GetUgovorOZakupu(Guid ugovorOZakupuID)
        {
            var ugovorOZakupu = ugovorOZakupuRepository.GetUgovorOZakupuID(ugovorOZakupuID);
            if (ugovorOZakupu == null)
                return NotFound();
            return Ok(mapper.Map<UgovorOZakupuEntity>(ugovorOZakupu));
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

        public IActionResult DeleteUgovorOZakupu(Guid ugovorOZakupuID)
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
        public ActionResult<UgovorOZakupuDTO> CreateUgovorOZakupu([FromBody] UgovorOZakupuCreateDTO ugovorOZakupuCreateDTO)
        {
            try
            {
                UgovorOZakupuDTO ugovorOZakupu = ugovorOZakupuRepository.CreateUgovorOZakupu(ugovorOZakupuCreateDTO);
                ugovorOZakupuRepository.SaveChanges();

                string? location = linkGenerator.GetPathByAction("GetUgovorOZakupu", "UgovorOZakupu", new { ugovorOZakupuID = ugovorOZakupu.UgovorOZakupuID });

                if (location != null)
                    return Created(location, ugovorOZakupu);
                else
                    return Created("", ugovorOZakupu);
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
        public ActionResult<UgovorOZakupuDTO> UpdateUgovorOZakupu(UgovorOZakupuUpdateDTO ugovorOZakupuUpdateDTO)
        {
            try
            {
                UgovorOZakupuEntity? ugovorOZakupu = ugovorOZakupuRepository.GetUgovorOZakupuID(ugovorOZakupuUpdateDTO.UgovorOZakupuID);
                if (ugovorOZakupu == null)
                    return NotFound();
                UgovorOZakupuEntity ugovor = mapper.Map<UgovorOZakupuEntity>(ugovorOZakupuUpdateDTO);
                mapper.Map(ugovor, ugovorOZakupu);
                ugovorOZakupuRepository.SaveChanges();
                return Ok(mapper.Map<UgovorOZakupuDTO>(ugovorOZakupu));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }



    }
}