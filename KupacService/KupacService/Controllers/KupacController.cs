﻿using AutoMapper;
using KupacService.Data;
using KupacService.Entities;
using Microsoft.AspNetCore.Mvc;
using KupacService.DTO;
using Microsoft.AspNetCore.Authorization;
using KupacService.ServiceCalls;
using System.Net;

namespace KupacService.Controllers
{
    /// <summary>
    /// Kontroler za entitet kupac.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/kupci")]
    [Produces("application/json", "application/xml")]
    public class KupacController : ControllerBase
    {
        private readonly IKupacRepository kupacRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        private readonly ILiceService liceService;

        /// <summary>
        /// Dependency injection za kontroler.
        /// </summary>
        public KupacController(IKupacRepository kupacRepository, LinkGenerator linkGenerator, IMapper mapper, ILiceService liceService)
        {
            this.kupacRepository = kupacRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.liceService = liceService;
        }

        /// <summary>
        /// Vraća sve kupce.
        /// </summary>
        /// <returns>Vraća potvrdu o listi postojećih kupaca.</returns>
        /// <param name="authorization">Autorizovan token.</param>
        /// <response code="200">Vraća listu kupaca.</response>
        /// <response code="204">Ne postoje kupaca.</response>
        /// <response code="500">Adresa lica nije pronađena.</response>
        [HttpGet]
        //[HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public ActionResult<List<KupacEntity>> GetKupci([FromHeader] string authorization)
        {
            List<KupacEntity> kupci = kupacRepository.GetKupci();
            if (kupci == null || kupci.Count == 0)
                return NoContent();

            List<KupacDTO> kupciDTO = new();
            foreach (KupacEntity kupac in kupci)
            {
                Guid tempLiceID = kupac.LiceID; ;
                LiceDTO? lice = liceService.GetLiceByIDAsync(tempLiceID, authorization).Result;

                if (lice != null)
                {
                    KupacDTO kupacDTO = mapper.Map<KupacDTO>(kupac);
                    kupacDTO.Lice = lice;
                    kupciDTO.Add(kupacDTO);
                }
                else
                    continue;
            }
            return Ok(kupciDTO);
        }

