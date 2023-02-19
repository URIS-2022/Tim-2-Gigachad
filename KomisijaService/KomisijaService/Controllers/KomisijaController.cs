using AutoMapper;
using KomisijaService.Data;
using KomisijaService.Entities;
using KomisijaService.Models;
using KomisijaService.ServiceCalls;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KomisijaService.Controllers
{
    /// <summary>
    /// Kontroler za entitet komisija.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/komisije")]
    [Produces("application/json", "application/xml")]
    public class KomisijaController : ControllerBase
    {
        private readonly IKomisijaRepository komisijaRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;

        private readonly ILiceService liceService;

        /// <summary>
        /// Dependency injection za kontroler.
        /// </summary>
        public KomisijaController(IKomisijaRepository komisijaRepository, LinkGenerator linkGenerator, IMapper mapper, ILiceService liceService)
        {
            this.komisijaRepository = komisijaRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.liceService = liceService;
        }

        /// <summary>
        /// Vraća listu svih komisija.
        /// </summary>
        /// <param name="authorization">Autorizovani token.</param>
        /// <returns>Vraća potvrdu o listi postojećih komisija.</returns>
        /// <response code="200">Vraća listu komisija.</response>
        /// <response code="204">Ne postoje komisija.</response>

        [HttpHead]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<KomisijaEntity>> GetKomisije([FromHeader] string authorization)
        {
            List<KomisijaEntity> komisije = komisijaRepository.GetKomisije();
            if (komisije == null || komisije.Count == 0)
                return NoContent();

            List<KomisijaDTO> komisijeDTO = new();
            foreach (KomisijaEntity komisija in komisije)
            {
                Guid tempClan1ID = komisija.Clan1ID;
                LiceDTO? clan1 = liceService.GetLiceByIDAsync(tempClan1ID, authorization).Result;

                Guid tempClan2ID = komisija.Clan2ID;
                LiceDTO? clan2 = liceService.GetLiceByIDAsync(tempClan2ID, authorization).Result;

                Guid tempClan3ID = komisija.Clan3ID;
                LiceDTO? clan3 = liceService.GetLiceByIDAsync(tempClan3ID, authorization).Result;

                Guid tempPredsednikID = komisija.PredsednikID;
                LiceDTO? predsednikID = liceService.GetLiceByIDAsync(tempPredsednikID, authorization).Result;

                LiceDTO? clan4;
                LiceDTO? clan5;

                if (komisija.Clan4ID != null && komisija.Clan5ID != null)
                {
                    Guid tempClan4ID = (Guid)komisija.Clan4ID;
                    Guid tempClan5ID = (Guid)komisija.Clan5ID;
                    clan4 = liceService.GetLiceByIDAsync(tempClan4ID, authorization).Result;
                    clan5 = liceService.GetLiceByIDAsync(tempClan5ID, authorization).Result;
                    if (clan1 == null || clan2 == null || clan3 == null || clan4 == null || clan5 == null || predsednikID == null)
                        continue;
                    else
                    {
                        KomisijaDTO komisijaDTO = mapper.Map<KomisijaDTO>(komisija);
                        komisijaDTO.Clan1 = clan1;
                        komisijaDTO.Clan2 = clan2;
                        komisijaDTO.Clan3 = clan3;
                        komisijaDTO.Clan4 = clan4;
                        komisijaDTO.Clan5 = clan5;
                        komisijaDTO.Predsednik = predsednikID;

                        komisijeDTO.Add(komisijaDTO);
                    }
                }
                else if (komisija.Clan4ID != null)
                {
                    Guid tempClan4ID = (Guid)komisija.Clan4ID;
                    clan4 = liceService.GetLiceByIDAsync(tempClan4ID, authorization).Result;
                    if (clan1 == null || clan2 == null || clan3 == null || clan4 == null || predsednikID == null)
                        continue;
                    else
                    {
                        KomisijaDTO komisijaDTO = mapper.Map<KomisijaDTO>(komisija);
                        komisijaDTO.Clan1 = clan1;
                        komisijaDTO.Clan2 = clan2;
                        komisijaDTO.Clan3 = clan3;
                        komisijaDTO.Clan4 = clan4;
                        komisijaDTO.Predsednik = predsednikID;

                        komisijeDTO.Add(komisijaDTO);
                    }
                }
                else if (komisija.Clan5ID != null)
                {
                    Guid tempClan5ID = (Guid)komisija.Clan5ID;
                    clan5 = liceService.GetLiceByIDAsync(tempClan5ID, authorization).Result;
                    if (clan1 == null || clan2 == null || clan3 == null || clan5 == null || predsednikID == null)
                        continue;
                    else
                    {
                        KomisijaDTO komisijaDTO = mapper.Map<KomisijaDTO>(komisija);
                        komisijaDTO.Clan1 = clan1;
                        komisijaDTO.Clan2 = clan2;
                        komisijaDTO.Clan3 = clan3;
                        komisijaDTO.Clan5 = clan5;
                        komisijaDTO.Predsednik = predsednikID;

                        komisijeDTO.Add(komisijaDTO);
                    }
                }
                else
                {
                    if (clan1 == null || clan2 == null || clan3 == null || predsednikID == null)
                        continue;
                    else
                    {
                        KomisijaDTO komisijaDTO = mapper.Map<KomisijaDTO>(komisija);
                        komisijaDTO.Clan1 = clan1;
                        komisijaDTO.Clan2 = clan2;
                        komisijaDTO.Clan3 = clan3;
                        komisijaDTO.Predsednik = predsednikID;

                        komisijeDTO.Add(komisijaDTO);
                    }
                }
            }
            return Ok(komisijeDTO);
        }

        /// <summary>
        /// Vraća jednu komisiju na osnovu prosleđenog ID-ja.
        /// </summary>
        /// <param name="komisijaID">ID žalbe</param>
        /// <param name="authorization">Autorizovani token.</param>
        /// <returns>Vraća potvrdu o specifiranoj komisiji.</returns>
        /// <response code="200">Vraća specifiranu komisiju.</response>
        /// <response code="404">Specifirana komisija ne postoji.</response>
        [HttpGet("{komisijaID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<KomisijaDTO> GetKomisijaByID(Guid komisijaID, [FromHeader] string authorization)
        {
            
            KomisijaEntity? komisija = komisijaRepository.GetKomisijaByID(komisijaID);
            if (komisija == null)
                return NotFound();

            Guid tempClan1ID = komisija.Clan1ID;
            LiceDTO? clan1 = liceService.GetLiceByIDAsync(tempClan1ID, authorization).Result;

            Guid tempClan2ID = komisija.Clan2ID;
            LiceDTO? clan2 = liceService.GetLiceByIDAsync(tempClan2ID, authorization).Result;

            Guid tempClan3ID = komisija.Clan3ID;
            LiceDTO? clan3 = liceService.GetLiceByIDAsync(tempClan3ID, authorization).Result;

            Guid tempPredsednikID = komisija.PredsednikID;
            LiceDTO? predsednikID = liceService.GetLiceByIDAsync(tempPredsednikID, authorization).Result;

            LiceDTO? clan4;
            LiceDTO? clan5;

            if (komisija.Clan4ID != null && komisija.Clan5ID != null)
            {
                Guid tempClan4ID = (Guid)komisija.Clan4ID;
                Guid tempClan5ID = (Guid)komisija.Clan5ID;
                clan4 = liceService.GetLiceByIDAsync(tempClan4ID, authorization).Result;
                clan5 = liceService.GetLiceByIDAsync(tempClan5ID, authorization).Result;
                if (clan1 == null || clan2 == null || clan3 == null || clan4 == null || clan5 == null || predsednikID == null)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Izasao je error!");
                else
                {
                    KomisijaDTO komisijaDTO = mapper.Map<KomisijaDTO>(komisija);
                    komisijaDTO.Clan1 = clan1;
                    komisijaDTO.Clan2 = clan2;
                    komisijaDTO.Clan3 = clan3;
                    komisijaDTO.Clan4 = clan4;
                    komisijaDTO.Clan5 = clan5;
                    komisijaDTO.Predsednik = predsednikID;

                    return Ok(komisijaDTO);
                }
            }
            else if (komisija.Clan4ID != null)
            {
                Guid tempClan4ID = (Guid)komisija.Clan4ID;
                clan4 = liceService.GetLiceByIDAsync(tempClan4ID, authorization).Result;
                if (clan1 == null || clan2 == null || clan3 == null || clan4 == null || predsednikID == null)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Izasao je error!");
                else
                {
                    KomisijaDTO komisijaDTO = mapper.Map<KomisijaDTO>(komisija);
                    komisijaDTO.Clan1 = clan1;
                    komisijaDTO.Clan2 = clan2;
                    komisijaDTO.Clan3 = clan3;
                    komisijaDTO.Clan4 = clan4;
                    komisijaDTO.Predsednik = predsednikID;

                    return Ok(komisijaDTO);
                }
            }
            else if (komisija.Clan5ID != null)
            {
                Guid tempClan5ID = (Guid)komisija.Clan5ID;
                clan5 = liceService.GetLiceByIDAsync(tempClan5ID, authorization).Result;
                if (clan1 == null || clan2 == null || clan3 == null || clan5 == null || predsednikID == null)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Izasao je error!");
                else
                {
                    KomisijaDTO komisijaDTO = mapper.Map<KomisijaDTO>(komisija);
                    komisijaDTO.Clan1 = clan1;
                    komisijaDTO.Clan2 = clan2;
                    komisijaDTO.Clan3 = clan3;
                    komisijaDTO.Clan5 = clan5;
                    komisijaDTO.Predsednik = predsednikID;

                    return Ok(komisijaDTO);
                }
            }
            else
            {
                if (clan1 == null || clan2 == null || clan3 == null || predsednikID == null)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Izasao je error!");
                else
                {
                    KomisijaDTO komisijaDTO = mapper.Map<KomisijaDTO>(komisija);
                    komisijaDTO.Clan1 = clan1;
                    komisijaDTO.Clan2 = clan2;
                    komisijaDTO.Clan3 = clan3;
                    komisijaDTO.Predsednik = predsednikID;

                    return Ok(komisijaDTO);
                }
            }
        }

        /// <summary>
        /// Kreira novu komisiju.
        /// </summary>
        /// <param name="komisijaCreateDTO"> DTO za kreiranje komisije</param>
        /// <param name="authorization">Autorizovani token.</param>
        /// <returns>Potvrdu o kreiranoj komisiji.</returns>
        /// <remarks>
		/// Primer zahteva za kreiranje novog fizičkog lica. \
		/// POST /api/komisije \
		/// { \
		///		"clan1ID": "16e85d49-9cdd-41a6-85bc-180932f68999", \
		///		"clan2ID": "334f5277-a71c-4be8-b5da-5c9148b228f7", \
		///		"clan3ID": "92e0d8e9-b221-42a6-9bb8-a80974aee937", \
        ///		"clan4ID": "334f5277-a71c-4be8-b5da-5c9148b228f7", \
        ///		"clan5ID": "16e85d49-9cdd-41a6-85bc-180932f68999", \
        ///		"predsednikID": "92e0d8e9-b221-42a6-9bb8-a80974aee937", \
		/// }
		/// </remarks>
        /// <response code="201">Vraća kreiranu komisiju.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom kreiranja komisije.</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KomisijaCreateDTO> CreateKomisija([FromBody] KomisijaCreateDTO komisijaCreateDTO, [FromHeader] string authorization)
        {
            try
            {
                Guid tempClan1ID = Guid.Parse(komisijaCreateDTO.Clan1ID);
                LiceDTO? clan1 = liceService.GetLiceByIDAsync(tempClan1ID, authorization).Result;

                Guid tempClan2ID = Guid.Parse(komisijaCreateDTO.Clan2ID);
                LiceDTO? clan2 = liceService.GetLiceByIDAsync(tempClan2ID, authorization).Result;

                Guid tempClan3ID = Guid.Parse(komisijaCreateDTO.Clan3ID);
                LiceDTO? clan3 = liceService.GetLiceByIDAsync(tempClan3ID, authorization).Result;

                Guid tempPredsednikID = Guid.Parse(komisijaCreateDTO.PredsednikID);
                LiceDTO? predsednik = liceService.GetLiceByIDAsync(tempPredsednikID, authorization).Result;

                LiceDTO? clan4;
                LiceDTO? clan5;

                if (clan1 != null && clan2 != null && clan3 != null && predsednik != null)
                {
                    if (komisijaCreateDTO.Clan4ID != null && komisijaCreateDTO.Clan5ID != null)
                    {
                        clan4 = liceService.GetLiceByIDAsync(Guid.Parse(komisijaCreateDTO.Clan4ID), authorization).Result;
                        clan5 = liceService.GetLiceByIDAsync(Guid.Parse(komisijaCreateDTO.Clan5ID), authorization).Result;
                        if (clan4 != null && clan5 != null)
                        {
                            KomisijaDTO komisijaDTO = komisijaRepository.CreateKomisija(komisijaCreateDTO);
                            komisijaRepository.SaveChanges();
                            komisijaDTO.Clan1 = clan1;
                            komisijaDTO.Clan2 = clan2;
                            komisijaDTO.Clan3 = clan3;
                            komisijaDTO.Clan4 = clan4;
                            komisijaDTO.Clan5 = clan5;
                            komisijaDTO.Predsednik = predsednik;

                            string? location = linkGenerator.GetPathByAction("GetKomisijaByID", "Komisija", new { komisijaID = komisijaDTO.KomisijaID });

                            if (location != null)
                                return Created(location, komisijaDTO);
                            else
                                return Created(string.Empty, komisijaDTO);
                        }
                        else
                            return StatusCode(StatusCodes.Status500InternalServerError, "Izasao je error!");
                    }
                    else if (komisijaCreateDTO.Clan4ID != null)
                    {
                        clan4 = liceService.GetLiceByIDAsync(Guid.Parse(komisijaCreateDTO.Clan4ID), authorization).Result;
                        if (clan4 != null)
                        {
                            KomisijaDTO komisijaDTO = komisijaRepository.CreateKomisija(komisijaCreateDTO);
                            komisijaRepository.SaveChanges();
                            komisijaDTO.Clan1 = clan1;
                            komisijaDTO.Clan2 = clan2;
                            komisijaDTO.Clan3 = clan3;
                            komisijaDTO.Clan4 = clan4;
                            komisijaDTO.Predsednik = predsednik;

                            string? location = linkGenerator.GetPathByAction("GetKomisijaByID", "Komisija", new { komisijaID = komisijaDTO.KomisijaID });

                            if (location != null)
                                return Created(location, komisijaDTO);
                            else
                                return Created(string.Empty, komisijaDTO);
                        }
                        else
                            return StatusCode(StatusCodes.Status500InternalServerError, "Izasao je error!");
                    }
                    else if (komisijaCreateDTO.Clan5ID != null)
                    {
                        clan5 = liceService.GetLiceByIDAsync(Guid.Parse(komisijaCreateDTO.Clan5ID), authorization).Result;
                        if (clan5 != null)
                        {
                            KomisijaDTO komisijaDTO = komisijaRepository.CreateKomisija(komisijaCreateDTO);
                            komisijaRepository.SaveChanges();
                            komisijaDTO.Clan1 = clan1;
                            komisijaDTO.Clan2 = clan2;
                            komisijaDTO.Clan3 = clan3;
                            komisijaDTO.Clan5 = clan5;
                            komisijaDTO.Predsednik = predsednik;

                            string? location = linkGenerator.GetPathByAction("GetKomisijaByID", "Komisija", new { komisijaID = komisijaDTO.KomisijaID });

                            if (location != null)
                                return Created(location, komisijaDTO);
                            else
                                return Created(string.Empty, komisijaDTO);
                        }
                        else
                            return StatusCode(StatusCodes.Status500InternalServerError, "Izasao je error!");
                    }
                    else
                    {
                        KomisijaDTO komisijaDTO = komisijaRepository.CreateKomisija(komisijaCreateDTO);
                        komisijaRepository.SaveChanges();
                        komisijaDTO.Clan1 = clan1;
                        komisijaDTO.Clan2 = clan2;
                        komisijaDTO.Clan3 = clan3;
                        komisijaDTO.Predsednik = predsednik;

                        string? location = linkGenerator.GetPathByAction("GetKomisijaByID", "Komisija", new { komisijaID = komisijaDTO.KomisijaID });

                        if (location != null)
                            return Created(location, komisijaDTO);
                        else
                            return Created(string.Empty, komisijaDTO);
                    }
                }
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, "Izasao je error!");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Ažurira jednu komisiju.
        /// </summary>
        /// <param name="komisijaUpdateDTO">DTO za ažuriranje komisije.</param>
        /// <param name="authorization">Autorizovani token.</param>
        /// <returns>Potvrdu o ažuriranoj komisiji.</returns>
        /// <remarks>
        /// Primer zahteva za kreiranje novog fizičkog lica. \
        /// PUT /api/komisije \
        /// { \
        ///		"clan1ID": "16e85d49-9cdd-41a6-85bc-180932f68999", \
        ///		"clan2ID": "334f5277-a71c-4be8-b5da-5c9148b228f7", \
        ///		"clan3ID": "92e0d8e9-b221-42a6-9bb8-a80974aee937", \
        ///		"clan4ID": "334f5277-a71c-4be8-b5da-5c9148b228f7", \
        ///		"clan5ID": "16e85d49-9cdd-41a6-85bc-180932f68999", \
        ///		"predsednikID": "92e0d8e9-b221-42a6-9bb8-a80974aee937", \
        /// }
        /// </remarks>		/// <response code="200">Vraća ažuriranu komisiju.</response>
        /// <response code="404">Specifirana komisija ne postoji.</response>
        /// <response code="500">Došlo je do greške na serveru prilikom ažuriranja komisije.</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KomisijaDTO> UpdateKomisija(KomisijaUpdateDTO komisijaUpdateDTO, [FromHeader] string authorization)
        {
            try
            {
                KomisijaEntity? oldKomisija = komisijaRepository.GetKomisijaByID(Guid.Parse(komisijaUpdateDTO.KomisijaID));
                if (oldKomisija == null)
                    return NotFound();

                Guid tempClan1ID = Guid.Parse(komisijaUpdateDTO.Clan1ID);
                LiceDTO? clan1 = liceService.GetLiceByIDAsync(tempClan1ID, authorization).Result;

                Guid tempClan2ID = Guid.Parse(komisijaUpdateDTO.Clan2ID);
                LiceDTO? clan2 = liceService.GetLiceByIDAsync(tempClan2ID, authorization).Result;

                Guid tempClan3ID = Guid.Parse(komisijaUpdateDTO.Clan3ID);
                LiceDTO? clan3 = liceService.GetLiceByIDAsync(tempClan3ID, authorization).Result;

                Guid tempPredsednikID = Guid.Parse(komisijaUpdateDTO.PredsednikID);
                LiceDTO? predsednik = liceService.GetLiceByIDAsync(tempPredsednikID, authorization).Result;

                LiceDTO? clan4;
                LiceDTO? clan5;

                if (clan1 != null && clan2 != null && clan3 != null && predsednik != null)
                {
                    if (komisijaUpdateDTO.Clan4ID != null && komisijaUpdateDTO.Clan5ID != null)
                    {
                        clan4 = liceService.GetLiceByIDAsync(Guid.Parse(komisijaUpdateDTO.Clan4ID), authorization).Result;
                        clan5 = liceService.GetLiceByIDAsync(Guid.Parse(komisijaUpdateDTO.Clan5ID), authorization).Result;
                        if (clan4 != null && clan5 != null)
                        {
                            KomisijaEntity komisija = mapper.Map<KomisijaEntity>(komisijaUpdateDTO);
                            mapper.Map(komisija, oldKomisija);
                            komisijaRepository.SaveChanges();

                            KomisijaDTO komisijaDTO = mapper.Map<KomisijaDTO>(oldKomisija);
                            komisijaDTO.Clan1 = clan1;
                            komisijaDTO.Clan2 = clan2;
                            komisijaDTO.Clan3 = clan3;
                            komisijaDTO.Clan4 = clan4;
                            komisijaDTO.Clan5 = clan5;
                            komisijaDTO.Predsednik = predsednik;

                            return Ok(komisijaDTO);
                        }
                        else
                            return StatusCode(StatusCodes.Status500InternalServerError, "Izasao je error!");
                    }
                    else if (komisijaUpdateDTO.Clan4ID != null)
                    {
                        clan4 = liceService.GetLiceByIDAsync(Guid.Parse(komisijaUpdateDTO.Clan4ID), authorization).Result;
                        if (clan4 != null)
                        {
                            KomisijaEntity komisija = mapper.Map<KomisijaEntity>(komisijaUpdateDTO);
                            mapper.Map(komisija, oldKomisija);
                            komisijaRepository.SaveChanges();

                            KomisijaDTO komisijaDTO = mapper.Map<KomisijaDTO>(oldKomisija);
                            komisijaDTO.Clan1 = clan1;
                            komisijaDTO.Clan2 = clan2;
                            komisijaDTO.Clan3 = clan3;
                            komisijaDTO.Clan4 = clan4;
                            komisijaDTO.Predsednik = predsednik;

                            return Ok(komisijaDTO);
                        }
                        else
                            return StatusCode(StatusCodes.Status500InternalServerError, "Izasao je error!");
                    }
                    else if (komisijaUpdateDTO.Clan5ID != null)
                    {
                        clan5 = liceService.GetLiceByIDAsync(Guid.Parse(komisijaUpdateDTO.Clan5ID), authorization).Result;
                        if (clan5 != null)
                        {
                            KomisijaEntity komisija = mapper.Map<KomisijaEntity>(komisijaUpdateDTO);
                            mapper.Map(komisija, oldKomisija);
                            komisijaRepository.SaveChanges();

                            KomisijaDTO komisijaDTO = mapper.Map<KomisijaDTO>(oldKomisija);
                            komisijaDTO.Clan1 = clan1;
                            komisijaDTO.Clan2 = clan2;
                            komisijaDTO.Clan3 = clan3;
                            komisijaDTO.Clan5 = clan5;
                            komisijaDTO.Predsednik = predsednik;

                            return Ok(komisijaDTO);
                        }
                        else
                            return StatusCode(StatusCodes.Status500InternalServerError, "Izasao je error!");
                    }
                    else
                    {
                        KomisijaEntity komisija = mapper.Map<KomisijaEntity>(komisijaUpdateDTO);
                        mapper.Map(komisija, oldKomisija);
                        komisijaRepository.SaveChanges();

                        KomisijaDTO komisijaDTO = mapper.Map<KomisijaDTO>(oldKomisija);
                        komisijaDTO.Clan1 = clan1;
                        komisijaDTO.Clan2 = clan2;
                        komisijaDTO.Clan3 = clan3;
                        komisijaDTO.Predsednik = predsednik;

                        return Ok(komisijaDTO);
                    }
                }
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, "Izasao je error!");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }


        /// <summary>
        /// Briše jednu komisiju na osnovu zadatog ID-ja.
        /// </summary>
        /// <param name="komisijaID">ID komisije.</param>
        /// <param name="authorization">Autorizovani token.</param>
        /// <returns>Vraća potvrdu o brisanju komisije.</returns>
        /// /// <response code="204">Specifirana komisija je uspešno obrisana.</response>
		/// <response code="404">Specifirana komisija ne postoji i nije obrisana.</response>
		/// <response code="500">Došlo je do greške na serveru prilikom brisanja specifirane komisije.</response>
        [HttpDelete("{komisijaID}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteKomisija(Guid komisijaID, [FromHeader] string authorization)
        {
            try
            {
                KomisijaEntity? komisija = komisijaRepository.GetKomisijaByID(komisijaID);

                if (komisija == null)
                    return NotFound();

                komisijaRepository.DeleteKomisija(komisijaID);
                komisijaRepository.SaveChanges();

                return NoContent();
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
		/// Vraća opcije za rad sa komisijama.
		/// </summary>
		/// <returns>Vraća prazan 200 HTTP kod.</returns>
		/// <response code="200">Vraća prazan 200 HTTP kod.</response>
		[HttpOptions]
        [AllowAnonymous]
        public IActionResult GetKomisijeOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }
    }
}
