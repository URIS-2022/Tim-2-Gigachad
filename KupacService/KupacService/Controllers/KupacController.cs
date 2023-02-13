using AutoMapper;
using KupacService.Data;
using KupacService.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KupacService.Controllers
{
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

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<KupacEntity>> GetKupci()
        {
            //List<Kupac>
            //return Ok("ses");
            var kupci = kupacRepository.GetKupci();
            if (kupci == null || kupci.Count == 0)
                return NoContent();
            //return Ok(mapper.Map<List<FizickoLiceDTO>>(fizickaLica));
            return Ok(kupci);
        }
    }
}