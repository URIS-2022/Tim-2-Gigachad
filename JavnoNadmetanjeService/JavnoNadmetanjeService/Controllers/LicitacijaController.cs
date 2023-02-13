using AutoMapper;
using JavnoNadmetanjeService.Entities;
using LicitacijaService.Data;
using Microsoft.AspNetCore.Mvc;

namespace JavnoNadmetanjeService.Controllers
{
    [ApiController]
    [Route("api/licitacije")]
    [Produces("application/json", "application/xml")]
    public class LicitacijaController : ControllerBase
    {
        private readonly ILicitacijaRepository licitacijaRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public LicitacijaController(ILicitacijaRepository licitacijaRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.licitacijaRepository = licitacijaRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<LicitacijaEntity>> GetLicitacija()
        {
            //return Ok("aaaaaaaa");
            var licitacije = licitacijaRepository.GetLicitacija();
            if (licitacije == null || licitacije.Count == 0)
                return NoContent();
            //return Ok(mapper.Map<List<LicitacijaDTO>>(licitacije));
            return Ok(licitacije);
        }
    }
}
