using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ZalbaService.Data;
using ZalbaService.Entities;
using ZalbaService.Models;

namespace ZalbaService.Controllers
{
    [ApiController]
    [Route("api/zalbe")]
    [Produces("application/json", "application/xml")]
    public class ZalbaController : ControllerBase
    {
        private readonly IZalbaRepository zalbaRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public ZalbaController(IZalbaRepository zalbaRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.zalbaRepository = zalbaRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<ZalbaEntity>> GetZalbe()
        {
            return Ok("seses");
            //var zalbe = zalbaRepository.GetZalbe();
            //if (zalbe == null || zalbe.Count == 0)
                //return NoContent();
            //return Ok(mapper.Map<List<FizickoLiceDTO>>(fizickaLica));
            //return Ok(zalbe);
        }
    }
}
