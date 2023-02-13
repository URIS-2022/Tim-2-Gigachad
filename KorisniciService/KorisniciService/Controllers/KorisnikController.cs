using AutoMapper;
using KorisniciService.Data;
using Microsoft.AspNetCore.Mvc;
using KorisniciService.Entities;

namespace KorisniciService.Controllers
{
    [ApiController]
    [Route("api/korisnici")]
    [Produces("application/json", "application/xml")]
    public class KorisnikController : ControllerBase
    {
        private readonly IKorisnikRepository KorisnikRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        public KorisnikController(IKorisnikRepository KorisnikRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.KorisnikRepository = KorisnikRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<KorisnikEntity>> GetKorisnici()
        {
            //List<KorisnikDTO>
            var korisnici = KorisnikRepository.GetKorisnici();
            if (korisnici == null || korisnici.Count == 0)
                return NoContent();
            //return Ok(mapper.Map<List<KorisnikDTO>>(fizickaLica));
            return Ok(korisnici);
        }
    }
}
