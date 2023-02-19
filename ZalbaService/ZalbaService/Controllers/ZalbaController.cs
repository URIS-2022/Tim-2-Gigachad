using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZalbaService.Data;
using ZalbaService.Entities;
using ZalbaService.Models;
using ZalbaService.ServiceCalls;

namespace ZalbaService.Controllers
{
    /// <summary>
    /// Kontroler za entitet žalba.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/zalbe")]
    [Produces("application/json", "application/xml")]
    public class ZalbaController : ControllerBase
    {
        private readonly IZalbaRepository zalbaRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        private readonly IKupacService kupacService;
        /// <summary>
        /// Dependency injection za kontroler.
        /// </summary>
        public ZalbaController(IZalbaRepository zalbaRepository, LinkGenerator linkGenerator, IMapper mapper, IKupacService kupacService)
        {
            this.zalbaRepository = zalbaRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.kupacService = kupacService;
        }

        /// <summary>
        /// Vraća listu svih žalbi
        /// </summary>
        /// <param name="authorization">Autorizovan token.</param>
        /// <returns>Vraća potvrdu o listi postojećih žalbi.</returns>
		/// <response code="200">Vraća listu žalbi.</response>
		/// <response code="204">Ne postoje žalbe.</response>
        [HttpHead]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<ZalbaEntity>> GetZalbe([FromHeader] string authorization)
        {
            List<ZalbaEntity> zalbe = zalbaRepository.GetZalbe();
            if (zalbe == null || zalbe.Count == 0)
                return NoContent();

            List<ZalbaDTO> zalbeDTO = new();
            foreach (ZalbaEntity zalba in zalbe)
            {
                Guid tempKupacID = zalba.KupacID;
                KupacDTO? kupac = kupacService.GetKupacByIDAsync(tempKupacID, authorization).Result;

                if (kupac != null)
                {
                    ZalbaDTO zalbaDTO = mapper.Map<ZalbaDTO>(zalba);
                    zalbaDTO.Kupac = kupac;

                    zalbeDTO.Add(zalbaDTO);
                }
                else
                    continue;
            }
            return Ok(zalbeDTO);
        }

