using AutoMapper;
using KomisijaService.Data;
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

        public KomisijaController(IKomisijaRepository fizickoLiceRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.komisijaRepository = fizickoLiceRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<KomisijaDTO>> GetKomisije()
        {
            //List<KomisijaDTO>
            return Ok("seses");
            //var komisije = komisijaRepository.GetKomisije();
            //if (komisije == null || komisije.Count == 0)
                //return NoContent();
            //return Ok(mapper.Map<List<KomisijaDTO>>(komisije));
            //return Ok(komisije);
        }
    }
}
