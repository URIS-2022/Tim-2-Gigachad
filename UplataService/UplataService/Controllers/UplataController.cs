using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UplataService.Data;
using UplataService.Entities;

namespace UplataService.Controllers
{
    [ApiController]
    [Route("api/uplate")]
    [Produces("application/json", "application/xml")]
    public class UplataController : ControllerBase
    {
        private readonly IUplataRepository UplataRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public UplataController(IUplataRepository UplataRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.UplataRepository = UplataRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<UplataEntity>> GetUplate()
        {
            //List<UplataDTO>
            var uplate = UplataRepository.GetUplate();
            if (uplate == null || uplate.Count == 0)
                return NoContent();
            //return Ok(mapper.Map<List<UplataDTO>>(uplate));
            return Ok(uplate);
        }
    }
}