        /// <summary>
        /// Vraća jednu žalbu na osnovu prosleđenog ID-ja.
        /// </summary>
        /// <param name="zalbaID">ID žalbe</param>
        /// <param name="authorization">Autorizovan token.</param>
        /// <returns>Vraća potvrdu o specifiranoj žalbi.</returns>
        /// <response code="200">Vraća specifiranu žalbu.</response>
		/// <response code="404">Specifirana žalba ne postoji.</response>
        [HttpGet("{zalbaID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ZalbaDTO> GetZalbaByID(Guid zalbaID, [FromHeader] string authorization)
        {
            ZalbaEntity? zalba = zalbaRepository.GetZalbaByID(zalbaID);
            if (zalba == null) 
                return NoContent();

            Guid tempKupac = zalba.KupacID;
            KupacDTO? kupac = kupacService.GetKupacByIDAsync(tempKupac, authorization).Result;

            if (kupac == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Izasao je error!");
            else
            {
                ZalbaDTO zalbaDTO = mapper.Map<ZalbaDTO>(zalba);

                zalbaDTO.Kupac = kupac;

                return Ok(zalbaDTO);
            }

        }

        /// <summary>
        /// Kreira novu žalbu.
        /// </summary>
        /// <param name="zalbaCreateDTO"> DTO za kreiranje žalbe</param>
        /// <param name="authorization">Autorizovan token.</param>
        /// <returns>Potvrdu o kreiranoj žalbi.</returns>
        /// /// <remarks>
		/// Primer zahteva za kreiranje nove zalbe. \
		/// POST /api/zalbe \
		/// { \
		///		"kupacID": "ccc043c6-398c-485d-9840-092c0441ebe8", \
        ///     "tipZalbe": "ZALBA_NA_ODLUKU_O_DAVANJU_NA_KORISCENJE", \
        ///     "datumPodnosenja": "2022-11-11T00:00:00", \
        ///     "razlog": "razlog1", \
        ///     "obrazlozenje": "obrazlozenje1", \
        ///     "statusZalbe": "Odbijena", \
        ///     "radnjaZalbe": "JN_IDE_U_DRUGI_KRUG_SA_NOVIM_USLOVIMA" \
		/// }
		/// </remarks>
        /// <response code="201">Vraća kreiranu žalbu.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom kreiranja žalbe.</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ZalbaCreateDTO> CreateZalba([FromBody] ZalbaCreateDTO zalbaCreateDTO, [FromHeader] string authorization)
        {
            try
            {
                Guid tempKupac = Guid.Parse(zalbaCreateDTO.KupacID);
                KupacDTO? kupac = kupacService.GetKupacByIDAsync(tempKupac, authorization).Result;

                if (kupac == null)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Izasao je error!");
                else
                {
                    ZalbaDTO zalbaDTO = zalbaRepository.CreateZalba(zalbaCreateDTO);
                    zalbaRepository.SaveChanges();

                    zalbaDTO.Kupac = kupac;

                    string? location = linkGenerator.GetPathByAction("GetZalbaByID", "Zalba", new { zalbaID = zalbaDTO.ZalbaID });

                    if (location != null)
                        return Created(location, zalbaDTO);
                    else
                        return Created(string.Empty, zalbaDTO);
                }
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
		/// Briše jednu žalbu na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="zalbaID">ID žalbe.</param>
        /// <param name="authorization">Autorizovan token.</param>
		/// <returns>Potvrdu o brisanju žalbe.</returns>
		/// <response code="204">Specifirana žalba je uspešno obrisano.</response>
		/// <response code="404">Specifirana žalba ne postoji i nije obrisano.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom brisanja specifirane žalbe.</response>
        [HttpDelete("{zalbaID}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteZalba(Guid zalbaID, [FromHeader] string authorization)
        {
            try
            {
                ZalbaEntity? zalba = zalbaRepository.GetZalbaByID(zalbaID);

                if (zalba == null)
                    return NotFound();

                zalbaRepository.DeleteZalba(zalbaID);
                zalbaRepository.SaveChanges();

                return NoContent();
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }


        /// <summary>
        /// Ažurira jednu žalbu.
        /// </summary>
        /// <param name="zalbaUpdateDTO">DTO za ažuriranje žalbe.</param>
        /// <param name="authorization">Autorizovan token.</param>
        /// <returns>Potvrdu o ažuriranoj žalbi.</returns>
        /// /// <remarks>
		/// Primer zahteva za ažuriranje postojećeg fizičkog lica. \
		/// PUT /api/fizickaLica \
		/// { \
		///		"kupacID": "ccc043c6-398c-485d-9840-092c0441ebe8", \
        ///     "tipZalbe": "ZALBA_NA_ODLUKU_O_DAVANJU_NA_KORISCENJE", \
        ///     "datumPodnosenja": "2022-11-11T00:00:00", \
        ///     "razlog": "razlog1", \
        ///     "obrazlozenje": "obrazlozenje1", \
        ///     "statusZalbe": "OTVORENA", \
        ///     "radnjaZalbe": "JN_IDE_U_DRUGI_KRUG_SA_NOVIM_USLOVIMA" \
		///}
		/// </remarks>
		/// <response code="200">Vraća ažuriranu žalbu.</response>
		/// <response code="404">Specifirana žalba ne postoji.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom ažuriranja žalbe.</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ZalbaDTO> UpdateZalba(ZalbaUpdateDTO zalbaUpdateDTO, [FromHeader] string authorization)
        {
            try
            {
                ZalbaEntity? oldZalba = zalbaRepository.GetZalbaByID(Guid.Parse(zalbaUpdateDTO.ZalbaID));
                if (oldZalba == null)
                    return NotFound();

                Guid tempKupac = Guid.Parse(zalbaUpdateDTO.KupacID);
                KupacDTO? kupac = kupacService.GetKupacByIDAsync(tempKupac, authorization).Result;

                if(kupac == null) 
                    return StatusCode(StatusCodes.Status500InternalServerError, "Izasao je error!");
                else
                {
                    ZalbaEntity zalba = mapper.Map<ZalbaEntity>(zalbaUpdateDTO);
                    mapper.Map(zalba, oldZalba);
                    zalbaRepository.SaveChanges();

                    ZalbaDTO zalbaDTO = mapper.Map<ZalbaDTO>(oldZalba);
                    zalbaDTO.Kupac = kupac;

                    return Ok(zalbaDTO);
                }

            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
		/// Vraća opcije za rad sa žalbama.
		/// </summary>
		/// <returns>Vraća prazan 200 HTTP kod.</returns>
		/// <response code="200">Vraća prazan 200 HTTP kod.</response>
		[HttpOptions]
        [AllowAnonymous]
        public IActionResult GetZalbeOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }
    }
}
