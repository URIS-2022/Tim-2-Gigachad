using AutoMapper;
using UgovorOZakupuService.Data;
using UgovorOZakupuService.DTO;
using UgovorOZakupuService.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UgovorOZakupuService.ServiceCalls;

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
        /// <summary>
        /// Dependency injection za kontroler preko konstruktora.
        /// </summary>
        public UgovorOZakupuController(IUgovorOZakupuRepository ugovorOZakupuRepository, LinkGenerator linkGenerator, IMapper mapper, IDokumentiService dokumentiService)
        {
            this.ugovorOZakupuRepository = ugovorOZakupuRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.dokumentiService = dokumentiService;
        }
        /// <summary>
        /// GET za sve ugovore o zakupu
        /// </summary>
        /// <returns></returns>
        //[HttpHead]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<UgovorOZakupuDTO>> GetUgovorOZakupu([FromHeader] string authorization)
        {
            List<UgovorOZakupuEntity> ugovori = ugovorOZakupuRepository.GetUgovorOZakupu();
            if (ugovori == null || ugovori.Count == 0)
                return NoContent();
            return Ok(mapper.Map<List<UgovorOZakupuDTO>>(ugovori)); 


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

        public IActionResult DeleteUgovorOZakupu(Guid ugovorOZakupuID, [FromHeader] string  authorization)
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