        /// <summary>
        /// Vraća sve kupce.
        /// </summary>
        /// <returns>Vraća potvrdu o listi postojećih kupaca.</returns>
        /// <param name="kupacID">ID lica.</param>
        /// <param name="authorization">Autorizovan token.</param>
        /// <response code="200">Vraća listu kupaca.</response>
        /// <response code="204">Ne postoje kupaca.</response>
        /// <response code="500">Adresa lica nije pronađena.</response>
        [HttpGet("{kupacID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KupacDTO> GetKupac(Guid kupacID, [FromHeader] string authorization)
        {
            KupacEntity? kupac = kupacRepository.GetKupacByID(kupacID);
            if (kupac == null)
                return NotFound();

            Guid tempLiceID = kupac.LiceID; ;
            LiceDTO? lice = liceService.GetLiceByIDAsync(tempLiceID, authorization).Result;
            if (lice != null)
            {
                KupacDTO kupacDTO = mapper.Map<KupacDTO>(kupac);
                
                kupacDTO.Lice = lice;
                return Ok(kupacDTO);
            }
            else
                return StatusCode(StatusCodes.Status500InternalServerError, "Adresa lica nije pronađena. ID adrese lica: " + tempLiceID.ToString() + ".");
        }

        /// <summary>
        /// Kreira novog kupca.
        /// </summary>
        /// <param name="kupacCreateDTO">Model kupca.</param>
        /// <param name="authorization">Autorizovan token.</param>
        /// <returns>Potvrdu o kreiranom kupcu.</returns>
        /// <response code="200">Vraća kreiranog kupca.</response>
        /// <response code="404">Došlo je do greške na serveru prilikom kreiranja kupca.</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja lica.</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KupacCreateDTO> CreateKupac([FromBody] KupacCreateDTO kupacCreateDTO, [FromHeader] string authorization)
        {
            try
            {
                List<KupacEntity> kupci = kupacRepository.GetKupci();
                if (kupci.Find(e => e.LiceID == Guid.Parse(kupacCreateDTO.LiceID)) == null)
                { 
                    Guid tempID = Guid.Parse(kupacCreateDTO.LiceID);
                    LiceDTO? lice = liceService.GetLiceByIDAsync(tempID, authorization).Result;
                    if (lice != null)
                    {
                        KupacDTO kupac = kupacRepository.CreateKupac(kupacCreateDTO);
                        kupacRepository.SaveChanges();

                        string? location = linkGenerator.GetPathByAction("GetKupac", "Kupac", new { kupacID = kupac.KupacID });

                        if (location != null)
                            return Created(location, kupac);
                        else
                            return Created(string.Empty, kupac);
                    }
                    else
                        return StatusCode(StatusCodes.Status422UnprocessableEntity, "Ne postoji lice sa zadatim ID-jem.");
                }
                else
                    return StatusCode(StatusCodes.Status422UnprocessableEntity, "Već postoji kupac koji je predstavljen ovim licem.");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Briše jednog kupca na osnovu zadatog ID-ja.
        /// </summary>
        /// <param name="kupacUpdateDTO">ID fizičkog lica.</param>
        /// <param name="authorization">Autorizovan token.</param>
        /// <returns>Potvrdu o brisanju kupca.</returns>
        /// <response code="204">Kupac uspešno obrisan.</response>
        /// <response code="404">Specifirani kupac ne postoji i nije obrisan.</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja kupca.</response>
        [HttpDelete("{kupacID}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KupacCreateDTO> UpdateKupac([FromBody] KupacUpdateDTO kupacUpdateDTO, [FromHeader] string authorization)
        {
            try
            {
                KupacEntity? oldKupac = kupacRepository.GetKupacByID(Guid.Parse(kupacUpdateDTO.KupacID));
                if (oldKupac == null)
                    return NotFound();

                List<KupacEntity> kupci = kupacRepository.GetKupci();
                if (kupci.Find(e => e.LiceID == Guid.Parse(kupacUpdateDTO.LiceID)) == null)
                {
                    Guid tempID = Guid.Parse(kupacUpdateDTO.LiceID);
                    LiceDTO? lice = liceService.GetLiceByIDAsync(tempID, authorization).Result;
                    if (lice != null)
                    {
                        KupacEntity kupac = mapper.Map<KupacEntity>(kupacUpdateDTO);
                        mapper.Map(kupac, oldKupac);
                        kupacRepository.SaveChanges();

                        KupacDTO kupacDTO = mapper.Map<KupacDTO>(oldKupac);

                        return Ok(kupacDTO);
                    }
                    else
                        return StatusCode(StatusCodes.Status422UnprocessableEntity, "Ne postoji lice sa zadatim ID-jem.");
                }
                else
                    return StatusCode(StatusCodes.Status422UnprocessableEntity, "Već postoji kupac koji je predstavljen ovim licem.");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Ažurira jednog kupca.
        /// </summary>
        /// <param name="kupacUpdateDTO">DTO za ažuriranje kupca.</param>
        /// <returns>Potvrdu o ažuriranom kupcu.</returns>
        /// <response code="200">Vraća ažuriranog kupca.</response>
        /// <response code="404">Specifirani kupac ne postoji.</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja kupca.</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KupacEntity> UpdateFizickoLice(KupacUpdateDTO kupacUpdateDTO)
        {
            try
            {
                KupacEntity? oldKupac = kupacRepository.GetKupacByID(Guid.Parse(kupacUpdateDTO.KupacID));
                if (oldKupac == null)
                    return NotFound();
                KupacEntity kupac = mapper.Map<KupacEntity>(kupacUpdateDTO);
                mapper.Map(kupac, oldKupac);
                kupacRepository.SaveChanges();
                return Ok(mapper.Map<KupacEntity>(oldKupac));
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Vraća opcije za rad sa licima.
        /// </summary>
        /// <returns>Vraća prazan 200 HTTP kod.</returns>
        /// <response code="200">Vraća prazan 200 HTTP kod.</response>
        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetKupciOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }
    }
}