using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OvlascenoLiceService.Data;
using OvlascenoLiceService.DTO;
using OvlascenoLiceService.Entities;
using OvlascenoLiceService.ServiceCalls;

namespace OvlascenoLiceService.Controllers
{
    /// <summary>
    /// Kontroler za entitet ovlasceno lice.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/ovlascenaLica")]
    [Produces("application/json", "application/xml")]
    public class OvlascenoLiceController : ControllerBase
    {
        private readonly IOvlascenoLiceRepository ovlascenoLiceRepository;
        private readonly IFizickoLiceRepository fizickoLiceRepository;
        private readonly LinkGenerator linkGenerator;
        private readonly IMapper mapper;
        private readonly IAdresaService adresaService;

        /// <summary>
        /// Dependency injection za kontroler.
        /// </summary>
        public OvlascenoLiceController(IOvlascenoLiceRepository ovlascenoLiceRepository, IFizickoLiceRepository fizickoLiceRepository, LinkGenerator linkGenerator, IMapper mapper, IAdresaService adresaService)
        {
            this.ovlascenoLiceRepository = ovlascenoLiceRepository;
            this.fizickoLiceRepository = fizickoLiceRepository;
            this.linkGenerator = linkGenerator;
            this.mapper = mapper;
            this.adresaService = adresaService;
        }

        /// <summary>
        /// Vraća listu svih ovlascenih lica.
        /// </summary>
        /// <returns>Vraća potvrdu o listi postojećih ovlascenih lica.</returns>
        /// <param name="authorization">Autorizovan token.</param>
        /// <response code="200">Vraća listu ovlasccenih lica.</response>
        /// <response code="204">Ne postoje ovlascena lica.</response>
        [HttpHead]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<OvlascenoLiceDTO>> GetLica([FromHeader] string authorization)
        {
            List<OvlascenoLiceEntity> ovlascenaLica = ovlascenoLiceRepository.GetOvlascenaLica();
            if (ovlascenaLica == null || ovlascenaLica.Count == 0)
                return NoContent();

            List<OvlascenoLiceDTO> ovlascenaLicaDTO = new();
            foreach (OvlascenoLiceEntity ovlascenoLice in ovlascenaLica)
            {
                Guid adresaID = ovlascenoLice.AdresaID;
                OvlascenoLiceDTO ovlascenoLiceDTO = mapper.Map<OvlascenoLiceDTO>(ovlascenoLice);
                AdresaDTO? adresaDTO = adresaService.GetAdresaByIDAsync(adresaID, authorization).Result;
                if (adresaDTO != null)
                {
                    ovlascenoLiceDTO.FizickoLice = mapper.Map<FizickoLiceDTO>(fizickoLiceRepository.GetFizickoLiceByID(ovlascenoLice.FizickoLiceID));
                    ovlascenoLiceDTO.Adresa = adresaDTO;
                    ovlascenaLicaDTO.Add(ovlascenoLiceDTO);
                }
            }

            return Ok(ovlascenaLicaDTO);
        }

