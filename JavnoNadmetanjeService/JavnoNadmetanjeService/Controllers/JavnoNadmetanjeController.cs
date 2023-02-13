using AutoMapper;
using JavnoNadmetanjeService.Data;
using JavnoNadmetanjeService.Entities;
using Microsoft.AspNetCore.Mvc;

namespace JavnoNadmetanjeService.Controllers
{
    /// <summary>
    /// Kontroler za javna nadmetanja.
    /// </summary>
    //[Authorize]
    [ApiController]
    [Route("api/javnaNadmetanja")]
    [Produces("application/json", "application/xml")]
    public class JavnoNadmetanjeController : ControllerBase
    {
        private readonly IJavnoNadmetanjeRepository javnoNadmetanjeRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public JavnoNadmetanjeController(IJavnoNadmetanjeRepository javnoNadmetanjeRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.javnoNadmetanjeRepository = javnoNadmetanjeRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<JavnoNadmetanjeEntity>> GetJavnoNadmetanje()
        {
            //return Ok("aaaaaaaa");
            ///
            var javnoNadmetanje = javnoNadmetanjeRepository.GetJavnoNadmetanje();
            if (javnoNadmetanje == null || javnoNadmetanje.Count == 0)
                return NoContent();
            return Ok(javnoNadmetanje);
            ///
        }
    }
}
