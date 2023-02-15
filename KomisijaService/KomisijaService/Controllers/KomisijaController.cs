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
    }
}
