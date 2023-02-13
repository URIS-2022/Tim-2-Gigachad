using AdresaService.Data;
using AdresaService.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AdresaService.Controllers
{
    [ApiController]
    [Route("api/adrese")]
    [Produces("application/json", "application/xml")]
    public class AdresaController : ControllerBase
    {
        private readonly IAdresaRepository adresaRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public AdresaController(IAdresaRepository adresaRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.adresaRepository = adresaRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<AdresaEntity>> GetAdrese()
        {
            //List<AdresaDTO>
            
            var adrese = adresaRepository.GetAdrese();
            if (adrese == null || adrese.Count == 0)
                return NoContent();
            //return Ok(mapper.Map<List<AdresaDTO>>(adrese));
            return Ok(adrese);
        }
    }
}
