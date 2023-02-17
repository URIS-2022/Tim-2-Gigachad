using AutoMapper;
using JavnoNadmetanjeService.Data;
using JavnoNadmetanjeService.DTO;
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

        /// <summary>
		/// Dependency injection za JavnoNadmetanje kontroler.
		/// </summary>
        public JavnoNadmetanjeController(IJavnoNadmetanjeRepository javnoNadmetanjeRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.javnoNadmetanjeRepository = javnoNadmetanjeRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        /// <summary>
		/// Vraća listu svih javnih nadmetanja.
		/// </summary>
		/// <returns>Vraća potvrdu o listi postojećih javnih nadmetanja.</returns>
		/// <response code="200">Vraća listu javnih nadmetanja.</response>
		/// <response code="204">Ne postoje javna nadmetanja.</response>
        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<JavnoNadmetanjeEntity>> GetJavnaNadmetanja()
        {
            List<JavnoNadmetanjeEntity> javnoNadmetanje = javnoNadmetanjeRepository.GetJavnaNadmetanja();
            if (javnoNadmetanje == null || javnoNadmetanje.Count == 0)
                return NoContent();
            return Ok(mapper.Map<List<JavnoNadmetanjeDTO>>(javnoNadmetanje));
        }
    }
}
