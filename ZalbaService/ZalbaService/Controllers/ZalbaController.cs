﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZalbaService.Data;
using ZalbaService.Entities;
using ZalbaService.Models;

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

        /// <summary>
        /// Dependency injection za kontroler.
        /// </summary>
        public ZalbaController(IZalbaRepository zalbaRepository, LinkGenerator linkGenerator, IMapper mapper)
        {
            this.zalbaRepository = zalbaRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
        }

        /// <summary>
        /// Vraća listu svih žalbi
        /// </summary>
        /// <returns>Vraća potvrdu o listi postojećih žalbi.</returns>
		/// <response code="200">Vraća listu žalbi.</response>
		/// <response code="204">Ne postoje žalbi.</response>
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

        /// <summary>
        /// Vraća jednu žalbu na osnovu prosleđenog ID-ja.
        /// </summary>
        /// <param name="zalbaID">ID žalbe</param>
        /// <returns>Vraća potvrdu o specifiranoj žalbi.</returns>
        /// /// <response code="200">Vraća specifiranu žalbu.</response>
		/// <response code="404">Specifirana žalba ne postoji.</response>
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

        /// <summary>
        /// Kreira novu žalbu.
        /// </summary>
        /// <param name="zalbaCreateDTO"> DTO za kreiranje žalbe</param>
        /// <returns>Potvrdu o kreiranoj žalbi.</returns>
        /// /// <response code="201">Vraća kreiranu žalbu.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom kreiranja žalbe.</response>
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

        /// <summary>
		/// Briše jednu žalbu na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="zalbaID">ID žalbe.</param>
		/// <returns>Potvrdu o brisanju žalbe.</returns>
		/// <response code="204">Specifirana žalba je uspešno obrisano.</response>
		/// <response code="404">Specifirana žalba ne postoji i nije obrisano.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom brisanja specifirane žalbe.</response>
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


        /// <summary>
        /// Ažurira jednu žalbu.
        /// </summary>
        /// <param name="zalbaUpdateDTO">DTO za ažuriranje žalbe.</param>
        /// <returns>Potvrdu o ažuriranoj žalbi.</returns>
		/// <response code="200">Vraća ažuriranu žalbu.</response>
		/// <response code="404">Specifirana žalba ne postoji.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom ažuriranja žalbe.</response>
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