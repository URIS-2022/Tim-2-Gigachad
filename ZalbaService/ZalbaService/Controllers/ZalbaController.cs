using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZalbaService.Data;
using ZalbaService.Entities;
using ZalbaService.Models;

namespace ZalbaService.Controllers
{
    [Authorize]
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
            //return Ok("seses");
            var zalbe = zalbaRepository.GetZalbe();
            if (zalbe == null || zalbe.Count == 0)
                return NoContent();
            return Ok(mapper.Map<List<ZalbaDTO>>(zalbe));
            //return Ok(zalbe);
        }

        [HttpGet("{zalbaID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ZalbaDTO> GetZalbaByID(Guid zalbaID)
        {
            var zalba = zalbaRepository.GetZalbaByID(zalbaID);
            if (zalba == null)
                return NotFound();
            return Ok(mapper.Map<ZalbaDTO>(zalba));
        }


        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ZalbaCreateDTO> CreateZalba([FromBody] ZalbaCreateDTO zalbaCreateDTO)
        {
            try
            {
                ZalbaDTO zalba = zalbaRepository.CreateZalba(zalbaCreateDTO);
                zalbaRepository.SaveChanges();

                string? location = linkGenerator.GetPathByAction("GetZalba", "Zalba", new { zalbaID = zalba.ZalbaID });

                if (location != null)
                    return Created(location, zalba);
                else
                    return Created("", zalba);
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }


        [HttpDelete("{zalbaID}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteZalba(Guid zalbaID)
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



        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ZalbaDTO> UpdateZalba(ZalbaUpdateDTO zalbaUpdateDTO)
        {
            try
            {
                ZalbaEntity? oldZalba = zalbaRepository.GetZalbaByID(zalbaUpdateDTO.ZalbaID);
                if (oldZalba == null)
                    return NotFound();
                ZalbaEntity zalba = mapper.Map<ZalbaEntity>(zalbaUpdateDTO);
                mapper.Map(zalba, oldZalba);
                zalbaRepository.SaveChanges();
                return Ok(mapper.Map<ZalbaDTO>(oldZalba));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }
    }
}
