using AutoMapper;
using KomisijaService.Data;
using KomisijaService.Entities;
using KomisijaService.Models;
using Microsoft.AspNetCore.Mvc;

namespace KomisijaService.Controllers
{
    [ApiController]
    [Route("api/komisije")]
    [Produces("application/json", "application/xml")]
    public class KomisijaController : ControllerBase
    {
        private readonly IKomisijaRepository komisijaRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public KomisijaController(IKomisijaRepository komisijaRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.komisijaRepository = komisijaRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

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
    }
}