        /// <summary>
        /// Vraća listu svih ovlascenih lica.
        /// </summary>
        /// <returns>Vraća potvrdu o listi postojećih ovlascenih lica.</returns>
        /// <param name="ovlascenoLiceID">ID lica.</param>
        /// <param name="authorization">Autorizovan token.</param>
        /// <response code="200">Vraća listu ovlasccenih lica.</response>
        /// <response code="204">Ne postoje ovlascena lica.</response>
        //[HttpHead]
        [HttpGet("{ovlascenoLiceID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<List<OvlascenoLiceDTO>> GetOvlascenoLiceByID(Guid ovlascenoLiceID, [FromHeader] string authorization)
        {
            OvlascenoLiceEntity? ovlascenoLice = ovlascenoLiceRepository.GetOvlascenoLiceByID(ovlascenoLiceID);
            if (ovlascenoLice == null)
                return NotFound();

            Guid adresaID = ovlascenoLice.AdresaID;
            AdresaDTO? adresaDTO = adresaService.GetAdresaByIDAsync(adresaID, authorization).Result;
            if (adresaDTO != null)
            {
                OvlascenoLiceDTO ovlascenoLiceDTO = mapper.Map<OvlascenoLiceDTO>(ovlascenoLice);
                ovlascenoLiceDTO.FizickoLice = mapper.Map<FizickoLiceDTO>(fizickoLiceRepository.GetFizickoLiceByID(ovlascenoLice.FizickoLiceID));

                ovlascenoLiceDTO.Adresa = adresaDTO;
                return Ok(ovlascenoLiceDTO);
            }
            else
                return StatusCode(StatusCodes.Status500InternalServerError, "Adresa lica nije pronađena. ID adrese lica: " + adresaID.ToString() + ".");
        }


        /// <summary>
        /// Kreira novo ovlasceno lice.
        /// </summary>
        /// <param name="ovlascenoLiceCreateDTO">DTO za kreiranje ovlascenog lica.</param>
        /// <param name="authorization">Autorizovan token.</param>
        /// <returns>Vraća potvrdu o kreiranom ovlascenom licu.</returns>
        /// <remarks>
        /// Primer zahteva za kreiranje novog ovlascenog lica. \
        /// POST /api/ovlascenaLica \
        ///    { \
        ///        "fizickoLiceID": "7756fb00-136f-4fd8-9f98-36170844c2d4", \
        ///        "adresaID": "6f79d49c-1c14-49b7-94c3-19a81c7f97a0", \
        ///        "telefon1": "4211218511", \
        ///        "telefon2": "3994610111", \
        ///        "email": "malicigo@net.org", \
        ///        "brojRacuna": "343658891760644" \
        ///    }
        /// </remarks>
        /// <response code="201">Vraća kreirano ovlasceno lice.</response>
        /// <response code="422">Došlo je do greške, već postoji prvi telefon ili drugi telefon ili broj računa na serveru sa istim vrednostima.</response>
        /// <response code="500">Došlo je do greške na serveru prilikom kreiranja ovlascenog lica.</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<OvlascenoLiceCreateDTO> CreateOvlascenoLice([FromBody] OvlascenoLiceCreateDTO ovlascenoLiceCreateDTO, [FromHeader] string authorization)
        {
            try
            {
                List<OvlascenoLiceEntity> ovlascenaLica = ovlascenoLiceRepository.GetOvlascenaLica();
                if (ovlascenaLica.Find(e => e.FizickoLiceID == Guid.Parse(ovlascenoLiceCreateDTO.FizickoLiceID)) == null)
                {
                    if (ovlascenaLica.Find(e => e.Telefon1 == ovlascenoLiceCreateDTO.Telefon1) == null &&
                    ovlascenaLica.Find(e => e.Telefon2 == ovlascenoLiceCreateDTO.Telefon1) == null)
                    {
                        if (ovlascenoLiceCreateDTO.Telefon2 == null)
                        {
                            if (ovlascenaLica.Find(e => e.BrojRacuna == ovlascenoLiceCreateDTO.BrojRacuna) == null)
                            {
                                Guid adresaID = Guid.Parse(ovlascenoLiceCreateDTO.AdresaID);
                                AdresaDTO? adresaDTO = adresaService.GetAdresaByIDAsync(adresaID, authorization).Result;
                                if (adresaDTO != null)
                                {
                                    OvlascenoLiceDTO ovlascenoLice = ovlascenoLiceRepository.CreateOvlascenoLice(ovlascenoLiceCreateDTO);
                                    ovlascenoLiceRepository.SaveChanges();
                                    ovlascenoLice.FizickoLice = mapper.Map<FizickoLiceDTO>(fizickoLiceRepository.GetFizickoLiceByID(Guid.Parse(ovlascenoLiceCreateDTO.FizickoLiceID)));
                                    
                                    ovlascenoLice.Adresa = adresaDTO;

                                    string? location = linkGenerator.GetPathByAction("GetOvlascenoLice", "OvlascenoLice", new { ovlascenoLiceID = ovlascenoLice.ID });

                                    if (location != null)
                                        return Created(location, ovlascenoLice);
                                    else
                                        return Created(string.Empty, ovlascenoLice);
                                }
                                else
                                    return StatusCode(StatusCodes.Status500InternalServerError, "Adresa lica nije pronađena. ID adrese lica: " + adresaID.ToString() + ".");
                            }
                            else
                                return StatusCode(StatusCodes.Status422UnprocessableEntity, "Već postoji zadati broj računa lica.");
                        }
                        else if (ovlascenaLica.Find(e => e.Telefon1 == ovlascenoLiceCreateDTO.Telefon2) == null &&
                            ovlascenaLica.Find(e => e.Telefon2 == ovlascenoLiceCreateDTO.Telefon2) == null)
                        {
                            if (ovlascenaLica.Find(e => e.BrojRacuna == ovlascenoLiceCreateDTO.BrojRacuna) == null)
                            {
                                Guid adresaID = Guid.Parse(ovlascenoLiceCreateDTO.AdresaID);
                                AdresaDTO? adresaDTO = adresaService.GetAdresaByIDAsync(adresaID, authorization).Result;
                                if (adresaDTO != null)
                                {
                                    OvlascenoLiceDTO ovlascenoLice = ovlascenoLiceRepository.CreateOvlascenoLice(ovlascenoLiceCreateDTO);
                                    ovlascenoLiceRepository.SaveChanges();
                                    ovlascenoLice.FizickoLice = mapper.Map<FizickoLiceDTO>(fizickoLiceRepository.GetFizickoLiceByID(Guid.Parse(ovlascenoLiceCreateDTO.FizickoLiceID)));

                                    ovlascenoLice.Adresa = adresaDTO;

                                    string? location = linkGenerator.GetPathByAction("GetOvlascenoLice", "OvlascenoLice", new { ovlascenoLiceID = ovlascenoLice.ID });

                                    if (location != null)
                                        return Created(location, ovlascenoLice);
                                    else
                                        return Created(string.Empty, ovlascenoLice);
                                }
                                else
                                    return StatusCode(StatusCodes.Status500InternalServerError, "Adresa lica nije pronađena. ID adrese lica: " + adresaID.ToString() + ".");
                            }
                            else
                                return StatusCode(StatusCodes.Status422UnprocessableEntity, "Već postoji zadati broj računa lica.");
                        }
                        else
                            return StatusCode(StatusCodes.Status422UnprocessableEntity, "Već postoji zadati telefon dva lica.");
                    }
                    else
                        return StatusCode(StatusCodes.Status422UnprocessableEntity, "Već postoji zadati telefon jedan lica.");
                }
                else
                    return StatusCode(StatusCodes.Status422UnprocessableEntity, "Već postoji zadato fizičko lice lica.");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Modifikuje ovlasceno lice.
        /// </summary>
        /// <param name="ovlascenoLiceUpdateDTO">DTO za modifikaciju ovlascenog lica.</param>
        /// <param name="authorization">Autorizovan token.</param>
        /// <returns>Vraća potvrdu o modifikovanom ovlascenom licu.</returns>
        /// <remarks>
        /// Primer zahteva za kreiranje novog ovlascenog lica. \
        /// PUT /api/ovlascenaLica \
        ///{ \
        ///    "id": "211af020-36ee-4d7b-84ef-2521af14a0cc", \
        ///    "fizickoLiceID": "7756fb00-136f-4fd8-9f98-36170844c2d4", \
        ///    "adresaID": "6f79d49c-1c14-49b7-94c3-19a81c7f97a0", \
        ///    "telefon1": "222222222", \
        ///    "telefon2": "111111111", \
        ///    "email": "malicigo@net.org", \
        ///    "brojRacuna": "343658891760644" \
        ///}
    /// </remarks>
    /// <response code="201">Vraća modifikovano ovlasceno lice.</response>
    /// <response code="422">Došlo je do greške, već postoji prvi telefon ili drugi telefon ili broj računa na serveru sa istim vrednostima.</response>
    /// <response code="500">Došlo je do greške na serveru prilikom modifikovanja ovlascenog lica.</response>
    [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<OvlascenoLiceUpdateDTO> UpdateOvlascenoLice([FromBody] OvlascenoLiceUpdateDTO ovlascenoLiceUpdateDTO, [FromHeader] string authorization)
        {
            try
            {
                OvlascenoLiceEntity? oldOvlascenoLice = ovlascenoLiceRepository.GetOvlascenoLiceByID(Guid.Parse(ovlascenoLiceUpdateDTO.ID));
                if (oldOvlascenoLice == null)
                    return NotFound();

                List<OvlascenoLiceEntity> ovlascenaLica = ovlascenoLiceRepository.GetOvlascenaLica();
                OvlascenoLiceEntity? tempOvlascenoLice = ovlascenaLica.Find(e => e.ID == Guid.Parse(ovlascenoLiceUpdateDTO.ID));
                if (tempOvlascenoLice != null)
                    ovlascenaLica.Remove(tempOvlascenoLice);

                if (ovlascenaLica.Find(e => e.FizickoLiceID == Guid.Parse(ovlascenoLiceUpdateDTO.FizickoLiceID)) == null)
                {
                    if (ovlascenaLica.Find(e => e.Telefon1 == ovlascenoLiceUpdateDTO.Telefon1) == null &&
                    ovlascenaLica.Find(e => e.Telefon2 == ovlascenoLiceUpdateDTO.Telefon1) == null)
                    {
                        if (ovlascenoLiceUpdateDTO.Telefon2 == null)
                        {
                            if (ovlascenaLica.Find(e => e.BrojRacuna == ovlascenoLiceUpdateDTO.BrojRacuna) == null)
                            {
                                Guid adresaID = Guid.Parse(ovlascenoLiceUpdateDTO.AdresaID);
                                AdresaDTO? adresaDTO = adresaService.GetAdresaByIDAsync(adresaID, authorization).Result;
                                if (adresaDTO != null)
                                {
                                    OvlascenoLiceEntity ovlascenoLice = mapper.Map<OvlascenoLiceEntity>(ovlascenoLiceUpdateDTO);
                                    mapper.Map(ovlascenoLice, oldOvlascenoLice);
                                    ovlascenoLiceRepository.SaveChanges();
                                    OvlascenoLiceDTO ovlascenoLiceDTO = mapper.Map<OvlascenoLiceDTO>(oldOvlascenoLice);
                                    ovlascenoLiceDTO.FizickoLice = mapper.Map<FizickoLiceDTO>(fizickoLiceRepository.GetFizickoLiceByID(Guid.Parse(ovlascenoLiceUpdateDTO.FizickoLiceID)));

                                    ovlascenoLiceDTO.Adresa = adresaDTO;
                                    return Ok(ovlascenoLiceDTO);
                                }
                                else
                                    return StatusCode(StatusCodes.Status500InternalServerError, "Adresa lica nije pronađena. ID adrese lica: " + adresaID.ToString() + ".");
                            }
                            else
                                return StatusCode(StatusCodes.Status422UnprocessableEntity, "Već postoji zadati broj računa lica.");
                        }
                        else if (ovlascenaLica.Find(e => e.Telefon1 == ovlascenoLiceUpdateDTO.Telefon2) == null &&
                            ovlascenaLica.Find(e => e.Telefon2 == ovlascenoLiceUpdateDTO.Telefon2) == null)
                        {
                            if (ovlascenaLica.Find(e => e.BrojRacuna == ovlascenoLiceUpdateDTO.BrojRacuna) == null)
                            {
                                Guid adresaID = Guid.Parse(ovlascenoLiceUpdateDTO.AdresaID);
                                AdresaDTO? adresaDTO = adresaService.GetAdresaByIDAsync(adresaID, authorization).Result;
                                if (adresaDTO != null)
                                {
                                    OvlascenoLiceEntity ovlascenoLice = mapper.Map<OvlascenoLiceEntity>(ovlascenoLiceUpdateDTO);
                                    mapper.Map(ovlascenoLice, oldOvlascenoLice);
                                    ovlascenoLiceRepository.SaveChanges();
                                    OvlascenoLiceDTO ovlascenoLiceDTO = mapper.Map<OvlascenoLiceDTO>(oldOvlascenoLice);
                                    ovlascenoLiceDTO.FizickoLice = mapper.Map<FizickoLiceDTO>(fizickoLiceRepository.GetFizickoLiceByID(Guid.Parse(ovlascenoLiceUpdateDTO.FizickoLiceID)));

                                    ovlascenoLiceDTO.Adresa = adresaDTO;
                                    return Ok(ovlascenoLiceDTO);
                                }
                                else
                                    return StatusCode(StatusCodes.Status500InternalServerError, "Adresa lica nije pronađena. ID adrese lica: " + adresaID.ToString() + ".");
                            }
                            else
                                return StatusCode(StatusCodes.Status422UnprocessableEntity, "Već postoji zadati broj računa lica.");
                        }
                        else
                            return StatusCode(StatusCodes.Status422UnprocessableEntity, "Već postoji zadati telefon dva lica.");
                    }
                    else
                        return StatusCode(StatusCodes.Status422UnprocessableEntity, "Već postoji zadati telefon jedan lica.");
                }
                else
                    return StatusCode(StatusCodes.Status422UnprocessableEntity, "Već postoji zadato fizičko lice lica.");
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Briše jedno ovlasceno lice na osnovu zadatog ID-ja.
        /// </summary>
        /// <param name="ovlascenoLiceID">ID ovlascenog lica.</param>
        /// <param name="authorization">Autorizovan token.</param>
        /// <returns>Vraća potvrdu o brisanju ovlascenog lica.</returns>
        /// <response code="204">Specifirano ovlasceno lice je uspešno obrisano.</response>
        /// <response code="404">Specifirano ovlasceno lice ne postoji i nije obrisano.</response>
        /// <response code="500">Došlo je do greške na serveru prilikom brisanja specifiranog ovlascenog lica.</response>
        [HttpDelete("{ovlascenoLiceID}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteLice(Guid ovlascenoLiceID, [FromHeader] string authorization)
        {
            try
            {
                OvlascenoLiceEntity? ovlascenoLice = ovlascenoLiceRepository.GetOvlascenoLiceByID(ovlascenoLiceID);

                if (ovlascenoLice == null)
                    return NotFound();

                ovlascenoLiceRepository.DeleteOvlascenoLice(ovlascenoLiceID);
                ovlascenoLiceRepository.SaveChanges();

                return NoContent();
            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// Vraća opcije za rad sa ovlascenim licima.
        /// </summary>
        /// <returns>Vraća prazan 200 HTTP kod.</returns>
        /// <response code="200">Vraća prazan 200 HTTP kod.</response>
        [HttpOptions]
        [AllowAnonymous]
        public IActionResult GetOvlascenaLicaOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }

    }
}
